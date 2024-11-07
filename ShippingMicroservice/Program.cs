using Microsoft.EntityFrameworkCore;
using ShippingMicroservice.ApplicationCore.Contracts.IRepositoreis;
using ShippingMicroservice.ApplicationCore.Contracts.IServices;
using ShippingMicroservice.Infrastructure.Data;
using ShippingMicroservice.Infrastructure.Repositories;
using ShippingMicroservice.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Configure database connection
builder.Services.AddDbContext<ShipperDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("ShipperServiceDB")
     ?? builder.Configuration["ConnectionStrings__ShipperServiceDB"]
    );
});

// Configure AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

// Register repositories
builder.Services.AddScoped<IShipperRepositoryAsync, ShipperRepositoryAsync>();

// Register services
builder.Services.AddScoped<IShipperServiceAsync, ShipperServiceAsync>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Shipper API V1");
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();
