using ApiFuncional.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApiFuncional.Data
{
    public class ApiDbContext : IdentityDbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) // Criando um construtor passando um DbContextOption para que possamos configurar os dados de conexão 
        {            
        }
        public DbSet<Produto> Produtos { get; set; }
    }
}
