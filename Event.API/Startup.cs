using System.Text;
using Event.API.Controllers.Handlers;
using Event.API.Controllers.Handlers.Contracts;
using Event.Core.Configuration;
using Event.Core.Logger;
using Event.Core.Logger.Contracts;
using Event.Core.Services;
using Event.Core.Services.Contracts;
using Event.Core.SessionManagement;
using Event.Core.SessionManagement.Contracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Event.API
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
            services.AddControllers();
            services.AddOptions();
            services.Configure<JwtSettings>(Configuration.GetSection("JwtSettings"));
            services.TryAddSingleton<IJwtSettings>(x => x.GetRequiredService<IOptions<JwtSettings>>().Value);
            services.Configure<CosmosDBSettings>(Configuration.GetSection("CosmosDBSettings"));
            services.TryAddSingleton<ICosmosDBSettings>(x => x.GetRequiredService<IOptions<CosmosDBSettings>>().Value);

            services.AddScoped<IConferenceEventService, ConferenceEventService>();
            services.AddScoped<IConferenceSessionService, ConferenceSessionService>();
            services.AddScoped<IConferenceEventHandler, ConferenceEventHandler>();
            services.AddScoped<IConferenceSessionHandler, ConferenceSessionHandler>();
            services.AddScoped<ISessionManager, SessionManager>();
            services.AddScoped<IFileLogger, FileLogger>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    RequireExpirationTime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtSettings:Key"]))
                };

            });

            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Event API",
                    Description = "Contains all the endpoints for event management application"
                });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("v1/swagger.json", "Event API V1");
            });

            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
