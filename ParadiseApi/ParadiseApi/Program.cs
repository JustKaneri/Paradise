using Microsoft.EntityFrameworkCore;
using ParadiseApi.Data;
using ParadiseApi.Configurations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ParadiseApi.Middleware;
using ParadiseApi.Other;
using Azure.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//pattern Repository
builder.ConnectPaternRepository();

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader().WithExposedHeaders("*");
}));

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddDbContext<LogDataContext>(options => {
    options.UseSqlite(builder.Configuration.GetConnectionString("SqlLiteConnection"));
});

builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig"));

var key = Encoding.ASCII.GetBytes(builder.Configuration.GetSection("JwtConfig:Secret").Value);
var tokenValidationParamers  = new TokenValidationParameters()
{
    ValidateIssuerSigningKey = true,
    IssuerSigningKey = new SymmetricSecurityKey(key),
    ValidateIssuer = false, // for dev
    ValidateAudience = false, // for dev
    ValidateLifetime = true,
    ClockSkew = new TimeSpan(0,3,0)
};

builder.Services.AddAuthentication( options => {

    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(jwt =>
{
    jwt.SaveToken = true;
    jwt.TokenValidationParameters = tokenValidationParamers;

});

builder.Services.AddSingleton(tokenValidationParamers);

builder.Services.AddSwaggerGen(options => SwaggerConfig.AddConfig(options));

builder.Services.AddControllers();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("corsapp");
app.UseMiddleware<GlobalErrorHandlerMiddleware>();
app.UseMiddleware<LoggingMiddleware>();
app.Use(async (context, next) =>
{
    if (ApplicationURL.Url != "")
        ApplicationURL.Url = context.Request.Host.ToString();

    await next.Invoke();
});

app.UseHttpsRedirection();

//app.UseHttpLogging();

app.UseAuthentication();

app.UseAuthorization();

app.UseStaticFiles();

app.MapControllers();

app.Run();

public partial class Program { }