using Microsoft.EntityFrameworkCore;
using OrderCleanArchitecture.Core;
using OrderCleanArchitecture.Infrustructure;
using OrderCleanArchitecture.Infrustructure.Context;
using OrderCleanArchitecture.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add DBContext
builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer(
    builder.Configuration.GetConnectionString("Connect")));
// Dependency Injection
builder.Services.AddInfrustructureDependencies()
                .AddServicesDependencies()
                .AddCoreDependencies();


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
