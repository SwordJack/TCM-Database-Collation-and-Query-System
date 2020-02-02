using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
/*
 * 以上为系统自动引用；
 * 以下为开发者引用；
 * 2020.01.31, 11:44
 */
using LandSpark_Query_API.Areas.TCM.Services;       //用于提供数据库服务。
using LandSpark_Query_API.Areas.TCM.Dtos;           //用于调用数据传输对象。
using Microsoft.AspNetCore.Authentication;          //用于用户登录。
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.Extensions.Logging;                 //用于日志记录。

namespace LandSpark_Query_API.Areas.TCM.Controllers
{
    [Route("api/Traditional-Chinese-Medicine/[controller]")]
    //[ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            this._logger = logger;
        }

        /// <summary>
        /// 未登录时的返回页。
        /// </summary>
        /// <returns></returns>
        //GET api/Traditional-Chinese-Medicine/Account/
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("因你未登录，访问被拒止，故显示此消息。");
        }

        /// <summary>
        /// 不符合权限策略时的返回页。
        /// </summary>
        /// <returns></returns>
        //GET api/Traditional-Chinese-Medicine/Account/Forbid/
        [HttpGet("Forbid")]
        public IActionResult ForbidRequset()
        {
            return Ok("因当前登录账号权限受限，访问被拒止，故显示此消息。");
        }

        /// <summary>
        /// 接收HttpPost登录请求。
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        // POST api/Traditional-Chinese-Medicine/Account/Login/
        [HttpPost("Login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            if (username is null || password is null)   //对于空用户名或者空密码进行拒绝。
            {
                return Forbid();
            }

            Account account = new Account(username, password);

            var response = LandsparkTCMDataService.ExecuteSelectScalarQuery(account.Username, account.PwdEncrypted);
            
            StatusController<AccountController> statusController = new StatusController<AccountController>(_logger);
            if (response.StatusCode == 200)     //状态码为200，说明正确地与数据库进行了交互。
            {
                statusController.CallLog(username, password);
            }
            else    //其它状态码，说明与数据库的交互出现异常，不宜继续进行之后的操作。
            {
                statusController.CallLog("Login", username, response.StatusCode, response.Data);
                return statusController.HandleResponse(response);
            }

            account.Authorized = (int)response.Data;

            if (account.Authorized == 1)
            {
                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim("password", password)
                };

                var userPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims, "Member"));
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    userPrincipal,
                    new AuthenticationProperties
                    {
                        ExpiresUtc = DateTime.UtcNow.AddMinutes(20),
                        IsPersistent = false,
                        AllowRefresh = false
                    }).ConfigureAwait(false);

            }
            return Ok(account.GetAccountStatus());
            //return Ok("登录失败");
        }

        /// <summary>
        /// 接收HttpPost进行登出操作。
        /// </summary>
        /// <returns></returns>
        // POST api/Traditional-Chinese-Medicine/Account/Logout/
        [Authorize]
        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            Account account = new Account(this.User.Identity.Name);
            await HttpContext.SignOutAsync().ConfigureAwait(false);
            return Ok(account.GetAccountStatus());
        }

        /**以上代码起实际作用。**/

        //

        //// GET: api/Account
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Account/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Account
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/Account/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

        //
    }
}
