using BootcampAPIWithDB.Data;
using BootcampAPIWithDB.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//REPOSITORY IMPLEMENT
builder.Services.AddTransient<IStudentRepository, StudentRepository>();

//DB CONTEXT IMPLEMENT
builder.Services.AddDbContext<BootcampContext>(options => options.UseLazyLoadingProxies(false).UseNpgsql("Host=localhost;Database=Bootcamp;Username=postgres;Password=nova"));

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
