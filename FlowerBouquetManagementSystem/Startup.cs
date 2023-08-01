using FlowerBouquetManagementSystem.SignalR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Text.Json.Serialization;

namespace FlowerBouquetManagementSystem
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
            services.AddRazorPages(
            //options =>
            //{
            //    options.Conventions.AuthorizeFolder("/Admin");
            //}
            )
            .AddJsonOptions(options => {
            //    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
                //options.JsonSerializerOptions.MaxDepth = 64;
            })
            .AddRazorPagesOptions(options =>
            {
                options.Conventions.AddPageRoute("/Shared/Index", "");
            })
            ;
            services
                //.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                //.AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options => Configuration.Bind("JwtSettings", options));
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultSignOutScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                })
                //.AddCookie()
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options => {
                    options.Cookie.Name = "CookieSettings";
                    options.LoginPath = "/Login";
                    options.LogoutPath = "/Logout";
                })
            ;
            services.AddAuthorization(
                //options =>
                //{
                //    options.AddPolicy("AdminRole", policy => policy.RequireClaim("Role", "Admin"));
                //    options.AddPolicy("UserRole", policy => policy.RequireClaim("Role", "User"));
                //}
            );
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapHub<FlowerHub>("/flowerHub");
            });
        }
    }
}
