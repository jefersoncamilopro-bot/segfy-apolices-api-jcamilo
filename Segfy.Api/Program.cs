using Microsoft.EntityFrameworkCore;
using Segfy.Application.Interfaces;
using Segfy.Application.Services;
using Segfy.Infrastructure.Data;
using Segfy.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite("Data Source=segfy.db");
});

builder.Services.AddScoped<IApoliceRepository, ApoliceRepository>();
builder.Services.AddScoped<IApoliceService, ApoliceService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapControllers();

app.Run();