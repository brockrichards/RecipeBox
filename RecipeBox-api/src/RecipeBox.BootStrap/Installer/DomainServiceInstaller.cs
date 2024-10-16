using Cortside.Common.BootStrap;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RecipeBox.DomainService;

namespace RecipeBox.BootStrap.Installer {
    public class DomainServiceInstaller : IInstaller {
        public void Install(IServiceCollection services, IConfiguration configuration) {
            services.AddScopedInterfacesBySuffix<RecipeService>("Service");
            services.AddScopedInterfacesBySuffix<UserService>("Service");
            services.AddScopedInterfacesBySuffix<TagService>("Service");
            services.AddScopedInterfacesBySuffix<IngredientService>("Service");
            services.AddScopedInterfacesBySuffix<UnitService>("Service");
        }
    }
}

