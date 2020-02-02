using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LandSpark_Query_API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
            {
                o.LoginPath = new PathString("/TraditionalChineseMedicine/Account");   //登录路径：这是当用户试图访问资源但未经过身份验证时，程序将会将请求重定向到这个相对路径。
                o.AccessDeniedPath = new PathString("/index.html");             //禁止访问路径：当用户试图访问资源时，但未通过该资源的任何授权策略，请求将被重定向到这个相对路径。
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                /*
                 * 在正式环境中, 我们遇到exception的时候, 需要捕获并把它记录(log)下来, 
                 * 这时候我们应该使用这个middleware: Exception Handler Middleware, 我们可以这样调用它：
                 * 
                 * UseExceptionHandler是可以传参数的, 但暂时先这样, 
                 * 我们在app.Run方法里抛一个异常, 然后运行程序, 在Chrome里按F12就会发现有一个(或若干个, 多少次请求, 就有多少个错误)500错误.
                 * 
                 * Source: https://blog.csdn.net/kingyumao/article/details/81532745
                 */
                app.UseExceptionHandler(@"/500.txt");
            }

            app.UseAuthentication();

            app.UseStatusCodePages();   //asp.net core 有一个 status code middleware：StatusCodePages，在Startup.cs中添加StatusCodePages的使用。

            //配置跨域访问，添加于2020.01.23，供开发阶段使用。
            app.UseCors(builder =>
            {
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
                //builder.WithOrigins("http://localhost:8080");

                builder.AllowAnyOrigin();   //开发过程中使用，生产环境不适用。
            });
            //以上。


            app.UseMvc();
        }
    }
}
