using System;
using System.Threading.Tasks;
using Warden.Common.Security;
using Warden.Common.Types;

namespace Warden.Common.ServiceClients
{
    public class OrganizationServiceClient : IOrganizationServiceClient
    {
        private readonly IServiceClient _serviceClient;
        private readonly ServiceSettings _settings;

        public OrganizationServiceClient(IServiceClient serviceClient, ServiceSettings settings)
        {
            _serviceClient = serviceClient;
            _settings = settings;
            _serviceClient.SetSettings(settings);
        }

        public async Task<Maybe<dynamic>> GetAsync(string userId, Guid organizationId)
            => await GetAsync<dynamic>(userId, organizationId);

        public async Task<Maybe<T>> GetAsync<T>(string userId, Guid organizationId) where T : class
            => await _serviceClient.GetAsync<T>(_settings.Url, $"/organizations/{organizationId}?userId={userId}");
    }
}