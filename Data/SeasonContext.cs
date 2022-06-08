using Microsoft.EntityFrameworkCore;

namespace Fiks.Data;

public class SeasonContext : DbContext
{
    public SeasonContext(DbContextOptions<SeasonContext> options) : base(options) { }

    public DbSet<Models.Season> Season { get; set; }
}