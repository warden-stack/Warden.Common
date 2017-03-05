using System;
using System.Threading.Tasks;
using NLog;
using Warden.Common.Security;
using Warden.Common.Types;
using Warden.Common.ServiceClients.Queries;

namespace Warden.Common.ServiceClients
{
    public class UserServiceClient : IUserServiceClient
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly IServiceClient _serviceClient;
        private readonly ServiceSettings _settings;

        public UserServiceClient(IServiceClient serviceClient, ServiceSettings settings)
        {
            _serviceClient = serviceClient;
            _settings = settings;
            _serviceClient.SetSettings(settings);
        }

        public async Task<Maybe<dynamic>> GetAsync(string userId)
            => await GetAsync<dynamic>(userId);

        public async Task<Maybe<T>> GetAsync<T>(string userId) where  T : class
            => await _serviceClient.GetAsync<T>(_settings.Url, $"users/{userId}");

        public async Task<Maybe<dynamic>> GetByNameAsync(string name)
            => await GetByNameAsync<dynamic>(name);

        public async Task<Maybe<T>> GetByNameAsync<T>(string name) where  T : class
            => await _serviceClient.GetAsync<T>(_settings.Url, $"users/{name}/account");

        public async Task<Maybe<dynamic>> GetSessionAsync(Guid id)
            => await GetSessionAsync<dynamic>(id);

        public async Task<Maybe<T>> GetSessionAsync<T>(Guid id) where  T : class
            => await _serviceClient.GetAsync<T>(_settings.Url, $"user-sessions/{id}");

        public async Task<Maybe<dynamic>> GetApiKeyAsync(string userId, string name) 
            => await GetApiKeyAsync<dynamic>(userId, name);

        public async Task<Maybe<T>> GetApiKeyAsync<T>(string userId, string name) where  T : class
            => await _serviceClient.GetAsync<T>(_settings.Url, $"users/{userId}/api-keys/{name}");

        public async Task<Maybe<PagedResult<dynamic>>> BrowseApiKeysAsync(BrowseApiKeys query)
            => await BrowseApiKeysAsync<dynamic>(query);

        public async Task<Maybe<PagedResult<T>>> BrowseApiKeysAsync<T>(BrowseApiKeys query) where  T : class
            => await _serviceClient.GetCollectionAsync<T>(_settings.Url, $"users/{query.UserId}/api-keys");

        public async Task<Maybe<dynamic>> IsAvailableAsync(string name)
            => await IsAvailableAsync<dynamic>(name);

        public async Task<Maybe<T>> IsAvailableAsync<T>(string name) where  T : class
             => await _serviceClient.GetAsync<T>(_settings.Url, $"usernames/{name}/available");
    }
}