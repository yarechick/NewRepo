using Krispy.AccessData.Data;
using Krispy.AccessData.Data.Initializer;
using Krispy.AccessData.Data.Initializer.Initializer;
using Krispy.AccessData.Data.Repository;
using Krispy.AccessData.Data.Repository.IRepository;
using Krispy.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Data;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

//Agregar otros servicios
builder.Services.AddScoped<IContent, Content>();
builder.Services.AddAutoMapper(typeof(Mappers));

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
builder.Services.AddTransient<IInitializerDb, InitializerDb>();



//Authentication 
var key = builder.Configuration.GetValue<string>("ApiSetting:KeyApi");
var urlClient = builder.Configuration.GetValue<string>("ApiSetting:UrlApi");
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddAuthorization();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        BearerFormat = "JWT",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        Description = "Enter your JWT Access Token",
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    options.AddSecurityDefinition("Bearer", jwtSecurityScheme);
    options.AddSecurityRequirement(new OpenApiSecurityRequirement {
        { jwtSecurityScheme, Array.Empty<string>() }
    });
});



// Agregar servicios CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowVueApp",
    builder => builder
    .WithOrigins(urlClient) 
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials());
});


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var inicializerDb = scope.ServiceProvider.GetRequiredService<IInitializerDb>();
    inicializerDb.MigrateAndSeed();
}

// Usar CORS
app.UseCors("AllowVueApp");

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
