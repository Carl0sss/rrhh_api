using Microsoft.EntityFrameworkCore;
using rrhh_api.Models;

namespace rrhh_api.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) {}

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity => { entity.HasIndex(e => e.CodUsuario).IsUnique(); });
        }
    }
}
