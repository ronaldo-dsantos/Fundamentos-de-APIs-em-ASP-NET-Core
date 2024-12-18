using ApiFuncional.Data;
using ApiFuncional.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

// Adicionando suporte a jwt no swagger
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Insira o token JWT desta maneira: Bearer {seu token}",
        Name = "Authorization",
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

// Adicionando a conex�o com o banco de dados
builder.Services.AddDbContext<ApiDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Adicionando o Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApiDbContext>();

// Pegando o token e gerando a chave encodada
var JwtSettingsSection = builder.Configuration.GetSection("JwtSettings"); // Pegando os dados de configura��o do token no arquivo appsettings.json
builder.Services.Configure<JwtSettings>(JwtSettingsSection); // Populando o modelo JwtSettings com as configura��es do token no momento em que rodar a aplica��o

var JwtSettings = JwtSettingsSection.Get<JwtSettings>(); // Pegando uma inst�ncia da classe JwtSettings populada
var key = Encoding.ASCII.GetBytes(JwtSettings.Segredo); // Criando uma key encodada do nosso segredo

// Adicionando a autentica��o
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; // Definindo que o esquema de autentica��o padr�o para JWT
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; // Desafio para verificar se o token � v�lido
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = true; // Informando que trabalharemos dentro do HTTPS para aumentar a seguran�a
    options.SaveToken = true; // Permitindo que o token seja salvo ap�s uma autoriza��o realizada com sucesso
    options.TokenValidationParameters = new TokenValidationParameters 
    {
        IssuerSigningKey = new SymmetricSecurityKey(key), // Gerando a key
        ValidateIssuer = true, // Validar emissor? sim
        ValidateAudience = true, // Validar audiencia? sim
        ValidAudience = JwtSettings.Audiencia, // Informando qual � a audi�ncia v�lida
        ValidIssuer = JwtSettings.Emissor // Informando qual � o emissor v�lido
    };
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Adicionando a autentica��o de usu�rio em nossa API
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
