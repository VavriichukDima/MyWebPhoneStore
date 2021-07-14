using System;
using StackExchange.Redis;

namespace PhoneApi.Services.Abstractions
{
    public interface IRedisCacheConnectionService
    {
        public ConnectionMultiplexer Connection { get; }
    }
}