#pragma warning disable CS1591 // Missing XML comments

using Cortside.Common.BootStrap;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RecipeBox.WebApi.Mappers;

namespace RecipeBox.WebApi.Installers {
    public class ModelMapperInstaller : IInstaller {
        public void Install(IServiceCollection services, IConfiguration configuration) {
            services.AddSingletonClassesBySuffix<RecipeModelMapper>("Mapper");
            services.AddSingletonClassesBySuffix<IngredientModelMapper>("Mapper");
            services.AddSingletonClassesBySuffix<TagModelMapper>("Mapper");
            services.AddSingletonClassesBySuffix<UnitModelMapper>("Mapper");
        }
    }
}

