using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MLRSIntroductoryWebApi.Models;
using MLRSIntroductoryWebApi.Service;
using MRLSIntroductoryProjectWebApi.Data;

namespace MRLSIntroductoryProjectWebApi
{
    public class Startup
    {
        private const string _myAllowAnyOrigin = "_myAllowAnyOrigin";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(_myAllowAnyOrigin,
                    builder =>
                    {
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });
            var serviceProvider = services.BuildServiceProvider();
            var logger = serviceProvider.GetService<ILogger<User>>();


            services.AddSingleton(typeof(ILogger), logger);
            // TODO use scoped
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();
            services.AddAutoMapper(typeof(Startup));

            services.AddControllers();

            services.AddDbContext<UserContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("UserContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile("Logs/log-{Date}.txt");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(_myAllowAnyOrigin);
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
