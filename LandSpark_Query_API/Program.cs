using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
/*
 * 以上为系统自动引用；
 * 以下为开发者引用；
 * 2020.01.17, 17:51
 */
using Serilog;              //Serilog主库。
using Serilog.AspNetCore;   //Serilog库的ASP.Net Core支持。
using Serilog.Events;
using Serilog.Sinks.File;   //将日志输出到文件上。
using LandSpark_Query_API.Areas.TCM.Services;

namespace LandSpark_Query_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // 配置 Serilog 
            Log.Logger = new LoggerConfiguration()
                // 最小的日志输出级别
                .MinimumLevel.Information()
                // 日志调用类命名空间如果以 Microsoft 开头，覆盖日志输出最小级别为 Information
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                // 配置日志输出到控制台
                .WriteTo.Console()
                // 配置日志输出到文件，文件输出到指定 Logs 目录下
                // 日记的生成周期为每天。
                .WriteTo.File(Path.Combine(LandsparkTCMDataService.SiteFileDirectory, "Logs", "LandsparkLog_.txt"), rollingInterval: RollingInterval.Day)
                // 创建 logger
                .CreateLogger();

            CreateWebHostBuilder(args).Build().Run();
            
            //代码来源：https://blog.csdn.net/Upgrader/article/details/88323907
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
            
            // 将 Serilog 设置为日志记录提供程序。
            .UseSerilog();
            
            
    }
}
