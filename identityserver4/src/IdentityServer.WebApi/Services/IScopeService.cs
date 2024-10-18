using System.Collections.Generic;

namespace IdentityServer.WebApi.Services {
    public interface IScopeService {

        List<string> GetAll();
    }
}

