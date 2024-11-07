using Microsoft.EntityFrameworkCore;
using PromotionMicroservice.ApplicationCore.Contracts.IRepositoreis;
using PromotionMicroservice.ApplicationCore.Contracts.IServices;
using PromotionMicroservice.Infrastructure.Data;
using PromotionMicroservice.Infrastructure.Repositories;
using PromotionMicroservice.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Configure database connection
builder.Services.AddDbContext<PromotionDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("PromotionServiceDB")
     ?? builder.Configuration["ConnectionStrings__PromotionServiceDB"]
    );
});

// Configure AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

// Register repositories
builder.Services.AddScoped<IPromotionRepositoryAsync, PromotionRepositoryAsync>();

// Register services
builder.Services.AddScoped<IPromotionServiceAsync, PromotionServiceAsync>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Promotion API V1");
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();
