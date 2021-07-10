using System;
using StackExchange.Redis;

namespace MyWebPhoneStoreApi.Services.Abstractions
{
    public interface IRedisCacheConnectionService
    {
        public ConnectionMultiplexer Connection { get; }
    }
}