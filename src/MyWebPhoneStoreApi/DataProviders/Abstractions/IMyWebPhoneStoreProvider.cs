using System.Threading.Tasks;
using MyWebPhoneStoreApi.Data;

namespace MyWebPhoneStoreApi.DataProviders.Abstractions
{
    public interface IMyWebPhoneStoreProvider
    {
        Task<MyWebPhoneStoreApiEntity> AddAsync(string name);
    }
}