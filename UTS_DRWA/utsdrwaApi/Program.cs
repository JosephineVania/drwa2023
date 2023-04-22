using UtsDrwaApi.Models;
using UtsDrwaApi.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<UtsDrwaDatabaseSettings>(
    builder.Configuration.GetSection("UtsDrwaDatabase"));

builder.Services.AddSingleton<GuruService>();

builder.Services.Configure<MapelDatabaseSettings>(
    builder.Configuration.GetSection("MapelDatabase"));

builder.Services.AddSingleton<MapelService>();

builder.Services.Configure<JadwalDatabaseSettings>(
    builder.Configuration.GetSection("JadwalGuruDatabase"));

builder.Services.AddSingleton<JadwalGuruService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
