using System.Collections.Generic;

namespace IdentityServer.WebApi.Models.Input {
    public class UpdateClientClaimsModel {

        public List<UserClaimModel> Claims { get; set; }
    }
}

