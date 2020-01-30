using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
/*
 * 以上为系统自动引用；
 * 以下为开发者引用；
 * 2020.01.01, 22:22
 */
using LandSpark_Query_API.Services;
using Microsoft.Extensions.Logging;     //用于生成日志。

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LandSpark_Query_API.Controllers
{
    public class StatusController<T> : ControllerBase
    {
        private readonly ILogger<T> _logger;

        public StatusController(ILogger<T> logger)
        {
            this._logger = logger;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            //return View();
            return NotFound();
        }


        /// <summary>
        /// 根据ResponseWithStatusCode类返回值，加工为IActionResult结果。
        /// </summary>
        /// <param name="response">ResponseWithStatusCode类返回值。</param>
        /// <returns></returns>
        public IActionResult HandleResponse(ResponseWithStatusCode response)
        {
            switch(response.StatusCode)
            {
                case 200:       //成功。
                    return Ok(response.Data);

                case 401:       //无权限。
                    return Unauthorized();

                case 409:       //冲突。
                    return Conflict(response.Data);

                default:
                    return NotFound();
            }
        }

        /// <summary>
        /// 记录日志信息（不记录返回信息）。
        /// </summary>
        /// <param name="functionName">功能名称</param>
        /// <param name="parameterInput">输入参数值</param>
        /// <param name="statusCode">状态码</param>
        public void CallLog(string functionName, string parameterInput, int statusCode)
        {
            string infoToLog = $"查询记录：{functionName}, {parameterInput}, StatusCode: {statusCode}";
            _logger.LogInformation(infoToLog);
        }

        /// <summary>
        /// 记录日志信息（记录返回信息）。
        /// </summary>
        /// <param name="functionName">功能名称</param>
        /// <param name="parameterInput">输入参数值</param>
        /// <param name="statusCode">状态码</param>
        /// <param name="data">查询返回的信息（一般是异常信息）</param>
        public void CallLog(string functionName, string parameterInput, int statusCode, object data)
        {
            string infoToLog = $"查询记录：{functionName}, {parameterInput}, StatusCode: {statusCode}, ResponseInformation: {data}";
            _logger.LogInformation(infoToLog);
        }

        /// <summary>
        /// 析构StatusController状态控制器对象。
        /// </summary>
        ~StatusController() { }
    }
}
