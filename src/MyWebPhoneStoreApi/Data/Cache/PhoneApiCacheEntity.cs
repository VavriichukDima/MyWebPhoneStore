using System;

namespace PhoneApi.Data.Cache
{
    public class PhoneApiCacheEntity : ICacheEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}