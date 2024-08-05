using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PasteBin.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connStarKey = "DevDb";
builder.Services.AddDbContext<PasteBinContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString(connStarKey) ?? throw new InvalidOperationException($"Connection String '{connStarKey}' not found.")));

builder.Services.AddControllers();
builder.Services.AddCors();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseCors(a => a.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

app.UseAuthorization();

app.MapControllers();

app.Run();
