using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NLog;
using StackExchange.Redis;
using Warden.Common.Extensions;
using Warden.Common.Types;

namespace Warden.Common.Caching.Redis
{
    public class RedisCache : ICache
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly IDatabase _database;
        private readonly RedisSettings _settings;

        public RedisCache(IDatabase database, RedisSettings settings)
        {
            _database = database;
            _settings = settings;
            Logger.Debug($"Initialized Redis service for database {settings.Database}, enabled: '{settings.Enabled}'.");
        }

        public async Task<Maybe<T>> GetAsync<T>(string key) where T : class
        {
            if (!_settings.Enabled)
                return default(T);

            var fixedKey = key.ToLowerInvariant();
            if (_settings.UseLogger)
            {
                Logger.Debug($"Fetching entry for key: '{fixedKey}'.");
            }
            var value = Deserialize<T>(await _database.StringGetAsync(fixedKey));
            if (value == null)
            {
                Logger.Debug($"Entry for key: '{fixedKey}' is null.");
            }

            return value;
        }

        public async Task AddAsync(string key, object value, TimeSpan? expiry = null)
        {
            if(!_settings.Enabled)
                return;

            if (_settings.UseLogger)
            {
                Logger.Debug($"Saving entry for key: '{key}' with expiry: {expiry}.");
            }
            var fixedKey = key.ToLowerInvariant();
            var obj = Serialize(value);
            await _database.StringSetAsync(fixedKey, obj, expiry);
            if (_settings.UseLogger)
            {
                Logger.Debug($"Entry for key: '{key}' with expiry: {expiry} was saved.");
            }
        }

        public async Task DeleteAsync(string key)
        {
            if (!_settings.Enabled)
                return;

            if (_settings.UseLogger)
            {
                Logger.Debug($"Deleting data for key: '{key}'.");
            }
            var fixedKey = key.ToLowerInvariant();
            await AddAsync(fixedKey, null, TimeSpan.FromMilliseconds(1));
            if (_settings.UseLogger)
            {
                Logger.Debug($"Entry for key: '{key}' was deleted.");
            }
        }

        private static string Serialize<T>(T value) => JsonConvert.SerializeObject(value);

        private static T Deserialize<T>(string serializedObject)
            => serializedObject.Empty() ? default(T) : JsonConvert.DeserializeObject<T>(serializedObject);
    }
}