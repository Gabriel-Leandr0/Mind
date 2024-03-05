using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Mind.Application.Interfaces;
using Mind.Application.Services;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

//---------------------------------------------------------



// auto mapper serve para mapear um objeto para outro objeto
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


// NewtonsoftJson serve para resolver problemas de referência cíclica (looping infinito)
// recebe um objeto e transforma em um json
builder.Services.AddControllers().AddNewtonsoftJson();


//---------------------------------------------------------

// Adicione os serviços de controle
builder.Services.AddControllers(); // Adicione esta linha


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
app.UseRouting();
app.MapControllers();

app.Run();
