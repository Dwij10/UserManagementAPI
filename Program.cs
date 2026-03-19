using Microsoft.EntityFrameworkCore;
using UserManagementAPI.Data;
using UserManagementAPI.Services;
using UserManagementAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("UserDb"));

builder.Services.AddScoped<UserService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Middleware Order
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseMiddleware<AuthMiddleware>();
app.UseMiddleware<LoggingMiddleware>();

app.MapControllers();

app.Run();
