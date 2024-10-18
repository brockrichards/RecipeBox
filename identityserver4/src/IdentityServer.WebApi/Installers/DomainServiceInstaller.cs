using System.IO.Abstractions;
using IdentityServer.WebApi.Assemblers;
using IdentityServer.WebApi.Assemblers.Implementors;
using IdentityServer.WebApi.Controllers.Account;
using IdentityServer.WebApi.Controllers.ResetClientSecretController;
using IdentityServer.WebApi.Helpers;
using IdentityServer.WebApi.Models;
using IdentityServer.WebApi.Services;
using IdentityServer.WebApi.Services.ExtensionGrantValidators;
using Cortside.Common.BootStrap;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityServer.WebApi.Installers {
    public class DomainServiceInstaller : IInstaller {
        public void Install(IServiceCollection services, IConfiguration configuration) {
            services.AddHttpClient<IGoogleRecaptchaV3Service, GoogleRecaptchaV3Service>();

            var build = configuration.GetSection("Build").Get<Build>();
            services.AddSingleton(build == null ? new Build() : build);

            services.AddSingleton<IHashProvider, HashProvider>();
            services.AddSingleton<IAuthenticator, Authenticator>();

            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IScopeService, ScopeService>();
            services.AddScoped<IClientSecretService, ClientSecretService>();
            services.AddScoped<IResetClientSecretService, ResetClientSecretService>();
            services.AddScoped<IUserModelAssembler, UserModelAssembler>();
            services.AddScoped<IFileSystem, FileSystem>();
            services.AddScoped<IPhoneNumberHelper, PhoneNumberHelper>();
            services.AddScoped<IAccountService, AccountService>();

            services.AddScoped<IUserService, UserService>();
        }
    }
}

