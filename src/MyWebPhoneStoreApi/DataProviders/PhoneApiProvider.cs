using System;
using System.Threading.Tasks;
using PhoneApi.Data;
using PhoneApi.DataProviders.Abstractions;

namespace PhoneApi.DataProviders
{
    public class PhoneApiProvider : IPhoneProvider
    {
        private readonly PhoneApiDbContext _phonesDbContext;

        public PhoneApiProvider(PhoneApiDbContext booksDbContext)
        {
            _phonesDbContext = booksDbContext;
        }

        public async Task<PhoneApiEntity> AddAsync(string name)
        {
            var result = await _phonesDbContext.Phones.AddAsync(new PhoneApiEntity() { Name = name });
            await _phonesDbContext.SaveChangesAsync();

            return result.Entity;
        }
    }
}