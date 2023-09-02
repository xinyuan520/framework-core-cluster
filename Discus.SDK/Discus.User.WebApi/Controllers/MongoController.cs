using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Discus.User.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MongoController : ControllerBase
    {
        private readonly IMongoService _mongoService;

        public MongoController(IMongoService mongoService)
        {
            _mongoService = mongoService;
        }

        /// <summary>
        /// 获取一条记录
        /// </summary>
        [HttpGet("GetAsync")]
        public void GetAsync()
        {
            _mongoService.GetAsync();
        }
    }
}
