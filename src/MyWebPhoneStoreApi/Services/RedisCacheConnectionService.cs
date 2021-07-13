using System;
using PhoneApi.Configuration;
using PhoneApi.Services.Abstractions;
using Microsoft.Extensions.Options;
using StackExchange.Redis;

namespace PhoneApi.Services
{
    public class RedisCacheConnectionService : IRedisCacheConnectionService, IDisposable
    {
        private readonly Lazy<ConnectionMultiplexer> _connectionLazy;
        private bool _disposed;

        public RedisCacheConnectionService(
            IOptions<Config> config)
        {
            var redisConfigurationOptions = ConfigurationOptions.Parse(config.Value.Redis.Host);
            _connectionLazy =
                new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(redisConfigurationOptions));
        }

        public ConnectionMultiplexer Connection => _connectionLazy.Value;

        public void Dispose()
        {
            if (!_disposed)
            {
                Connection.Dispose();
                _disposed = true;
            }
        }
    }
}