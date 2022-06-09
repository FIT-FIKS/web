using Microsoft.EntityFrameworkCore;

namespace Fiks.Data;

public class FiksDbContext : DbContext
{
    public FiksDbContext(DbContextOptions<FiksDbContext> options) : base(options) { }

    public DbSet<Models.Season> Season { get; set; }

    public DbSet<Models.School> School { get; set; }

    protected override void OnModelCreating(Microsoft.EntityFrameworkCore.ModelBuilder b) {
        b.Entity<Models.School>(o => {
            o.Property(v => v.Validated)
                .HasDefaultValue(false);
        });

        base.OnModelCreating(b);
    }
}