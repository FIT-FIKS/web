using Microsoft.EntityFrameworkCore;

namespace Fiks.Data;

public class FiksDbContext : DbContext
{
    public FiksDbContext(DbContextOptions<FiksDbContext> options) : base(options) { }

    public DbSet<Models.Season> Season { get; set; }
}