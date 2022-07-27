using JsonBasedLocalization.Api;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SchoolProject.Models;
using SchoolProject.Repository;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApiJWT.Helpers;
using TestApiJWT.Services;

namespace SchoolProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //var builder = WebApplication.
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => {
                options.AddDefaultPolicy(builder => {
                    builder.WithOrigins("http://localhost:4200", 
                        "http://localhost:4211",
                        "http://silver-phoenix-debecd.netlify.app",
                        "http://lucent-froyo-b816bb.netlify.app",
                        "http://hossamfox224-001-site2.gtempurl.com",
                        "http://ceotaelim-001-site2.gtempurl.com",
                        "http://ceotaelim-001-site3.gtempurl.com")
                    .AllowAnyHeader()
                    .AllowAnyMethod().AllowCredentials();

                });


            });
                //options.AddDefaultPolicy(builder => {
                //    builder.WithOrigins("/*http://localhost:4211*/")
                //    .AllowAnyHeader()
                //    .AllowAnyMethod().AllowCredentials();

                //});

            services.Configure<JWT>(Configuration.GetSection("JWT"));
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<Context>();

            services.AddScoped<IAuthService, AuthService>();
            services.AddControllersWithViews();
            services.AddDbContext<Context>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("CS"));

            });

            services.AddScoped(typeof(ICRUD_Repository<>), typeof(CRUD_Repository<>));
            services.AddScoped(typeof(ICrud_Repository1<>), typeof(Crud_Repository1<>));

            services.AddScoped(typeof(Istdrepo), typeof(stdrepo));

            services.AddScoped(typeof(ICountrepository), typeof(Countrepository));

            services.AddScoped(typeof(IuserRepository), typeof(userRepository));

            services.AddLocalization();
            services.AddDistributedMemoryCache();
           services.AddSingleton<IStringLocalizerFactory, JsonStringLocalizerFactory>();


            services.AddMvc()
                .AddDataAnnotationsLocalization(options =>
                {
                    options.DataAnnotationLocalizerProvider = (type, factory) =>
                        factory.Create(typeof(JsonStringLocalizerFactory));
                });

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {
        new CultureInfo("en-US"),
        new CultureInfo("ar-EG")
    };

                options.DefaultRequestCulture = new RequestCulture(culture: supportedCultures[0]);
                options.SupportedCultures = supportedCultures;
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            // services.AddEndpointsApiExplorer();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(o =>
                {
                    o.RequireHttpsMetadata = false;
                    o.SaveToken = false;
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = Configuration["JWT:Issuer"],
                        ValidAudience = Configuration["JWT:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Key"]))
                    };
                });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SchoolProject", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SchoolProject v1"));
            }
            app.UseCors();
            app.UseRouting();
            var supportedCultures = new[] { "en-US", "ar-EG"};
            var localizationOptions = new RequestLocalizationOptions()
                .SetDefaultCulture(supportedCultures[0])
                .AddSupportedCultures(supportedCultures);

            app.UseRequestLocalization(localizationOptions);


            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
