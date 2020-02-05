using HarrisPharmacy.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarrisPharmacy.Data.Entities.Fido;
using Fido2NetLib;

namespace HarrisPharmacy.Data.Interfaces
{
    /// <summary>
    /// The interface for the service class for the Fido Biometrics
    /// </summary>
    public interface IFidoService
    {
        /// <summary>
        /// Get the credentials for a given username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<List<FidoStoredCredential>> GetCredentialsByUsername(string username);
        /// <summary>
        /// Removes Fido credentials for a given username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Task RemoveCredentialsByUsername(string username);
        /// <summary>
        /// Gets a Fido credential by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<FidoStoredCredential> GetCredentialById(byte[] id);
        /// <summary>
        /// Gets Fido Credentials from user handle
        /// </summary>
        /// <param name="userHandle"></param>
        /// <returns></returns>
        Task<List<FidoStoredCredential>> GetCredentialsByUserHandleAsync(byte[] userHandle);
        /// <summary>
        /// Update counter
        /// </summary>
        /// <param name="credentialId"></param>
        /// <param name="counter"></param>
        /// <returns></returns>
        Task UpdateCounter(byte[] credentialId, uint counter);
        /// <summary>
        /// Add Fido credential to a user
        /// </summary>
        /// <param name="user"></param>
        /// <param name="credential"></param>
        /// <returns></returns>
        Task AddCredentialToUser(Fido2User user, FidoStoredCredential credential);
        /// <summary>
        /// Get users by a credential Id
        /// </summary>
        /// <param name="credentialId"></param>
        /// <returns></returns>
        Task<List<Fido2User>> GetUsersByCredentialIdAsync(byte[] credentialId);
    }
}
