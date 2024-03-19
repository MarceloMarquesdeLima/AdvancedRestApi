using AdvancedRestApi.Data;
using AdvancedRestApi.Interfaces;
using AdvancedRestApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<UserDbContext>(option=>option.UseSqlServer(@"Server=localhost,1433;Database=AdvancedRestApi;User Id=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True;"));

builder.Services.AddScoped<IUser, UserService>();

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
