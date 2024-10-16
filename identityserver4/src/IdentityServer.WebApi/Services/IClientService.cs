using System.Threading.Tasks;
using IdentityServer.WebApi.Data;
using IdentityServer.WebApi.Models;
using IdentityServer.WebApi.Models.Input;

namespace IdentityServer.WebApi.Services {
    public interface IClientService {
        /// <summary>
        /// Updates the settings pertaining to the client ID,
        /// applying to all affiliated entities in their entirety.
        /// </summary>
        /// <param name="clientId">Client ID, a string name that corresponds with an auth client.</param>
        /// <param name="updateClientRequest">The request object containing settings to update.</param>
        /// <returns>Client that was inserted or updated, containing all child entities.</returns>
        Task<Client> UpdateClient(string clientId, UpdateClientRequest updateClientRequest);
        Task<Client> UpdateClient(int id, UpdateClientModel request);

        /// <summary>
        /// Updates a client's scopes given a user client scope update request
        /// </summary>
        /// <param name="id">Client Id</param>
        /// <param name="model">Model containing the scopes</param>
        /// <returns></returns>
        Task<UpdateClientScopesModel> UpdateClientScopes(int id, UpdateClientScopesModel model);

        /// <summary>
        /// Updates a client's claims given a user client claims update request
        /// </summary>
        /// <param name="id">Client Id</param>
        /// <param name="model">Model containing the claims</param>
        /// <returns></returns>
        Task<UpdateClientClaimsModel> UpdateClientClaims(int id, UpdateClientClaimsModel model);

        /// <summary>
        /// Deletes the client ID and all affiliated settings.
        /// </summary>
        /// <param name="clientId">Client ID, a string name that corresponds with an auth client.</param>
        /// <returns></returns>
        Task DeleteClient(string clientId);

        /// <summary>
        /// Retrieves client info by the client sub from the claims table
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        Client GetClient(string clientSubjectId);
        Client GetClient(int id);

        /// <summary>
        /// Creates a new client
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<Client> CreateClient(CreateClientModel request);
    }
}

