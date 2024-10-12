#pragma warning disable CS1591 // Missing XML comments

using Cortside.Common.BootStrap;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RecipeBox.WebApi.Installers {
    public class ModelMapperInstaller : IInstaller {
        public void Install(IServiceCollection services, IConfiguration configuration) {
            //services.AddSingletonClassesBySuffix<RecipeModelMapper>("Mapper");
        }
    }
}

