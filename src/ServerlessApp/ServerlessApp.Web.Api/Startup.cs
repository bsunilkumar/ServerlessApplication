using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ServerlessApp.NHibernate;
using ServerlessApp.Repositories.Tenant;
using ServerlessApp.Repositories.User;
using ServerlessApp.ViewModels.Configurations;
using ServerlessApp.Web.Api.Configurations;

namespace ServerlessApp.Web.Api
{
    public class Startup
    {
        public const string AppS3BucketKey = "AppS3Bucket";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            var connStr = Configuration["ConnectionString"];
            services.AddControllers();
            services.AddNHibernatePostgreSQL(connStr);
            // Add S3 to the ASP.NET Core dependency injection framework.
            services.AddAWSService<Amazon.S3.IAmazonS3>();

            services.AddAutoMapperConfiguration();

            // Swagger Config
            services.AddSwaggerConfiguration();

            services.AddScoped<UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<TenantService>();
            services.AddScoped<ITenantRepository, TenantRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwaggerSetup();
        }
    }
}
