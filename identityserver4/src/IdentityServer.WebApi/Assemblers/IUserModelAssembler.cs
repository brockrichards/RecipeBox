using IdentityServer.WebApi.Data;

namespace IdentityServer.WebApi.Assemblers {
    public interface IUserModelAssembler {
        Models.Output.UserOutputModel ToUserOutputModel(User user);
        Models.Output.UserOutputModel ToUserOutputModel(Client client);
    }
}

