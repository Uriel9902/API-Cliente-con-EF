using API_Cliente_con_EF.Data;
using API_Cliente_con_EF.Middlewares;
using API_Cliente_con_EF.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSqlServer<AppDbContext>(builder.Configuration.GetConnectionString("Database"));

builder.Services.AddScoped<ClienteService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//Swagger con ApiKey
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Mi API", Version = "v1" });

    // Configurar API Key
    c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
    {
        Description = "Ingrese la API Key en el header 'X-API-KEY'",
        Name = "X-API-KEY",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "ApiKeyScheme"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "ApiKey"
                }
            },
            new string[] {}
        }
    });
});



// Leer la API Key desde appsettings.json
var apiKey = builder.Configuration["ApiKey"];

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Middleware con key para todos los endpoints
app.UseMiddleware<ApiKeyMiddleware>(apiKey);


app.UseAuthorization();

app.MapControllers();

app.Run();
