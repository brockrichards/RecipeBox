using System;

namespace IdentityServer.WebApi.Models.Output {
    public class ClientSecretRequestDecodedOutput {
        public Guid RequestId { get; set; }

        public string TokenHash { get; set; }
    }
}

