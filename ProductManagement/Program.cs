using Microsoft.EntityFrameworkCore;
using ProductManagement;
using ProductManagement.Interfaces;
using ProductManagement.Mapping;
using ProductManagement.Models;
using ProductManagement.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IMapper<ProductManagement.Entities.Product, ProductModel>, ProductMapper>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IMapper<ProductManagement.Entities.Category, CategoryModel>, CategoryMapper>();
builder.Services.AddDbContext<ProductManagementContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("ProductManagementDB")));

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
