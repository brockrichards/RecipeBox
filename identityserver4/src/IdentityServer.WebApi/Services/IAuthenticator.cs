using System.Threading.Tasks;
using IdentityServer.WebApi.Models;

namespace IdentityServer.WebApi.Services {
    public interface IAuthenticator {
        Task<AuthenticationResponse> AuthenticateAsync(LoginInfo info);
    }
}

