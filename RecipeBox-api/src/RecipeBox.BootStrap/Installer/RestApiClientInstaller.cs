using Cortside.AspNetCore.AccessControl;
using Cortside.Common.BootStrap;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RecipeBox.BootStrap.Installer {
    public class RestApiClientInstaller : IInstaller {
        /// <summary>
        /// Registers a RestApiClient with it's interface and configuration.  Configuration authentication
        /// is populated from IdentityServer section if not populated.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public void Install(IServiceCollection services, IConfiguration configuration) {
            // get common ids authorization and make sure the authorityUrl is set
            var idsConfig = configuration.GetSection("IdentityServer").Get<IdentityServerConfiguration>();
            idsConfig.Authentication.AuthorityUrl = idsConfig.Authority;
        }
    }
}

