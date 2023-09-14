using Discus.User.Application.Contracts.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Discus.User.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CacheController : ControllerBase
    {
        private readonly IRedisClient _redisClient;

        public CacheController(IRedisClient redisClient)
        {
            _redisClient = redisClient;
        }

        /// <summary>
        ///  设置Redis的值
        /// </summary>
        /// <returns></returns>
        [HttpPost("RedisStringSetAsync")]
        public async Task<bool> RedisStringSetAsync(RedisDto dto)
        {
            return await _redisClient.StringSetAsync(dto.RedisKey, dto.RedisValue, dto.Expired);
        }

        /// <summary>
        /// 获取Redis的值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpGet("RedisStringGetAsync")]
        public async Task<string> RedisStringGetAsync(string key)
        {
            return await _redisClient.StringGetAsync(key);
        }
    }
}
