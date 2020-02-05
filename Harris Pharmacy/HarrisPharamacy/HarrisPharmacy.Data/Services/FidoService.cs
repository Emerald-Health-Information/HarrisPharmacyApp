using HarrisPharmacy.Data;
using Fido2NetLib;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarrisPharmacy.Data.Interfaces;
using HarrisPharmacy.Data.Entities.Fido;

namespace HarrisPharmacy.Data.Services
{
    class FidoService : IFidoService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly AuthDbContext _authDbContext;

        public FidoService(ApplicationDbContext applicationDbContext, AuthDbContext authDbContext)
        {
            _applicationDbContext = applicationDbContext;
            _authDbContext = authDbContext;
        }

        public async Task<List<FidoStoredCredential>> GetCredentialsByUsername(string username)
        {
            return await _authDbContext.FidoStoredCredential.Where(c => c.Username == username).ToListAsync();
        }

        public async Task RemoveCredentialsByUsername(string username)
        {
            var item = await _authDbContext.FidoStoredCredential.Where(c => c.Username == username).FirstOrDefaultAsync();
            if (item != null)
            {
                _authDbContext.FidoStoredCredential.Remove(item);
                await _authDbContext.SaveChangesAsync();
            }
        }

        public async Task<FidoStoredCredential> GetCredentialById(byte[] id)
        {
            var credentialIdString = Base64Url.Encode(id);
            //byte[] credentialIdStringByte = Base64Url.Decode(credentialIdString);

            var cred = await _authDbContext.FidoStoredCredential
                .Where(c => c.DescriptorJson.Contains(credentialIdString)).FirstOrDefaultAsync();

            return cred;
        }

        public Task<List<FidoStoredCredential>> GetCredentialsByUserHandleAsync(byte[] userHandle)
        {
            return Task.FromResult(_authDbContext.FidoStoredCredential.Where(c => c.UserHandle.SequenceEqual(userHandle)).ToList());
        }

        public async Task UpdateCounter(byte[] credentialId, uint counter)
        {
            var credentialIdString = Base64Url.Encode(credentialId);
            //byte[] credentialIdStringByte = Base64Url.Decode(credentialIdString);

            var cred = await _authDbContext.FidoStoredCredential
                .Where(c => c.DescriptorJson.Contains(credentialIdString)).FirstOrDefaultAsync();

            cred.SignatureCounter = counter;
            await _authDbContext.SaveChangesAsync();
        }

        public async Task AddCredentialToUser(Fido2User user, FidoStoredCredential credential)
        {
            credential.UserId = user.Id;
            _authDbContext.FidoStoredCredential.Add(credential);
            await _authDbContext.SaveChangesAsync();
        }

        public async Task<List<Fido2User>> GetUsersByCredentialIdAsync(byte[] credentialId)
        {
            var credentialIdString = Base64Url.Encode(credentialId);
            //byte[] credentialIdStringByte = Base64Url.Decode(credentialIdString);

            var cred = await _authDbContext.FidoStoredCredential
                .Where(c => c.DescriptorJson.Contains(credentialIdString)).FirstOrDefaultAsync();

            if (cred == null)
            {
                return new List<Fido2User>();
            }

            return await _authDbContext.Users
                    .Where(u => Encoding.UTF8.GetBytes(u.UserName)
                    .SequenceEqual(cred.UserId))
                    .Select(u => new Fido2User
                    {
                        DisplayName = u.UserName,
                        Name = u.UserName,
                        Id = Encoding.UTF8.GetBytes(u.UserName) // byte representation of userID is required
                    }).ToListAsync();
        }

    }
}
