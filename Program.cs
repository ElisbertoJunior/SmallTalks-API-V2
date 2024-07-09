
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Smalltalks.Data;
using Smalltalks.Repository;
using Smalltalks.Repository.Interfaces;
using Smalltalks.Services;
using System.Security.Claims;
using System.Text.Encodings.Web;
using Serilog;
using Serilog.Core;


namespace Smalltalks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var POLICY = "*";
            var builder = WebApplication.CreateBuilder(args);

            // Configurando Serilog
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("Logs/myapp-.log", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            builder.Host.UseSerilog();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("BlipPolicy",
                    builder =>
                    {
                        builder.AllowAnyHeader()
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });

            

            builder.Services.AddEntityFrameworkNpgsql()
                .AddDbContext<SmallTalksDBContext>(
                    options => options.UseNpgsql(builder.Configuration.GetConnectionString("DataBase"))
                );

            builder.Services.AddAuthentication("ApiKeyScheme")
                .AddScheme<ApiKeyAuthenticationOptions, ApiKeyAuthenticationHandler>("ApiKeyScheme", option => { });

            builder.Services.AddScoped<ISwearingRepository, SwearingRepository>();
            builder.Services.AddScoped<ISalutationRepository, SalutationRepository>();
            builder.Services.AddScoped<IToThankRepository, ToThankRepository>();

            builder.Services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Authorization header using the Beaerer scheme (Example: '12345abcdef')",
                    Name = "ApiKey",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });

                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SmallTalks.api", Version = "v1" });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.Use(async (context, next) =>
            {
                Log.Information("Handling request: " + context.Request.Method + " " + context.Request.Path);
                await next.Invoke();
                Log.Information("Finished handling request.");
               
            });

            // Presentation message after application is started
            Log.Information("****************************************");
            Log.Information("*    Aplicação iniciada com sucesso!   *");
            Log.Information("****************************************");

            app.UseCors("BlipPolicy");

            app.MapControllers();

            app.Run();
        }
    }

    public class ApiKeyAuthenticationHandler : AuthenticationHandler<ApiKeyAuthenticationOptions>
    {
        public ApiKeyAuthenticationHandler(IOptionsMonitor<ApiKeyAuthenticationOptions> options,
                                           ILoggerFactory logger,
                                           UrlEncoder encoder,
                                           ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("ApiKey"))
            {
                return AuthenticateResult.Fail("API key is missing");
            }

            var apiKey = Request.Headers["ApiKey"];

            if (string.IsNullOrEmpty(apiKey))
            {
                return AuthenticateResult.Fail("API key is missing");
            }

            if (!IsApiKeyValid(apiKey))
            {
                return AuthenticateResult.Fail("Invalid API key");
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, "ApiKeyUser")
                // Aqui você pode adicionar outras claims conforme necessário
            };

            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }

        private bool IsApiKeyValid(string apiKey)
        {
            if (apiKey != "Besouro")
            {
                return false;
            }

            return true;
        }
    }

    public class ApiKeyAuthenticationOptions : AuthenticationSchemeOptions
    {
        public const string DefaultScheme = "ApiKeyScheme";
        public string Scheme => DefaultScheme;
        public string AuthenticationType = DefaultScheme;
    }
}
