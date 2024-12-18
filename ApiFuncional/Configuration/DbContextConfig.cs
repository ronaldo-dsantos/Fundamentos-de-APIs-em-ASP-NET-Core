using ApiFuncional.Data;
using Microsoft.EntityFrameworkCore;


namespace ApiFuncional.Configuration
{
    // Configurações de Banco de dados
    public static class DbContextConfig
    {
        public static WebApplicationBuilder AddDbContextConfig(this WebApplicationBuilder builder)
        {
            // Adicionando a conexão com o banco de dados
            builder.Services.AddDbContext<ApiDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            return builder;
        }
    }
}
