using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace LandSpark_Query_API.Areas.TCM.Services
{
    /// <summary>
    /// 读取配置文件中关于TCM区域的信息。
    /// </summary>
    class ConfigManager
    {
        public static IConfiguration Configuration { get; set; }

        static ConfigManager()
        {
            //读取配置文件。
            Configuration = new ConfigurationBuilder().Add(
                new JsonConfigurationSource
                {
                    Path = "appsettings.json",
                    ReloadOnChange = true   //当appsetting.json被修改时重新加载。
                }).Build();

        }
    }
}
