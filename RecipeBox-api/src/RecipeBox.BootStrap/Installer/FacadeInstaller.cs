using Cortside.Common.BootStrap;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RecipeBox.Facade;
using RecipeBox.Facade.Mappers;

namespace RecipeBox.BootStrap.Installer {
    public class FacadeInstaller : IInstaller {
        public void Install(IServiceCollection services, IConfiguration configuration) {
            services.AddScopedInterfacesBySuffix<RecipeFacade>("Facade");
            services.AddSingletonClassesBySuffix<RecipeMapper>("Mapper");
        }
    }
}

