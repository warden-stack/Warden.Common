using System;
using System.Threading.Tasks;
using NLog;
using Warden.Common.Security;
using Warden.Common.Types;

namespace Warden.Common.ServiceClients
{
    public class OperationServiceClient : IOperationServiceClient
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly IServiceClient _serviceClient;
        private readonly ServiceSettings _settings;

        public OperationServiceClient(IServiceClient serviceClient, ServiceSettings settings)
        {
            _serviceClient = serviceClient;
            _settings = settings;
            _serviceClient.SetSettings(settings);
        }

        public async Task<Maybe<dynamic>> GetAsync(Guid requestId)
            => await GetAsync<dynamic>(requestId);

        public async Task<Maybe<T>> GetAsync<T>(Guid requestId) where T : class
            => await _serviceClient.GetAsync<T>(_settings.Url, $"/operations/{requestId}");
    }
}