using System.Threading.Tasks;
using MyWebPhoneStoreApi.Data.Cache;
using MyWebPhoneStoreApi.DataProviders.Abstractions;
using MyWebPhoneStoreApi.Models;
using MyWebPhoneStoreApi.Services.Abstractions;

namespace MyWebPhoneStoreApi.Services
{
    public class PhoneService : IPhoneService
    {
        private readonly IMyWebPhoneStoreProvider _phoneProvider;
        private readonly ICacheService<WebPhoneStoreApiCacheEntity> _cacheService;

        public PhoneService(
            IMyWebPhoneStoreProvider phoneProvider,
            ICacheService<WebPhoneStoreApiCacheEntity> cacheService)
        {
            _phoneProvider = phoneProvider;
            _cacheService = cacheService;
        }

        public async Task<AddPhoneResponse> AddAsync(string name)
        {
            var result = await _phoneProvider.AddAsync(name);

            await _cacheService.AddOrUpdateAsync(new WebPhoneStoreApiCacheEntity() { Id = result.Id, Name = name }, "userName");

            return new AddPhoneResponse() { Id = result.Id };
        }

        public async Task<GetPhoneResponse?> GetAsync(int id)
        {
            var cache = await _cacheService.GetAsync(id, "userName");

            return cache != null ? new GetPhoneResponse() { Id = cache.Id, Name = cache.Name } : null;
        }
    }
}