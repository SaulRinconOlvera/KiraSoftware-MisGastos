using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using MisGastos.CrossCutting.DependencyInjection;
using MisGastos.Web.Services.Utilities.Authorizations.GeneralAccess;
using MisGastos.Web.Services.Utilities.Configuration;
using MisGastos.Web.Services.Utilities.JWT;
using Newtonsoft.Json;
using System;
using System.Text;

namespace MisGastos.Web.Services
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Initialize_AppSettings();
        }

        public IConfiguration Configuration { get; }
        //public static IConfiguration StaticConfiguration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin", c => c.AllowAnyOrigin());
            });

            services.AddControllers().AddNewtonsoftJson(
                options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(o =>
                    o.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = AppConfiguration.Token_ValidateIssuer,
                        ValidateAudience = AppConfiguration.Token_ValidateAudience,
                        ValidateLifetime = AppConfiguration.Token_ValidateLifetime,
                        ValidateIssuerSigningKey = AppConfiguration.Token_ValidateIssuerSigningKey,
                        IssuerSigningKey = 
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppConfiguration.TokenSecretKey)),
                        ClockSkew = TimeSpan.Zero
                    });

            services.AddAuthorization(options =>
            {
                options.AddPolicy(AppConfiguration.GeneralAccessPolicyName,
                    policy => policy.Requirements.Add(new GeneralAccessRequirement()));
            });

            RegisterServices.Register(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(builder =>
                   builder.WithOrigins(AppConfiguration.TokenAudiencie)
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials());

            app.UseAuthentication().UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
        }

        private void Initialize_AppSettings()
        {
            AppConfiguration.Token_ValidateIssuer =
                Convert.ToBoolean(Configuration["JwtBearer:TokenValidationParameters:ValidateIssuer"]);
            AppConfiguration.Token_ValidateAudience =
                Convert.ToBoolean(Configuration["JwtBearer:TokenValidationParameters:ValidateAudience"]);
            AppConfiguration.Token_ValidateLifetime =
                Convert.ToBoolean(Configuration["JwtBearer:TokenValidationParameters:ValidateLifetime"]);
            AppConfiguration.Token_ValidateIssuerSigningKey =
                Convert.ToBoolean(Configuration["JwtBearer:TokenValidationParameters:ValidateIssuerSigningKey"]);
            AppConfiguration.TokenSecretKey = Configuration["JwtBearer:SecretKey"];
            AppConfiguration.TokenExpiration = Convert.ToDouble(Configuration["JwtBearer:Expiration"]);
            AppConfiguration.TokenAlgorithm = Configuration["JwtBearer:Algorithm"];
            AppConfiguration.TokenAudiencie = Configuration["JwtBearer:Audience"];
            AppConfiguration.TokenIssuer = Configuration["JwtBearer:Issuer"];
            AppConfiguration.ImagesPath = Configuration["Application:GeneralConfiguration:ImagesPath"];
        }
    }
}
