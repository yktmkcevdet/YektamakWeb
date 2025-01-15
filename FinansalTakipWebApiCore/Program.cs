using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using FinansalTakipWebApiCore.TokenJobs;

namespace FinansalTakipWebApiCore
{
    // Program.cs veya Startup.cs
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //builder.Configuration.SetBasePath(Directory.GetCurrentDirectory()) // E�er BasePath yanl��sa do�ru yolu belirtin
            //              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            // JWT Ayarlar�n� yap�land�rma
            var jwtSettings = builder.Configuration.GetSection("JwtSettings");
            builder.Services.AddControllers();
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["Issuer"],
                    ValidAudience = jwtSettings["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]))
                };
            });

            builder.Services.AddAuthorization();

            // TokenService'i DI'ye ekleyin
            string secretKey = jwtSettings["SecretKey"];
            builder.Services.AddSingleton<TokenService>(sp => new TokenService(jwtSettings["SecretKey"]));

            var app = builder.Build();

            // Middleware ayarlar�
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers(); // Controller'lar� kullanabilmek i�in

            app.Run();
        }
    }


}
