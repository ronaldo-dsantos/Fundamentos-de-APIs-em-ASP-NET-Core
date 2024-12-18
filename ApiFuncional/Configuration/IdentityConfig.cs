using ApiFuncional.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ApiFuncional.Models;


namespace ApiFuncional.Configuration
{
    // Configurações do Identity
    public static class IdentityConfig
    {
        public static WebApplicationBuilder AddIdentityConfig(this WebApplicationBuilder builder)
        {
            // Adicionando o Identity
            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                            .AddRoles<IdentityRole>()
                            .AddEntityFrameworkStores<ApiDbContext>();

            // Pegando o token e gerando a chave encodada
            var JwtSettingsSection = builder.Configuration.GetSection("JwtSettings"); // Pegando os dados de configuração do token no arquivo appsettings.json
            builder.Services.Configure<JwtSettings>(JwtSettingsSection); // Populando o modelo JwtSettings com as configurações do token no momento em que rodar a aplicação

            var JwtSettings = JwtSettingsSection.Get<JwtSettings>(); // Pegando uma instância da classe JwtSettings populada
            var key = Encoding.ASCII.GetBytes(JwtSettings.Segredo); // Criando uma key encodada do nosso segredo

            // Adicionando a autenticação
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; // Definindo que o esquema de autenticação padrão para JWT
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; // Desafio para verificar se o token é válido
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = true; // Informando que trabalharemos dentro do HTTPS para aumentar a segurança
                options.SaveToken = true; // Permitindo que o token seja salvo após uma autorização realizada com sucesso
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(key), // Gerando a key
                    ValidateIssuer = true, // Validar emissor? sim
                    ValidateAudience = true, // Validar audiencia? sim
                    ValidAudience = JwtSettings.Audiencia, // Informando qual é a audiência válida
                    ValidIssuer = JwtSettings.Emissor // Informando qual é o emissor válido
                };
            });

            return builder;
        }
    }
}
