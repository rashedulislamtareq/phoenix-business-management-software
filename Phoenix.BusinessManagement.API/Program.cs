using Microsoft.EntityFrameworkCore;
using Phoenix.BusinessManagement.API.ServiceExtensions;
using Phoenix.BusinessManagement.ClientModel.Mapper;
using Phoenix.BusinessManagement.Repository.Context;
using Phoenix.BusinessManagement.Repository.Core;
using Phoenix.BusinessManagement.Service.Services;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    {
        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddServices();

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
