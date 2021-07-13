using System.Threading.Tasks;
using PhoneApi.Data;

namespace PhoneApi.DataProviders.Abstractions
{
    public interface IPhoneProvider
    {
        Task<PhoneApiEntity> AddAsync(string name);
    }
}