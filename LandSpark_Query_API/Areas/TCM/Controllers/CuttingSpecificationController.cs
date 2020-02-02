using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;         //此类需要继承“Microsoft.AspNetCore.Mvc.Controller”。
using LandSpark_Query_API.Areas.TCM.Services;     //此类需要通过“LandSpark_Query_API.Services”获取数据。

namespace LandSpark_Query_API.Areas.TCM.Controllers
{
    [Route("api/[controller]")]
    public class CuttingSpecificationController : Controller
    {
        [HttpGet]
        public JsonResult GetCuttingSpecifications()
        {
            return new JsonResult(
                //new List<CuttingSpecification>
                //{
                //    new CuttingSpecification
                //    {
                //        CuttingSpecification_Code = "00",
                //        CuttingSpecification_Name = "净制（如清除杂质、除去非药用部位）",
                //    },

                //    new CuttingSpecification
                //    {
                //        CuttingSpecification_Code = "01",
                //        CuttingSpecification_Name = "极薄片（0.5mm以下）",
                //    }
                //}     //该部分数据写入了TCMService.cs中。

                TCMService.Current.CuttingSpecifications    //返回TCMService类下Current属性所返回之实例的CuttingSpecifications属性。
                );

            /*
             *  完成此步后，请求的网址返回404 Not Found, 因为还没有配置路由 Routing, 所以MVC不知道如何处理/映射这些URI。
             *  
             *  路由有两种方式: Convention-based (按约定), attribute-based(基于路由属性配置的). 
             *  其中convention-based (基于约定的) 主要用于MVC (返回View或者Razor Page那种的).
             *  Web api 推荐使用attribute-based.
             *  这种基于属性配置的路由可以配置Controller或者Action级别, URI会根据Http method然后被匹配到一个controller里具体的action上.
             *  常用的Http Method有:
             *  Get, 查询, Attribute: HttpGet, 例如: '/api/product', '/api/product/1'
             *  POST, 创建, HttpPost, '/api/product'
             *  PUT 整体修改更新 HttpPut, '/api/product/1'
             *  PATCH 部分更新, HttpPatch, '/api/product/1'
             *  DELETE 删除, HttpDelete, '/api/product/1
             *  
             *  使用[Route("api/[controller]")], 它使得整个Controller下面所有action的URI前缀变成了"/api/product", 其中[controller]表示XxxController.cs中的Xxx(其实是小写).
             *  也可以具体指定, [Route("api/product")], 这样做的好处是, 如果ProductController重构以后改名了, 只要不改Route里面的内容, 那么请求的地址不会发生变化.
             *  然后在GetProducts方法上面, 写上HttpGet, 也可以写HttpGet(). 它里面还可以加参数,例如: HttpGet("all"), 那么这个Action的请求的地址就变成了 "/api/product/All"
             *  
             *  Source: https://blog.csdn.net/kingyumao/article/details/82896061
             */
        }

        [Route("{code}")]
        public JsonResult GetCuttingSpecification(string code)
        {
            return new JsonResult(
                TCMService.Current.CuttingSpecifications.SingleOrDefault(x => x.CuttingSpecification_Code == code)
                );
        }


    }

}
