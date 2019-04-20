using System;
using Artstesh.Controllers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.Extensions;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuizWeb.Data.DbContext;
using QuizWeb.Data.Repositories;
using QuizWeb.Data.Repositories.Implementation;
using QuizWeb.Data.Services;

namespace QuizWeb
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
            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                })
                .AddCookie(options =>
                {
                    options.LoginPath = "/Account/Login";
                    options.LogoutPath = "/Account/logout";
                    options.Cookie.Name = ".AspNetCore.Cookies";
                    options.Cookie.Expiration = TimeSpan.FromHours(5);
                });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMemoryCache();
            services.AddDbContext<DataContext>(options =>
            {
                options.UseMySQL(Configuration.GetConnectionString("DataContext"));
            });
            services.AddScoped<IAnswerLogRepository, AnswerLogRepository>();
            services.AddScoped<IChallengeRepository, ChallengeRepository>();
            services.AddScoped<IThemeRepository, ThemeRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserSessionRepository, UserSessionRepository>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IStudentResultService, StudentResultService>();
            services.AddScoped<IStudentResultService, StudentResultService>();
            services.AddScoped<IExamVersionRepository, ExamVersionRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ILevelRepository, LevelRepository>();
            services.AddScoped<IChallengeControllerHelper, ChallengeControllerHelper>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            IDistributedCache distributedCache)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
        //    app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "default",
                    "{controller=Wiki}/{action=Index}/{id?}");
            });
            var cacheEntryOptions = new DistributedCacheEntryOptions()
                .SetAbsoluteExpiration(
                    TimeSpan.FromMinutes(Convert.ToDouble(Configuration.GetSection("appkeys")["CacheLifeTime"])));
            distributedCache.Set("News", new byte[0], cacheEntryOptions);
        }
    }
}