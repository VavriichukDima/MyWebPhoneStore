using System.Threading.Tasks;
using MyWebPhoneStoreApi.Models;

namespace MyWebPhoneStoreApi.Services.Abstractions
{
    public interface IPhoneService
    {
        Task<AddPhoneResponse> AddAsync(string name);
        Task<GetPhoneResponse?> GetAsync(int id);
    }
}