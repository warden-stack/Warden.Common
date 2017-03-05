using System;
using System.Threading.Tasks;
using Warden.Common.Types;
using Warden.Common.ServiceClients.Queries;

namespace Warden.Common.ServiceClients
{
    public interface IUserServiceClient
    {
        Task<Maybe<dynamic>> GetAsync(string userId);
        Task<Maybe<T>> GetAsync<T>(string  userId) where  T : class;
        Task<Maybe<dynamic>> GetByNameAsync(string name);
        Task<Maybe<T>> GetByNameAsync<T>(string name) where  T : class;
        Task<Maybe<dynamic>> GetSessionAsync(Guid id);
        Task<Maybe<T>> GetSessionAsync<T>(Guid id) where  T : class;
        Task<Maybe<dynamic>> GetApiKeyAsync(string userId, string name);
        Task<Maybe<T>> GetApiKeyAsync<T>(string userId, string name) where  T : class;
        Task<Maybe<PagedResult<dynamic>>> BrowseApiKeysAsync(BrowseApiKeys query);
        Task<Maybe<PagedResult<T>>> BrowseApiKeysAsync<T>(BrowseApiKeys query) where  T : class;
        Task<Maybe<dynamic>> IsAvailableAsync(string name); 
        Task<Maybe<T>> IsAvailableAsync<T>(string name) where  T : class;
    }
}