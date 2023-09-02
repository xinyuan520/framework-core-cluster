using Discus.SDK.Core.Configuration;
using Discus.SDK.Tools.HttpResult;
using Discus.Shared.Webapi.Controller;
using Discus.Shared.WebApi.Authorization;
using Discus.Shared.WebApi.Authorization.JwtBearer;
using Discus.User.Application.Contracts.Dtos;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;

namespace Discus.User.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JwtController : BasicController
    {
        private readonly IJwtService _jwtService;

        public JwtController(IJwtService jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpPost("Login")]
        public async Task<ApiResult> Login(LoginRequestDto request)
        {
            return await _jwtService.Login(request);
          
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetById"), CustomerAuthorize(AuthCode= "")]
        public async Task<UserInfoDto> GetById()
        {
            AutoInfoModel autoInfoModel = this.GetAutoInfoModel();
            return await _jwtService.GetById(autoInfoModel.Id);
        }


    }
}
