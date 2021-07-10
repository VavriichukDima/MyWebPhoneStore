using System.Collections.Generic;
using System.Text.Json.Serialization;
using MyWebPhoneStoreApi.Configuration;
using MyWebPhoneStoreApi.Data;
using MyWebPhoneStoreApi.Data.Cache;
using MyWebPhoneStoreApi.DataProviders;
using MyWebPhoneStoreApi.DataProviders.Abstractions;
using MyWebPhoneStoreApi.Services;
using MyWebPhoneStoreApi.Services.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using BookApi.DataProviders;

namespace MyWebPhoneStoreApi
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
            services.AddTransient<ICacheService<WebPhoneStoreApiCacheEntity>, CacheService<WebPhoneStoreApiCacheEntity>>();
            services.AddTransient<IJsonSerializer, JsonSerializer>();

            services.Configure<Config>(AppConfiguration);

            var connectionString = AppConfiguration["MyWebPhoneStoreApi:ConnectionString"];
            services.AddDbContext<MyWebPhoneStoreApiDbContext>(
                opts => opts.UseNpgsql(connectionString));

            services.AddTransient<IMyWebPhoneStoreProvider, MyWebPhoneStoreApiProvider>();
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