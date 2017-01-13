namespace Warden.Common.Caching.Redis
{
    public class RedisSettings
    {
        public string ConnectionString { get; set; }
        public int Database { get; set; }
        public bool Enabled { get; set; }
        public bool UseLogger { get; set; }
    }
}