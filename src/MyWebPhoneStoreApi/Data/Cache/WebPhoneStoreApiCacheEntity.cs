using System;

namespace MyWebPhoneStoreApi.Data.Cache
{
    public class WebPhoneStoreApiCacheEntity : ICacheEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}