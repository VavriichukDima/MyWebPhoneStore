using PhoneApi.Configuration;

namespace PhoneApi.Configuration
{
    public class Config
    {
        public PhoneApiConfig PhoneApi { get; set; } = null!;
        public RedisConfig Redis { get; set; } = null!;
    }
}