using System.Threading.Tasks;
using PhoneApi.Data.Cache;
using PhoneApi.DataProviders.Abstractions;
using PhoneApi.Models;
using PhoneApi.Services.Abstractions;

namespace PhoneApi.Services
{
    public class PhoneService : IPhoneService
    {
        private readonly IPhoneProvider _phoneProvider;
        private readonly ICacheService<PhoneApiCacheEntity> _cacheService;

        public PhoneService(
            IPhoneProvider phoneProvider,
            ICacheService<PhoneApiCacheEntity> cacheService)
        {
            _phoneProvider = phoneProvider;
            _cacheService = cacheService;
        }

        public async Task<AddPhoneResponse> AddAsync(string name)
        {
            var result = await _phoneProvider.AddAsync(name);

            await _cacheService.AddOrUpdateAsync(new PhoneApiCacheEntity() { Id = result.Id, Name = name }, "userName");

            return new AddPhoneResponse() { Id = result.Id };
        }

        public async Task<GetPhoneResponse?> GetAsync(int id)
        {
            var cache = await _cacheService.GetAsync(id, "userName");

            return cache != null ? new GetPhoneResponse() { Id = cache.Id, Name = cache.Name } : null;
        }
    }
}