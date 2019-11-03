using Microsoft.EntityFrameworkCore;
using Crud_json;

namespace Crud_json.Models
{
    public class RolesContext : DbContext
    {
            public DbSet <RolesModel> Rolmc { get; set;}
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=apps;Username=postgres;Password=Maddox");
        }
         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
            .HasDefaultSchema("public")
            .Entity<RolesModel>()
            .ToTable("roles")
            .HasKey(r => r.idroles);
        } 

    }
}
