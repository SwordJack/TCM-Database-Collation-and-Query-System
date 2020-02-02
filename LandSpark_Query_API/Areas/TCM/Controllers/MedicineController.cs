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
using System.IO;
using System.Drawing;                   //用于读取和返回图片。
using Microsoft.Extensions.Logging;     //用于生成日志。
using LandSpark_Query_API.Areas.TCM.Services;
using LandSpark_Query_API.Areas.TCM.Dtos;   //用于调用数据传输对象。
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LandSpark_Query_API.Areas.TCM.Controllers
{
    [Route("api/Traditional-Chinese-Medicine/[controller]")]
    public class MedicineController : Controller
    {
        private readonly ILogger<MedicineController> _logger;   //使用ILogger接口的实例，用于记录访问信息。
        public MedicineController(ILogger<MedicineController> logger)
        {
            _logger = logger;
        }

        #region 药物信息检索
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
        [HttpGet]
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

                return statusController.HandleResponse(response);
            }
        }

        /// <summary>
        /// 获取药物的详细信息。
        /// </summary>
        /// <param name="medicineCode">药物代码</param>
        /// <returns></returns>
        [HttpGet]
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

                return statusController.HandleResponse(response);
            }
        }

        /// <summary>
        /// 根据药物代码，返回药物的图片。
        /// </summary>
        /// <param name="medicineCode">药物代码</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{medicineCode}/image")]
        public IActionResult MedicineImage(string medicineCode)
        {
            var statusController = new StatusController<MedicineController>(_logger);   //创建StatusController类的实例。

            string imageDirectory = LandsparkTCMDataService.SiteFileDirectory + @"Resources\TCM_Image\";           //图片的保存目录。
            string errorImage = imageDirectory + "404.png";     //不存在图片时的默认返回值。

            #region 从数据库获取图片文件名。
            string queryText = string.Format(@"EXEC [Get_Medicine_Image] @TCM_Code = N'{0}'", medicineCode.Replace("\'", ""));      //将过滤引号后的参数赋给查询语句。
            var response = LandsparkTCMDataService.ExecuteSelectScalarQuery(queryText);
            var fileQueryResult = response.Data;
            #endregion

            string imgPath;
            if (!(fileQueryResult is DBNull))    //当查询结果不为数据库空值（即：SQL Server的返回值为NULL）时。
            {
                imgPath = imageDirectory + fileQueryResult.ToString();    //查询结果，图片文件名记录存在，则设置图片路径为文件路径。
            }
            else
            {
                imgPath = errorImage;       //查询结果，图片文件名记录不存在，则设置图片路径为404.png。
            }

            Dictionary<string, string> contentTypDict = new Dictionary<string, string> {
                {"jpg","image/jpeg"},
                {"jpeg","image/jpeg"},
                {"jpe","image/jpeg"},
                {"png","image/png"},
                {"gif","image/gif"},
                {"ico","image/x-ico"},
                {"tif","image/tiff"},
                {"tiff","image/tiff"},
                {"fax","image/fax"},
                {"wbmp","image/vnd.wap.wbmp"},
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

            string imgDownloadName;    //图片在网页上被下载时所用名称。

            if (imgPath == errorImage)
            {
                statusController.CallLog("MedicineImage", medicineCode, 404);    //若返回404.png，记录状态为404。
                imgDownloadName = $"404.{imgType}";
            }
            else
            {
                statusController.CallLog("MedicineImage", medicineCode, 200);    //记录日志。
                imgDownloadName = $"{medicineCode}.{imgType}";
            }

            //using (FileStream fs = new FileStream(imgPath, FileMode.Open))  //启用一个文件流。
            //{
            //    byte[] buffer = new byte[fs.Length];    //二进制数组变量buffer。
            //    fs.Read(buffer, 0, buffer.Length);      //将文件流中内容读入buffer中。
            //    fs.Close();
            //    return (File(buffer, contentTypeStr));
            //}

            return PhysicalFile(imgPath, contentTypeStr, imgDownloadName);  //返回文件的物理地址。


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

        #endregion

        #region 药物信息录入
        /// <summary>
        /// 接受经授权的用户将上传的图片文件，并将文件信息录入到数据库和NFS文件系统。
        /// </summary>
        /// <param name="formData">经由POST传递的包含图片文件的form-data</param>
        /// <param name="medicineCode">药物代码</param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("{medicineCode}/image/upload")]
        public IActionResult MedicineImageUpload(IFormCollection formData, string medicineCode)
        {
            var statusController = new StatusController<MedicineController>(_logger);   //创建StatusController类的实例。

            string imageDirectory = LandsparkTCMDataService.SiteFileDirectory + @"Resources\TCM_Image\";           //图片的保存目录。

            LandSpark_Query_API.Areas.TCM.Dtos.MedicineImageUpload upload = new LandSpark_Query_API.Areas.TCM.Dtos.MedicineImageUpload(medicineCode, this.User.Identity.Name);  //Dtos目录下的类名称恰与此控制器名称相同，故使用类的完整名称。

            string functionNameToLog = $"MedicineImageUpload By '{upload.Username}'";  //用于在日志中记录方法名，包含方法名称和用户。

            if (!(formData is null))
            {
                try
                {
                    //string imgData = formData["File"];          //这破玩意没有被引用，删了删了！

                    //IFormFileCollection formFiles = Request.Form.Files;     //获取请求中的文件列表。
                    //var imgFile = formFiles[0];     //获取文件列表中第0个元素。
                    var imgFile = Request.Form.Files[0];   //获取请求中的文件列表的第0个元素。

                    string[] pictureTypeLimitation = { ".jpg", ".jpeg", ".jpe", ".png", ".bmp" };   //设定图片格式限制。

                    string pictureTypeUploaded = Path.GetExtension(imgFile.FileName).ToLower();

                    if (!pictureTypeLimitation.Contains(pictureTypeUploaded))   //若文件类型不在指定范围内，触发阻止。
                    {
                        statusController.CallLog(functionNameToLog, imgFile.FileName, 403, "文件格式不符合要求");
                        return Forbid();
                    }

                    upload.ImgFileName = $"{upload.MedicineCode}{pictureTypeUploaded}";

                    string queryText = $"EXEC [Insert_Medicine_Image] @TCM_Code = '{upload.MedicineCode}', @File_Name = '{upload.ImgFileName}', @DataConstructer = '{upload.Username}'";
                    var response = LandsparkTCMDataService.ExecuteInsertQuery(queryText);

                    if (response.StatusCode != 401)
                    {
                        statusController.CallLog(functionNameToLog, upload.MedicineCode, response.StatusCode); //记录日志。
                        using (FileStream fs = new FileStream($"{imageDirectory}{upload.ImgFileName}", FileMode.Create, FileAccess.Write))   //启用文件流，创建并写入文件到路径地址。
                        {
                            imgFile.CopyTo(fs);     //将所接收文件复制到文件流。
                            fs.Flush();             //将文件流信息写入文件，并清除文件流。
                        }
                        upload.AffectedRowsCount = Convert.ToInt32(response.Data);
                        return StatusCode(201, upload.GetUploadStatus());
                    }
                    else
                    {
                        statusController.CallLog(functionNameToLog, upload.MedicineCode, response.StatusCode, response.Data);    //报回401错误，则记录错误信息。
                        return statusController.HandleResponse(response);
                    }

                }
                catch (Exception ex)
                {
                    statusController.CallLog(functionNameToLog, upload.MedicineCode, 500, ex);
                    return StatusCode(500);
                }
            }
            else
            {
                statusController.CallLog(functionNameToLog, upload.MedicineCode, 403, "无文件。");
                return Forbid();
            }
        }
        #endregion
    }
}
