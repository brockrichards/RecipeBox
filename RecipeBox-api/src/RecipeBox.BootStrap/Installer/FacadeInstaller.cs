using Cortside.Common.BootStrap;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RecipeBox.Facade;
using RecipeBox.Facade.Mappers;

namespace RecipeBox.BootStrap.Installer {
    public class FacadeInstaller : IInstaller {
        public void Install(IServiceCollection services, IConfiguration configuration) {
            services.AddScopedInterfacesBySuffix<RecipeFacade>("Facade");
            services.AddScopedInterfacesBySuffix<IngredientFacade>("Facade");
            services.AddScopedInterfacesBySuffix<TagFacade>("Facade");
            services.AddScopedInterfacesBySuffix<UnitFacade>("Facade");

            services.AddSingletonClassesBySuffix<RecipeMapper>("Mapper");
            services.AddSingletonClassesBySuffix<RecipeIngredientMapper>("Mapper");
            services.AddSingletonClassesBySuffix<RecipeTagMapper>("Mapper");
            services.AddSingletonClassesBySuffix<SubjectMapper>("Mapper");
            services.AddSingletonClassesBySuffix<UnitMapper>("Mapper");
            services.AddSingletonClassesBySuffix<UserMapper>("Mapper");
        }
    }
}

