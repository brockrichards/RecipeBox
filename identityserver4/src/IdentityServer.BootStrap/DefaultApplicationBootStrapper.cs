using System.Collections.Generic;
using Cortside.Common.BootStrap;

namespace IdentityServer.BootStrap {
    public class DefaultApplicationBootStrapper : BootStrapper {
        public DefaultApplicationBootStrapper() {
            installers = new List<IInstaller>();
        }
    }
}

