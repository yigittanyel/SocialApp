using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using serverapp.Models;
using serverapp.Profile;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region ""

builder.Services.AddDbContext<Context>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("cnnstr"));
});

builder.Services.AddIdentity<User, Role>().AddEntityFrameworkStores<Context>();

builder.Services.Configure<IdentityOptions>(opt =>
{
    opt.Password.RequireDigit = true;
    opt.Password.RequireUppercase = true;
    opt.Password.RequiredLength = 5;
    opt.Lockout.MaxFailedAccessAttempts = 5; ;
    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    opt.Lockout.AllowedForNewUsers = true;
    opt.User.RequireUniqueEmail = true;
});

builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuerSigningKey = true, //tokený yazan kiþi
        IssuerSigningKey=new 
        SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration.GetSection("AppSettings:Secret").Value)),
        ValidateIssuer=false,
        ValidateAudience=false
    };
});
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//biz ekledik
app.UseAuthentication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
