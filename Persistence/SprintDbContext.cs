using Microsoft.EntityFrameworkCore;
using PrevisaoEcommerce.Models;

namespace PrevisaoEcommerce.Persistence
{
    public class SprintDbContext : DbContext
    {
        public DbSet<LogChat> LogChats { get; set; }
        public DbSet<Cadastro> Cadastros { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<DadosMercado> DadosMercados { get; set; }

        public SprintDbContext(DbContextOptions<SprintDbContext> options) : base(options)
        {

        }
    }
}
