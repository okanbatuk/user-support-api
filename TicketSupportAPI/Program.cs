using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using TicketSupportAPI.Extensions;
using TicketSupport.Application.Common.Helpers;
using TicketSupport.Application.Common.Interfaces;
using TicketSupport.Application.Common.Mappings;

Env.Load();
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services
  .ConfigureInvalidModelStateResponse()
  .AddValidationServices()
  .AddDatabase(builder.Configuration)
  .AddApplicationServices()
  .AddAutoMapper(typeof(UserMappingProfile));

var app = builder.Build();

app.UseCustomMiddlewares();
// app.UseHttpsRedirection();
app.MapControllers();
app.Run();