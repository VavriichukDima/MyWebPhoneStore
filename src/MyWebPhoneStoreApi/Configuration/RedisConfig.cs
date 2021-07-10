using System;

namespace MyWebPhoneStoreApi.Configuration
{
    public class RedisConfig
    {
        public string Host { get; set; } = null!;

        public TimeSpan CacheTimeout { get; set; }
    }
}