using System.Text;
using BlazorTemplate.Api.Abstractions;
using BlazorTemplate.Api.Context;
using BlazorTemplate.Api.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(policy =>
{
    policy.AddPolicy("CorsPolicy", opt => opt
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod()
        .WithExposedHeaders("X-Pagination"));
});

builder.Services.AddDbContext<CustomerContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("sqlConnection")));

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<CustomerContext>();

var jwtSettings = builder.Configuration.GetSection("JwtSettings"); 
builder.Services.AddAuthentication(opt => 
{ 
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; 
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; 
}).AddJwtBearer(options => 
{ 
    options.TokenValidationParameters = new TokenValidationParameters 
    { 
        ValidateIssuer = true, 
        ValidateAudience = true, 
        ValidateLifetime = true, 
        ValidateIssuerSigningKey = true, 
                    
        ValidIssuer = jwtSettings.GetSection("validIssuer").Value, 
        ValidAudience = jwtSettings.GetSection("validAudience").Value, 
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.GetSection("securityKey").Value)) 
    }; 
});

builder.Services.AddControllers();


var app = builder.Build();

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();