using System;
using System.Threading.Tasks;
using MyWebPhoneStoreApi.Data;
using MyWebPhoneStoreApi.DataProviders.Abstractions;

namespace BookApi.DataProviders
{
    public class MyWebPhoneStoreApiProvider : IMyWebPhoneStoreProvider
    {
        private readonly MyWebPhoneStoreApiDbContext _phonesDbContext;

        public MyWebPhoneStoreApiProvider(MyWebPhoneStoreApiDbContext booksDbContext)
        {
            _phonesDbContext = booksDbContext;
        }

        public async Task<MyWebPhoneStoreApiEntity> AddAsync(string name)
        {
            var result = await _phonesDbContext.Phones.AddAsync(new MyWebPhoneStoreApiEntity() { Name = name });
            await _phonesDbContext.SaveChangesAsync();

            return result.Entity;
        }
    }
}