using System;

namespace PhoneApi.Configuration
{
    public class RedisConfig
    {
        public string Host { get; set; } = null!;

        public TimeSpan CacheTimeout { get; set; }
    }
}