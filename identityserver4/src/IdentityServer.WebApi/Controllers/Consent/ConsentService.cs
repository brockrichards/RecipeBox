// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using Microsoft.Extensions.Logging;

namespace IdentityServer.WebApi.Controllers.Consent {
    public class ConsentService {
        private readonly IClientStore _clientStore;
        private readonly IResourceStore _resourceStore;
        private readonly IIdentityServerInteractionService _interaction;
        private readonly ILogger _logger;

        public ConsentService(
            IIdentityServerInteractionService interaction,
            IClientStore clientStore,
            IResourceStore resourceStore,
            ILogger logger
        ) {
            _interaction = interaction;
            _clientStore = clientStore;
            _resourceStore = resourceStore;
            _logger = logger;
        }

        public async Task<ProcessConsentResult> ProcessConsent(ConsentInputModel model) {
            var result = new ProcessConsentResult();

            ConsentResponse grantedConsent = null;

            // user clicked 'no' - send back the standard 'access_denied' response
            if (model != null && model.Button == "no") {
                grantedConsent = new ConsentResponse {
                    Error = AuthorizationError.AccessDenied
                };
            }
            // user clicked 'yes' - validate the data
            else if (model != null && model.Button == "yes") {
                // if the user consented to some scope, build the response model
                if (model.ScopesConsented != null && model.ScopesConsented.Any()) {
                    var scopes = model.ScopesConsented;
                    if (!ConsentOptions.EnableOfflineAccess) {
                        scopes = scopes.Where(x => x != IdentityServer4.IdentityServerConstants.StandardScopes.OfflineAccess);
                    }

                    grantedConsent = new ConsentResponse {
                        RememberConsent = model.RememberConsent,
                        ScopesValuesConsented = scopes.ToArray()
                    };
                } else {
                    result.ValidationError = ConsentOptions.MustChooseOneErrorMessage;
                }
            } else {
                result.ValidationError = ConsentOptions.InvalidSelectionErrorMessage;
            }

            if (grantedConsent != null) {
                // validate return url is still valid
                var request = await _interaction.GetAuthorizationContextAsync(model.ReturnUrl);
                if (request == null)
                    return result;

                // communicate outcome of consent back to identityserver
                await _interaction.GrantConsentAsync(request, grantedConsent);

                // indicate that's it ok to redirect back to authorization endpoint
                result.RedirectUri = model.ReturnUrl;
            } else if (model != null) {
                // we need to redisplay the consent UI
                result.ViewModel = await BuildViewModelAsync(model.ReturnUrl, model);
            }

            return result;
        }

        public async Task<ConsentViewModel> BuildViewModelAsync(string returnUrl, ConsentInputModel model = null) {
            var request = await _interaction.GetAuthorizationContextAsync(returnUrl);
            if (request != null) {
                var client = await _clientStore.FindEnabledClientByIdAsync(request.Client.ClientId);
                if (client != null) {
                    var resources = await _resourceStore.FindEnabledResourcesByScopeAsync(request.ValidatedResources.RawScopeValues);
                    if (resources != null && (resources.IdentityResources.Any() || resources.ApiResources.Any())) {
                        return CreateConsentViewModel(model, returnUrl, client, resources);
                    } else {
                        _logger.LogError("No scopes matching: {0}", request.ValidatedResources.RawScopeValues.Aggregate((x, y) => x + ", " + y));
                    }
                } else {
                    _logger.LogError("Invalid client id: {0}", request.Client.ClientId);
                }
            } else {
                _logger.LogError("No consent request matching request: {0}", returnUrl);
            }

            return null;
        }

        private ConsentViewModel CreateConsentViewModel(
            ConsentInputModel model,
            string returnUrl,
            IdentityServer4.Models.Client client, Resources resources) {
            var vm = new ConsentViewModel {
                RememberConsent = model?.RememberConsent ?? true,
                ScopesConsented = model?.ScopesConsented ?? Enumerable.Empty<string>(),

                ReturnUrl = returnUrl,

                ClientName = client.ClientName ?? client.ClientId,
                ClientUrl = client.ClientUri,
                ClientLogoUrl = client.LogoUri,
                AllowRememberConsent = client.AllowRememberConsent
            };

            vm.IdentityScopes = resources.IdentityResources.Select(x => CreateScopeViewModel(x, vm.ScopesConsented.Contains(x.Name) || model == null)).ToArray();
            vm.ResourceScopes = resources.ApiScopes.Select(x => CreateScopeViewModel(x, vm.ScopesConsented.Contains(x.Name) || model == null)).ToArray();
            if (ConsentOptions.EnableOfflineAccess && resources.OfflineAccess) {
                vm.ResourceScopes = vm.ResourceScopes.Union(new ScopeViewModel[] {
                    GetOfflineAccessScope(vm.ScopesConsented.Contains(IdentityServer4.IdentityServerConstants.StandardScopes.OfflineAccess) || model == null)
                });
            }

            return vm;
        }

        public ScopeViewModel CreateScopeViewModel(IdentityResource identity, bool check) {
            return new ScopeViewModel {
                Value = identity.Name,
                DisplayName = identity.DisplayName,
                Description = identity.Description,
                Emphasize = identity.Emphasize,
                Required = identity.Required,
                Checked = check || identity.Required
            };
        }

        public ScopeViewModel CreateScopeViewModel(ApiScope scope, bool check) {
            return new ScopeViewModel {
                Value = scope.Name,
                DisplayName = scope.DisplayName,
                Description = scope.Description,
                Emphasize = scope.Emphasize,
                Required = scope.Required,
                Checked = check || scope.Required
            };
        }

        private ScopeViewModel GetOfflineAccessScope(bool check) {
            return new ScopeViewModel {
                Value = IdentityServer4.IdentityServerConstants.StandardScopes.OfflineAccess,
                DisplayName = ConsentOptions.OfflineAccessDisplayName,
                Description = ConsentOptions.OfflineAccessDescription,
                Emphasize = true,
                Checked = check
            };
        }
    }
}


