using JWT_Authentication_Authorization_Roles_RefreshToken_Demo.Data;
using JWT_Authentication_Authorization_Roles_RefreshToken_Demo.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Registered our DB Context for Sqlite inbuilt no need to install sqlserver and ssms
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite("Data Source=User_Database.db; Cache=Shared; Pooling=true");
});

// Adding or Registering only JWT Authentication not Roles(Authorization) that it will get from our appsettings.json file
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["JWTTokenSettings:Issuer"],
            ValidateAudience = true,
            ValidAudience = builder.Configuration["JWTTokenSettings:Audience"],
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["JWTTokenSettings:Token"]!)),
            ValidateIssuerSigningKey = true
        };
    });

// Resgistering Here our Services
builder.Services.AddScoped<IAuthService, AuthService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
