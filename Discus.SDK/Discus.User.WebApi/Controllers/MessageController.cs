using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Discus.User.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        /// <summary>
        /// 发布消息测试
        /// </summary>
        /// <returns></returns>
        [HttpGet("Publish")]
        public async Task Publish()
        {
            await _messageService.Publish();
        }
    }
}
