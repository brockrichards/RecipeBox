using Cortside.Common.BootStrap;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RecipeBox.Data.Repositories;

namespace RecipeBox.BootStrap.Installer {
    public class RepositoryInstaller : IInstaller {
        public void Install(IServiceCollection services, IConfiguration configuration) {
            services.AddScopedInterfacesBySuffix<RecipeRepository>("Repository");
            services.AddScopedInterfacesBySuffix<IngredientRepository>("Repository");
            services.AddScopedInterfacesBySuffix<TagRepository>("Repository");
            services.AddScopedInterfacesBySuffix<UnitRepository>("Repository");
        }
    }
}

