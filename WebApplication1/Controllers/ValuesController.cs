using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Dynamic;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IDistributedCache _cache;

        public ValuesController(IDistributedCache cache)
        {
            _cache = cache;
        }

        // GET api/values
        [HttpGet]
        public ActionResult Get()
        {
            byte[] value = _cache.Get("TEST_KEY_123");

            if (value != null)
            {
                return Ok(System.Text.Encoding.ASCII.GetString(value));
            }

            return NotFound("Not found.");
        }

        [HttpGet("{key}")]
        public ActionResult Get(string key)
        {
            byte[] value = _cache.Get(key);

            if (value != null)
            {
                return Ok(System.Text.Encoding.ASCII.GetString(value));
            }

            return NotFound("Not found.");
        }

        [HttpPost]
        public ActionResult Post([FromBody]PostModel model)
        {
            // I do not handled byte array for now.
            model.Key = model.Key.Replace(" ", "");
            model.Value = model.Value.Replace(" ", "");

            // This function using to test (data of cache should be from db)
            _cache.Set(model.Key, System.Text.Encoding.ASCII.GetBytes(model.Value));

            return Ok("Processed");
        }
    }

    public class PostModel
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
