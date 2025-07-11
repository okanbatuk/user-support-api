using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using TicketSupportAPI.Extensions;


Env.Load();
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddApplicationServices();

var app = builder.Build();


// app.UseHttpsRedirection();
app.MapControllers();
app.Run();