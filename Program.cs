using EcomerceWebAPIs.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EcomerceWebApisDbcontext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("EcomerceWebAPIsDBcs")));

// Inside the ConfigureServices method
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false, // Set to true if you want to validate the server
            ValidateAudience = false, // Set to true if you want to validate the audience
            ValidateLifetime = true, // Validate the token's lifetime
            ValidateIssuerSigningKey = true, // Validate the signing key
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("bd972db7de14db84d7384731760dcec33f618138b7804d0ee6926d452d376981")) // Set your secret key here
        };
    });
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:5173") // Allow only this origin can be adjusted as needed
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});




var app = builder.Build();
// And then in the middleware pipeline:
app.UseCors("AllowSpecificOrigin");
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
