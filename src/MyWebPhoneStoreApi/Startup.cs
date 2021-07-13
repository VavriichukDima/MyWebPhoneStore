using System.Collections.Generic;
using System.Text.Json.Serialization;
using PhoneApi.Configuration;
using PhoneApi.Data;
using PhoneApi.Data.Cache;
using PhoneApi.DataProviders;
using PhoneApi.DataProviders.Abstractions;
using PhoneApi.Services;
using PhoneApi.Services.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace PhoneApi
{
    public class Startup
    {
        public Startup()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();

            AppConfiguration = builder.Build();
        }

        public IConfiguration AppConfiguration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                { Title = "MyWebPhoneStoreApi", Version = "v1" });
            });

            services.AddTransient<IRedisCacheConnectionService, RedisCacheConnectionService>();
            services.AddTransient<ICacheService<PhoneApiCacheEntity>, CacheService<PhoneApiCacheEntity>>();
            services.AddTransient<IJsonSerializer, JsonSerializer>();

            services.Configure<Config>(AppConfiguration);

            var connectionString = AppConfiguration["MyWebPhoneStoreApi:ConnectionString"];
            services.AddDbContext<PhoneApiDbContext>(
                opts => opts.UseNpgsql(connectionString));

            services.AddTransient<IPhoneProvider, PhoneApiProvider>();
            services.AddTransient<IPhoneService, PhoneService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                    c.SwaggerEndpoint(
                        "/swagger/v1/swagger.json",
                        "MyWebPhoneStoreApi v1"));
            }

            app.UseRouting();
            app.UseEndpoints(builder => builder.MapDefaultControllerRoute());
        }
    }
}