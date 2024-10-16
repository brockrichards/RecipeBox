// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System.Collections.Generic;
using System.Linq;

namespace IdentityServer.WebApi.Controllers.Account {
    public class LoginViewModel : LoginInputModel {
        public bool AllowRememberLogin { get; set; }
        public bool EnableLocalLogin { get; set; }
        public string ForgotPasswordAddress { get; set; }
        public string AuthenticatorUri { get; set; } = string.Empty;
        public IEnumerable<ExternalProvider> ExternalProviders { get; set; }
        public IEnumerable<ExternalProvider> VisibleExternalProviders => ExternalProviders.Where(x => !string.IsNullOrWhiteSpace(x.DisplayName));
        public bool IsExternalLoginOnly => !EnableLocalLogin && ExternalProviders?.Count() == 1;
        public string ExternalLoginScheme => ExternalProviders?.SingleOrDefault()?.AuthenticationScheme;
    }
}

