using AutoMapper;
using BtkAkademiAi.WebApi.Context;
using BtkAkademiAi.WebApi.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BlogAIContext>();
builder.Services.AddAutoMapper(cfg => { }, typeof(Program).Assembly);

builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<BlogAIContext>();

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
