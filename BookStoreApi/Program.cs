using System.Text;
using BookStoreApi.Models;
using UasDrwaApi.Models;
using UasDrwaApi.Services;
using BookStoreApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var MyAllowSpecificDrigins = "_myAllowSpecificDrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<BookStoreDatabaseSettings>(
    builder.Configuration.GetSection("BookStoreDatabase"));

builder.Services.Configure<KelasUasDatabaseSettings>(
    builder.Configuration.GetSection("KelasUasDatabase"));
    builder.Services.AddSingleton<KelasUasService>();

builder.Services.Configure<MapelDatabaseSettings>(
    builder.Configuration.GetSection("MapelDatabase"));
    builder.Services.AddSingleton<MapelService>();

builder.Services.Configure<GuruDatabaseSettings>(
    builder.Configuration.GetSection("GuruDatabase"));
    builder.Services.AddSingleton<GuruService>();

builder.Services.Configure<PresensiHarianGuruDatabaseSettings>(
    builder.Configuration.GetSection("PresensiHarianGuruDatabase"));
    builder.Services.AddSingleton<PresensiHarianGuruService>();

builder.Services.Configure<PresensiMengajarDatabaseSettings>(
    builder.Configuration.GetSection("PresensiMengajarDatabase"));
    builder.Services.AddSingleton<PresensiMengajarService>();

builder.Services.AddSingleton<BooksService>();

builder.Services.AddControllers()
    .AddJsonOptions(
        options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true
    };
});
builder.Services.AddAuthorization();
// Add configuration from appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "BookStore API",
        Description = "An ASP.NET Core Web API for managing ToDo items",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });
});

// add cors
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificDrigins,
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:5126");
                    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseCors(MyAllowSpecificDrigins);

IConfiguration configuration = app.Configuration;
IWebHostEnvironment environment = app.Environment;

app.MapControllers();

app.Run();