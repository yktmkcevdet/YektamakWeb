using BlazorApp1.Features.Commands.Account.Login;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Requests;
using System.Text;
using YektamakWeb;
using YektamakWeb.Data;

var builder = WebApplication.CreateBuilder(args);
 
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddBlazorBootstrap();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
// Dependency Injection
builder.Services.AddScoped<UserSession>();
builder.Services.AddTransient<LoginHandler>();
builder.Services.AddScoped<IWebMethods, WebMethods>();
builder.Services.AddTransient<ProgramConst>();
builder.Services.AddTransient<Utilities.GlobalData>();
// JWT Authentication
var jwtSettings = builder.Configuration.GetSection("jwtsettings");
var secretKey = jwtSettings.GetValue<string>("SecretKey");
builder.Services.AddDistributedMemoryCache();  // Bellek tabanlý bir daðýtýk önbellek kullanýyoruz
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);  // Oturumun geçerlilik süresi (örneðin 30 dakika)
    options.Cookie.HttpOnly = true;  // Yalnýzca sunucu tarafýndan eriþilebilir
    options.Cookie.IsEssential = true;  // Oturum çerezi, GDPR gereksinimleri nedeniyle gerekli
});


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings.GetValue<string>("Issuer"),
        ValidAudience = jwtSettings.GetValue<string>("Audience"),
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
    };
});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireClaim("Role", "1"));
    options.AddPolicy("UserOnly", policy => policy.RequireClaim("Role", "2"));
    options.AddPolicy("ProjeTasarimMuhendisiOnly", policy => policy.RequireClaim("Role", "5"));
});
// Session servisini ekleyin
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseSession();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapBlazorHub();
app.MapFallbackToPage("/_host");

app.Run();
