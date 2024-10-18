using IdentityServer.WebApi.Data;

namespace IdentityServer.WebApi.Models {
    public class AuthenticationResponse {
        public User User { get; set; }
        public string Error { get; set; }
    }
}

