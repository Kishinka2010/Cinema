using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Cinema.Dal.Data;
using Microsoft.EntityFrameworkCore;
using Cinema.Dal.interfaces;
using Cinema.Dal.mocks;
using Cinema.Dal.Dbo;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Cinema
{

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true)
                .AddEnvironmentVariables()
                .Build();
        }

        readonly string MyCorsPolicy = "_myAllowSpecificOrigins";

        public IConfiguration Configuration { get; }



        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers()
                    .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddIdentity<UsersDbo, RoleDbo>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequireLowercase = false;
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 5;
            })
                .AddRoles<RoleDbo>()
                .AddRoleStore<RoleStore<RoleDbo, CinemaDbContext, Guid, UsersRoleDbo, IdentityRoleClaim<Guid>>>()
                .AddRoleManager<RoleManager<RoleDbo>>()
                .AddUserManager<UserManager<UsersDbo>>()
                .AddSignInManager<SignInManager<UsersDbo>>()
                .AddClaimsPrincipalFactory<UserClaimsPrincipalFactory<UsersDbo, RoleDbo>>()
                .AddEntityFrameworkStores<CinemaDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication()
                .AddCookie();


            services.ConfigureApplicationCookie(options =>
            {
                {
                    options.Cookie.HttpOnly = false;
#if DEBUG
                    options.Cookie.SameSite = SameSiteMode.Strict;
                    options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
#else
                    options.Cookie.SameSite = SameSiteMode.None;
                    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
#endif

                    options.Events.OnRedirectToAccessDenied =
                        options.Events.OnRedirectToLogin =
                            options.Events.OnRedirectToReturnUrl = (context) =>
                            {
                                context.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                                return Task.CompletedTask;
                            };
                }
            });

            services.AddAuthorization();

            var connectionString = Configuration.GetConnectionString("CinemaContext");

            services.AddDbContext<CinemaDbContext>(options =>
                    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 28))));

            services.AddTransient<IAllMovie, MockMovie>();
            services.AddTransient<ISessionMovie, MockSession>();
            services.AddMvc();


            services.AddCors(options =>
            {
                options.AddPolicy(name: MyCorsPolicy, builder =>
                {
                    builder
                        .WithOrigins("http://localhost:3000",
                            "https://wonderful-wave-05b443303.azurestaticapps.net",
                            "http://dev.dms.devs-universe.com",
                            "https://dev.dms.devs-universe.com",
                            "http://dms.devs-universe.com",
                            "https://dms.devs-universe.com")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });



        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();   // добавляем поддержку статических файлов

            app.UseRouting();

            app.UseCors(MyCorsPolicy);

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Movie}/{action=Index}/{id?}");
            });

        }
    }
}




//public class Startup
//{
//    public Startup(IConfiguration configuration)
//    {
//        Configuration = configuration;
//        Configuration = new ConfigurationBuilder()
//          .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
//          .AddJsonFile("appsettings.json", optional: true)
//          .AddEnvironmentVariables()
//          .Build();
//    }


//    readonly string MyCorsPolicy = "_myAllowSpecificOrigins";


//    public IConfiguration Configuration { get; }

//    // This method gets called by the runtime. Use this method to add services to the container.
//    public void ConfigureServices(IServiceCollection services)
//    {
//        services.AddControllers()
//               .AddNewtonsoftJson(options =>
//               options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

//        services.AddIdentity<UsersDbo, RoleDbo>(options =>
//        {
//            options.User.RequireUniqueEmail = true;
//            options.Password.RequireLowercase = false;
//            options.Password.RequireDigit = false;
//            options.Password.RequireNonAlphanumeric = false;
//            options.Password.RequireUppercase = false;
//            options.Password.RequiredLength = 5;
//        })
//            .AddRoles<RoleDbo>()
//            .AddRoleStore<RoleStore<RoleDbo, CinemaDbContext, Guid, UsersRoleDbo, IdentityRoleClaim<Guid>>>()
//            .AddRoleManager<RoleManager<RoleDbo>>()
//            .AddUserManager<UserManager<UsersDbo>>()
//            .AddSignInManager<SignInManager<UsersDbo>>()
//            .AddClaimsPrincipalFactory<UserClaimsPrincipalFactory<UsersDbo, RoleDbo>>()
//            .AddEntityFrameworkStores<CinemaDbContext>()
//            .AddDefaultTokenProviders();

//        services.AddAuthentication()
//           .AddCookie();

//        services.ConfigureApplicationCookie(options =>
//        {
//            {
//                //options.Cookie.HttpOnly = false;
//#if DEBUG
//                options.Cookie.SameSite = SameSiteMode.Strict;
//                options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
//#else
//                    options.Cookie.SameSite = SameSiteMode.None;
//                    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
//#endif

//                options.Events.OnRedirectToAccessDenied =
//                    options.Events.OnRedirectToLogin =
//                        options.Events.OnRedirectToReturnUrl = (context) =>
//                        {
//                            context.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
//                            return Task.CompletedTask;
//                        };
//            }
//        });

//        services.AddAuthorization();

//        var connectionString = Configuration.GetConnectionString("CinemaContext");

//        services.AddDbContext<CinemaDbContext>(options =>
//                options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 28))));



//        services.AddControllersWithViews();
//        services.AddMvc();
//        services.AddTransient<IAllMovie, MockMovie>();
//        services.AddTransient<ISessionMovie, MockSession>();
//        services.AddSingleton<CinemaDbContext>();
//    }

//    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
//    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//    {
//        if (env.IsDevelopment())
//        {
//            app.UseDeveloperExceptionPage();
//            app.UseStatusCodePages();
//            app.UseStaticFiles();
//            //app.UseMvcWithDefaultRoute();
//        }
//        else
//        {
//            app.UseExceptionHandler("/Home/Error");
//            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//            app.UseHsts();
//        }
//        app.UseHttpsRedirection();
//        app.UseStaticFiles();

//        app.UseRouting();

//        app.UseAuthentication();
//        app.UseAuthorization();

//        app.UseEndpoints(endpoints =>
//        {
//            endpoints.MapControllerRoute(
//                name: "default",
//                pattern: "{controller=Movie}/{action=Index}/{id?}");
//        });
//    }
//}

