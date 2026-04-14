using CQRSWebApi.Infrastructure.Database;
using CQRSWebApi.Application.Commands.Dogs.AddDog;
using CQRSWebApi.Application.Commands.Dogs.UpdateDog;
using CQRSWebApi.Application.Queries.Dogs.GetAll;
using CQRSWebApi.Application.Queries.Dogs.GetById;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<MockDatabase>();
builder.Services.AddScoped<GetAllDogsQueryHandler>();
builder.Services.AddScoped<GetDogByIdQueryHandler>();
builder.Services.AddScoped<AddDogCommandHandler>();
builder.Services.AddScoped<UpdateDogByIdCommandHandler>();
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
