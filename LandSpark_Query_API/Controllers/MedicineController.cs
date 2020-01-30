using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
/*
 * 以上为系统自动引用；
 * 以下为开发者引用；
 * 2019.12.30, 14:21
 */
//using Newtonsoft.Json;                  //控制器返回Json格式数据。
using Microsoft.AspNetCore.Http;
using LandSpark_Query_API.Services;     //控制器需要Services名字空间提供服务支持。
using System.IO;
using System.Drawing;                   //用于读取和返回图片。
using Microsoft.Extensions.Logging;     //用于生成日志。

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LandSpark_Query_API.Controllers
{
    [Route("api/Traditional-Chinese-Medicine/[controller]")]
    public class MedicineController : Controller
    {
        private readonly ILogger<MedicineController> _logger;   //使用ILogger接口的实例，用于记录访问信息。
        public MedicineController(ILogger<MedicineController> logger)
        {
            this._logger = logger;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            //return View();
            return Ok("药物查询");
        }

        /// <summary>
        /// 药物检索，暂时仅设计按名称查询之功能。
        /// </summary>
        /// <returns></returns>
        [Route("search")]
        public IActionResult MedicineName()
        {
            var statusController = new StatusController<MedicineController>(_logger);

            IQueryCollection parameters = HttpContext.Request.Query;
            string name = parameters["name"];
            if (name.Length == 0)
            {
                statusController.CallLog("MedicineSearch", null, 301);      //记录日志。
                return Redirect("../medicine/");  //重定向至medicine目录。
            }
            else
            {
                string queryText = $"EXEC [Get_Medicine_By_Name] @input = N'{name.Replace("\'", "")}'";    //将过滤引号后的参数赋给查询语句。
                var response = LandsparkTCMDataService.ExecuteSelectDatasetQuery(queryText);

                if (response.StatusCode != 401)
                {
                    statusController.CallLog("MedicineSearch", name, response.StatusCode); //记录日志。
                }
                else
                {
                    statusController.CallLog("MedicineDetails", name, response.StatusCode, response.Data);   //报回401错误，则记录错误信息。
                }

                return (statusController.HandleResponse(response));
            }
        }

        /// <summary>
        /// 获取药物的详细信息。
        /// </summary>
        /// <param name="medicineCode">药物代码</param>
        /// <returns></returns>
        [Route("{medicineCode}")]
        public IActionResult MedicineCode(string medicineCode)
        {
            var statusController = new StatusController<MedicineController>(_logger);   //创建StatusController类的实例。

            if (medicineCode.Length != 17 || InputCheck.CheckCodeVerification(medicineCode) == false)
            {
                statusController.CallLog("MedicineDetails", medicineCode, 404); //记录日志。
                return NotFound();       //药物代码不为17位或代码校验不通过，则返回404。
            }
            else
            {
                string queryText = $"EXEC [Get_Medicine_Details] @TCM_Code = N'{medicineCode.Replace("\'", "")}'";    //将过滤引号后的参数赋给查询语句。
                var response = LandsparkTCMDataService.ExecuteSelectDatasetQuery(queryText);

                if (response.StatusCode != 401)
                {
                    statusController.CallLog("MedicineDetails", medicineCode, response.StatusCode); //记录日志。
                }
                else
                {
                    statusController.CallLog("MedicineDetails", medicineCode, response.StatusCode, response.Data);    //报回401错误，则记录错误信息。
                }

                return (statusController.HandleResponse(response));
            }
        }

        /// <summary>
        /// 根据药物代码，返回药物的图片。
        /// </summary>
        /// <param name="medicineCode">药物代码</param>
        /// <returns></returns>
        [Route("{medicineCode}/image")]
        public IActionResult MedicineImage(string medicineCode)
        {
            var statusController = new StatusController<MedicineController>(_logger);   //创建StatusController类的实例。

            string imageDirectory = LandsparkTCMDataService.SiteFileDirectory + @"Resources\TCM_Image\";           //图片的保存目录。
            string errorImage = imageDirectory + "404.png";     //不存在图片时的默认返回值。

            #region 从数据库获取图片文件名。
            string queryText = String.Format(@"EXEC [Get_Medicine_Image] @TCM_Code = N'{0}'", medicineCode.Replace("\'", ""));      //将过滤引号后的参数赋给查询语句。
            var response = LandsparkTCMDataService.ExecuteSelectScalarQuery(queryText);
            var fileQueryResult = response.Data;
            #endregion

            string imgPath;
            if (!(fileQueryResult is System.DBNull))    //当查询结果不为数据库空值（即：SQL Server的返回值为NULL）时。
            {
                imgPath = imageDirectory + fileQueryResult.ToString();    //查询结果，图片文件名记录存在，则设置图片路径为文件路径。
            }
            else
            {
                imgPath = errorImage;       //查询结果，图片文件名记录不存在，则设置图片路径为404.png。
            }
            var contentTypDict = new Dictionary<string, string> {
                {"jpg","image/jpeg"},
                {"jpeg","image/jpeg"},
                {"jpe","image/jpeg"},
                {"png","image/png"},
                {"gif","image/gif"},
                {"ico","image/x-ico"},
                {"tif","image/tiff"},
                {"tiff","image/tiff"},
                {"fax","image/fax"},
                {"wbmp","image//vnd.wap.wbmp"},
                {"rp","image/vnd.rn-realpix"}
            };  //指示图片的文件格式。

            string contentTypeStr = "image/jpeg";       //指示默认值，为jpeg格式图片。

            #region 获取文件后缀名。
            var imgTypeSplit = imgPath.Split('.');
            var imgType = imgTypeSplit[imgTypeSplit.Length - 1].ToLower();
            #endregion

            if (!contentTypDict.ContainsKey(imgType))   //未知的图片类型
            {
                imgPath = errorImage;
            }
            else
            {
                contentTypeStr = contentTypDict[imgType];
            }

            if (!new FileInfo(imgPath).Exists)  //图片不存在
            {
                imgPath = errorImage;
            }

            if (imgPath == errorImage) 
            { 
                statusController.CallLog("MedicineImage", medicineCode, 404);    //若返回404.png，记录状态为404。
            }
            else
            {
                statusController.CallLog("MedicineImage", medicineCode, 200);    //记录日志。
            }

            using (FileStream fs = new FileStream(imgPath, FileMode.Open))  //启用一个文件流。
            {
                byte[] buffer = new byte[fs.Length];    //二进制数组变量buffer。
                fs.Read(buffer, 0, buffer.Length);      //将文件流中内容读入buffer中。
                fs.Close();
                return (File(buffer, contentTypeStr));
            }


            ////原图
            //if (width <= 0)   //参数中包含width才有效。
            //{
            //    using (var sw = new FileStream(imgPath, FileMode.Open))
            //    {
            //        var bytes = new byte[sw.Length];
            //        sw.Read(bytes, 0, bytes.Length);
            //        sw.Close();
            //        return new FileContentResult(bytes, contentTypeStr);
            //    }
            //}
            ////缩小图片
            //using (var imgBmp = new Bitmap(imgPath))
            //{
            //    //找到新尺寸
            //    var oWidth = imgBmp.Width;
            //    var oHeight = imgBmp.Height;
            //    var height = oHeight;
            //    if (width > oWidth)
            //    {
            //        width = oWidth;
            //    }
            //    else
            //    {
            //        height = width * oHeight / oWidth;
            //    }
            //    var newImg = new Bitmap(imgBmp, width, height);
            //    newImg.SetResolution(72, 72);
            //    var ms = new MemoryStream();
            //    newImg.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            //    var bytes = ms.GetBuffer();
            //    ms.Close();
            //    return new FileContentResult(bytes, contentTypeStr);
            //}
        }
    }
}
