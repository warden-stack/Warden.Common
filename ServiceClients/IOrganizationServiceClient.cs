using System;
using System.Threading.Tasks;
using Warden.Common.Types;

namespace Warden.Common.ServiceClients
{
    public interface IOrganizationServiceClient
    {
        Task<Maybe<dynamic>> GetAsync(string userId, Guid organizationId);  
        Task<Maybe<T>> GetAsync<T>(string userId, Guid organizationId) where T : class;             
    }
}