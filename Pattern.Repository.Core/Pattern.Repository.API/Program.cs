using Microsoft.EntityFrameworkCore;
using Pattern.Repository.API.Services;
using Pattern.Repository.Core.BaseRepository;
using Pattern.Repository.Core.Context;
using Pattern.Repository.Core.Models;
using Pattern.Repository.Core.ObjectRepository;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin", policyBuilder =>
    {
        policyBuilder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
    });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ProductService>();

builder.Services.AddDbContext<OracleDbContext>(options =>
    options.UseOracle(configuration.GetConnectionString("OracleConnection")));
builder.Services.AddDbContext<SqlServerDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("SqlServerConnection")));

builder.Services.AddScoped<IBaseRepository<CategoryDTO>, CategoryRepository>();
builder.Services.AddScoped<IBaseRepository<ProductDTO>, ProductRepository>();

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
