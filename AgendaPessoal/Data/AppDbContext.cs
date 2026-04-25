using Microsoft.EntityFrameworkCore;
using AgendaPessoal.Domain;

namespace AgendaPessoal.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
      : base(options) { }

        public DbSet<Person> Persons { get; set; }
    }
}
