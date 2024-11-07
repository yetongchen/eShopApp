using Microsoft.EntityFrameworkCore;
using ReviewMicroservice.ApplicaitonCore.Contracts.IRepositoreis;
using ReviewMicroservice.ApplicaitonCore.Contracts.IServices;
using ReviewMicroservice.Infrastructure.Data;
using ReviewMicroservice.Infrastructure.Repositories;
using ReviewMicroservice.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Configure database connection
builder.Services.AddDbContext<ReviewDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("ReviewServiceDB")
     ?? builder.Configuration["ConnectionStrings__ReviewServiceDB"]
    );
});

// Configure AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

// Register repositories
builder.Services.AddScoped<IReviewRepositoryAsync, ReviewRepositoryAsync>();

// Register services
builder.Services.AddScoped<IReviewServiceAsync, ReviewServiceAsync>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "CustomerReview API V1");
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();
