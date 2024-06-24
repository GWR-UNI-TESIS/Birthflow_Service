using Birthflow_Application;
using Birthflow_Infraestructure;
using Birthflow_Service.Infraestructure.DbContexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


var BirthContext = builder.Configuration.GetConnectionString("localDB");

builder.Services.AddDbContext<BirthflowDbContext>(x => x.UseSqlServer(BirthContext));

builder.Services.AddHttpContextAccessor();

// Add services
builder.Services.AddServices();

// Add Repositories
builder.Services.AddRepositories();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
