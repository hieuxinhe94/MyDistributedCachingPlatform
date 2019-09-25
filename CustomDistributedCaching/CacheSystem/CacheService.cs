using CachingDistributedSystem.Services.Model;
using System.Threading.Tasks;

namespace CachingDistributedSystem
{
    public class CacheService : ICacheService
    {
        private ICacheRepository<string> _cacheRepository;

        public CacheService(ICacheRepository<string> cacheRepository)
        {
            _cacheRepository = cacheRepository;

            // Test
            _cacheRepository.Set("TEST_KEY_123", "Test OK");
        }

        public async Task<object> GetAsync(RequestModel requestModel)
        {
            if (requestModel.Type == RequestType.GET)
            {
              return  _cacheRepository.Get(requestModel.Key);
            }

            return "Not valid request type";
        }

        public Task<object> Handler(RequestModel requestModel)
        {
            switch (requestModel.Type)
            {
                case RequestType.GET:

                    return GetAsync(requestModel);
                case RequestType.SET:

                    return Set(requestModel);
                case RequestType.REMOVE:

                    return Remove(requestModel);
                case RequestType.REFRESH:
                default:
                    break;
            }

            return null;
        }

        public async Task<object> Remove(RequestModel requestModel)
        {
            if (requestModel.Type == RequestType.REMOVE)
            {
                _cacheRepository.Remove(requestModel.Key);
            }

            return "Not valid request type";
        }

        public async Task<object> Set(RequestModel requestModel)
        {
            if (requestModel.Type == RequestType.SET)
            {
                _cacheRepository.Set(requestModel.Key, requestModel.Value);
            }

            return "Not valid request type";
        }
    }
}
