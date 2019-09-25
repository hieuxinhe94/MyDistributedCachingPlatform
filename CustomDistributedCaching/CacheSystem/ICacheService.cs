using CachingDistributedSystem.Services.Model;
using System.Threading.Tasks;

namespace CachingDistributedSystem
{
    public interface ICacheService
    {
        Task<object> Handler(RequestModel requestModel);

        Task<object> GetAsync(RequestModel requestModel);
        Task<object> Set(RequestModel requestModel);
        Task<object> Remove(RequestModel requestModel);
    }
}
