using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Mind.Infrastructure.Data;


var builder = WebApplication.CreateBuilder(args);

//---------------------------------------------------------




//Inicia a conexão com o banco de dados
    //-UseLazyLoadingProxies() serve para carregar os dados relacionados (campos virtuais) de forma preguiçosa
builder.Services.AddDbContext<MindDbContext>(options =>
 options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("MindConnection")));


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
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
