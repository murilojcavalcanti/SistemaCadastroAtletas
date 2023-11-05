using back.Authorization;
using back.Data;
using back.Enums;
using back.Models;
using back.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var conString = builder.Configuration.GetConnectionString("conexaoSistema");

builder.Services.AddDbContext<SistemaDbContext>(opts=> opts.UseSqlServer(conString));

builder.Services.AddIdentity<Usuario, IdentityRole>()
    .AddEntityFrameworkStores<SistemaDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//builder.Services.AddSingleton<IAuthorizationHandler>();
builder.Services.AddScoped<UsuarioService>();



// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(opts=>opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddAuthentication(opts =>
{
    opts.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(opts =>
{
    opts.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("D9pPYl57QYjcVsvFCdYdMZ0EkfYOrUgH")),
        ValidateAudience = false,
        ValidateLifetime = false,
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddAuthorization(opts =>
{
    opts.AddPolicy("AdminUsuario", policy =>
    policy.AddRequirements(new TipoUsuario(UsuarioEnum.Admin))
    );
    opts.AddPolicy("Usuario", policy =>
    policy.AddRequirements(new TipoUsuario(UsuarioEnum.User))
    );
});

builder.Services.AddScoped<AuthorizationService>();



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
