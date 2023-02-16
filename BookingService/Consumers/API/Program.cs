using AdaptersSQL;
using AdaptersSQL.Guest;
using AdaptersSQL.Room;
using Application.Guests;
using Application.Guests.DTOs;
using Application.Guests.Ports;
using Application.Guests.Validators;
using Application.Room;
using Application.Room.DTOs;
using Application.Room.Ports;
using Application.Room.Validators;
using Domain.Ports;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Conexao")));

#region IOC
builder.Services.AddScoped<IGuestManager, GuestManager>();
builder.Services.AddScoped<IGuestRepository,GuestRepository>();
builder.Services.AddScoped<IRoomManager, RoomManager>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();


#region IOCValidators
builder.Services.AddTransient<IValidator<GuestDto>, GuestValidator>();
builder.Services.AddTransient<IValidator<RoomDto>, RoomValidators>();
#endregion

#endregion

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
