using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
/*
 * 以上为系统自动引用；
 * 以下为开发者引用；
 * 2019.12.30, 22:26
 */
//using Newtonsoft.Json;                  //控制器返回Json格式数据。
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;     //用于生成日志。
using LandSpark_Query_API.Areas.TCM.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LandSpark_Query_API.Areas.TCM.Controllers
{
    [Route("api/Traditional-Chinese-Medicine/[controller]")]    //设置路径。
    public class PrescriptionController : Controller
    {
        private readonly ILogger<PrescriptionController> _logger;   //使用ILogger接口的实例，用于记录访问信息。

        public PrescriptionController(ILogger<PrescriptionController> logger)
        {
            _logger = logger;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            //return View();
            return Ok("方剂查询");
        }

        /// <summary>
        /// 方剂检索，暂时仅设计按名称查询之功能。
        /// </summary>
        /// <returns></returns>
        [Route("search")]
        public IActionResult PrescriptionSearch()
        {
            var statusController = new StatusController<PrescriptionController>(_logger);       //建立StatusController的实例。

            IQueryCollection parameters = HttpContext.Request.Query;
            string name = parameters["name"];
            if (name.Length == 0)
            {
                statusController.CallLog("PrescriptionSearch", null, 301); //记录日志。
                return Redirect("../prescription/");  //重定向至prescription目录。
            }
            else
            {
                string queryText = $"EXEC [Get_Prescription_By_Name] @input = N'{name.Replace("\'", "")}';";    //将过滤引号后的参数赋给查询语句。
                var response = LandsparkTCMDataService.ExecuteSelectDatasetQuery(queryText);

                if (response.StatusCode != 401)
                {
                    statusController.CallLog("PrescriptionSearch", name, response.StatusCode); //记录日志。
                }
                else
                {
                    statusController.CallLog("PrescriptionSearch", name, response.StatusCode, response.Data);   //报回401错误，则记录错误信息。
                }

                return statusController.HandleResponse(response);
            }
        }

        /// <summary>
        /// 获取方剂的详细信息。
        /// </summary>
        /// <param name="prescriptionCode">方剂代码</param>
        /// <returns></returns>
        [Route("{prescriptionCode}")]
        public IActionResult PrescriptionCode(string prescriptionCode)
        {
            var statusController = new StatusController<PrescriptionController>(_logger);

            if (prescriptionCode.Length != 10 || InputCheck.CheckCodeVerification(prescriptionCode) == false)
            {
                statusController.CallLog("PrescriptionDetails", prescriptionCode, 404); //记录日志。
                return NotFound();       //方剂代码不为10位或代码校验不通过，则返回404。
            }
            else
            {
                string queryText = $"EXEC [Get_Prescription_Details] @Prescription_Code = N'{prescriptionCode.Replace("\'", "")}'";    //将过滤引号后的参数赋给查询语句。
                var response = LandsparkTCMDataService.ExecuteSelectDatasetQuery(queryText);

                if (response.StatusCode != 401)
                {
                    statusController.CallLog("PrescriptionDetails", prescriptionCode, response.StatusCode); //记录日志。
                }
                else
                {
                    statusController.CallLog("PrescriptionDetails", prescriptionCode, response.StatusCode, response.Data);   //报回401错误，则记录错误信息。
                }

                return statusController.HandleResponse(response);
            }
        }
    }
}
