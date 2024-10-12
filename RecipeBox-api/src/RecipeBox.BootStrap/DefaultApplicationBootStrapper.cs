using Cortside.Common.BootStrap;
using RecipeBox.BootStrap.Installer;

namespace RecipeBox.BootStrap {
    public class DefaultApplicationBootStrapper : BootStrapper {
        public DefaultApplicationBootStrapper() {
            installers = [
                new RepositoryInstaller(),
                new DomainServiceInstaller(),
                new DistributedLockInstaller(),
                new RestApiClientInstaller(),
                new FacadeInstaller()
            ];
        }
    }
}

