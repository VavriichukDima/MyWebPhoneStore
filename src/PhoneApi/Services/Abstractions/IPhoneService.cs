using System.Threading.Tasks;
using PhoneApi.Models;

namespace PhoneApi.Services.Abstractions
{
    public interface IPhoneService
    {
        Task<AddPhoneResponse> AddAsync(string name);
        Task<GetPhoneResponse?> GetAsync(int id);
    }
}