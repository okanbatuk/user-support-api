using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using TicketSupportAPI.Extensions;
using TicketSupport.Application.Common.Helpers;
using TicketSupport.Application.Common.Interfaces;

Env.Load();
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddSingleton<IApiResponseHelper, ApiResponseHelper>();

var app = builder.Build();


// app.UseHttpsRedirection();
app.MapControllers();
app.Run();