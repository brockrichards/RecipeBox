using System;
using System.Threading.Tasks;

namespace IdentityServer.WebApi.Controllers.ResetClientSecretController {
    public interface IResetClientSecretService {
        Task<SecretKeyModel> BuildSecretKeyViewModel(Guid requestId);
        VerifyIdentityModel BuildVerifyIdentityViewModel(string encodedRequestId);
        VerifyIdentityModel BuildVerifyIdentityViewModel(Guid requestId);
    }
}

