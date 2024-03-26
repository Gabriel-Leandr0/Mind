using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Security.Cryptography;
using System.Text;
using Mind.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

//Inicia a conexão com o banco de dados
builder.Services.AddDbContext<MindDbContext>(options =>
    options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("MindConnection")));

// auto mapper serve para mapear um objeto para outro objeto
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// NewtonsoftJson serve para resolver problemas de referência cíclica (looping infinito)
// recebe um objeto e transforma em um json
builder.Services.AddControllers().AddNewtonsoftJson();

//Configuração do JWT
var jwtHashKeyBase64 = builder.Configuration["Auth:JwtHashKey"];
var encryptionKeyBase64 = builder.Configuration["Auth:EncryptionKey"];

var jwtHashKey = Convert.FromBase64String(jwtHashKeyBase64);
var encryptionKey = Convert.FromBase64String(encryptionKeyBase64);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(bearer =>
    {
        // Somente deve ser falso em processo de Desenvolvimento.
        bearer.RequireHttpsMetadata = false;
        bearer.SaveToken = true;
        bearer.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(jwtHashKey),
            ValidateIssuer = true,
            ValidateAudience = true,
            ClockSkew = TimeSpan.Zero // Remove o clock skew para evitar problemas com a validação do token.
        };
    });


// Adicione os serviços de controle
builder.Services.AddControllers();

//Injeção de dependência
DependencyInjection.AddServices(builder.Services, builder.Configuration);

// Configuração do Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Mind API", Version = "v1" });
});

var app = builder.Build();

// Habilitar o Swagger e a UI Swagger


app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mind API V1");
});

// Configuração do middleware e roteamento.
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
