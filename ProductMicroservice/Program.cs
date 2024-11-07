using Microsoft.EntityFrameworkCore;
using ProductMicroservice.ApplicationCore.Contracts.IRepositoreis;
using ProductMicroservice.ApplicationCore.Contracts.IServices;
using ProductMicroservice.Infrastructure.Data;
using ProductMicroservice.Infrastructure.Repositories;
using ProductMicroservice.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Configure database connection
builder.Services.AddDbContext<ProductDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("ProductServiceDB")
     ?? builder.Configuration["ConnectionStrings__ProductServiceDB"]
    );
});

// Configure AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

// Register repositories
builder.Services.AddScoped<ICategoryRepositoryAsync, CategoryRepositoryAsync>();
builder.Services.AddScoped<ICategoryVariationRepositoryAsync, CategoryVariationRepositoryAsync>();
builder.Services.AddScoped<IProductRepositoryAsync, ProductRepositoryAsync>();
builder.Services.AddScoped<IProductVariationRepositoryAsync, ProductVariationRepositoryAsync>();
builder.Services.AddScoped<IVariationValueRepositoryAsync, VariationValueRepositoryAsync>();

// Register services
builder.Services.AddScoped<ICategoryServiceAsync, CategoryServiceAsync>();
builder.Services.AddScoped<ICategoryVariationServiceAsync, CategoryVariationServiceAsync>();
builder.Services.AddScoped<IProductServiceAsync, ProductServiceAsync>();
builder.Services.AddScoped<IProductVariationServiceAsync, ProductVariationServiceAsync>();
builder.Services.AddScoped<IVariationValueServiceAsync, VariationValueServiceAsync>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Product API V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
