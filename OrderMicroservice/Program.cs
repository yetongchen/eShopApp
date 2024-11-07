using Microsoft.EntityFrameworkCore;
using Order.Infrastructure.Services;
using OrderMicroservice.ApplicationCore.Contracts.IRepositories;
using OrderMicroservice.ApplicationCore.Contracts.IServices;
using OrderMicroservice.Infrastructure.Data;
using OrderMicroservice.Infrastructure.Repositories;
using OrderMicroservice.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// database connection
builder.Services.AddDbContext<OrderDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("OrderServiceDB")
     ?? builder.Configuration["ConnectionStrings__OrderServiceDB"]
    );
});

// AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

// Repositories
builder.Services.AddScoped<IAddressRepositoryAsync, AddressRepositoryAsync>();
builder.Services.AddScoped<ICustomerRepositoryAsync, CustomerRepositoryAsync>();
builder.Services.AddScoped<IOrderDetailRepositoryAsync, OrderDetailRepositoryAsync>();
builder.Services.AddScoped<IOrderRepositoryAsync, OrderRepositoryAsync>();
builder.Services.AddScoped<IPaymentMethodRepositoryAsync, PaymentMethodRepositoryAsync>();
builder.Services.AddScoped<IPaymentTypeRepositoryAsync, PaymentTypeRepositoryAsync>();
builder.Services.AddScoped<IShoppingCartItemRepositoryAsync, ShoppingCartItemRepositoryAsync>();
builder.Services.AddScoped<IShoppingCartRepositoryAsync, ShoppingCartRepositoryAsync>();
builder.Services.AddScoped<IUserAddressRepositoryAsync, UserAddressRepositoryAsync>();

// Services
builder.Services.AddScoped<ICustomerServiceAsync, CustomerServiceAsync>();
builder.Services.AddScoped<IOrderServiceAsync, OrderServiceAsync>();
builder.Services.AddScoped<IPaymentServiceAsync, PaymentServiceAsync>();
builder.Services.AddScoped<IShoppingCartItemServiceAsync, ShoppingCartItemServiceAsync>();
builder.Services.AddScoped<IShoppingCartServiceAsync, ShoppingCartServiceAsync>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Order API V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
