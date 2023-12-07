using acervoLivros.Models;
using Microsoft.EntityFrameworkCore;

namespace acervoLivros.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<AcervoModel> Livros { get; set; }
    }
}