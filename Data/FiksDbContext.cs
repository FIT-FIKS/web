using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Fiks.Data;

public class FiksDbContext : DbContext
{
    public FiksDbContext(DbContextOptions<FiksDbContext> options) : base(options) { }

    public DbSet<Models.Season> Season { get; set; }

    public DbSet<Models.School> School { get; set; }

    public DbSet<Models.Announcement> Announcement { get; set; }

    public DbSet<Models.Correction> Correction { get; set; }

    public DbSet<Models.Submission> Submission { get; set; }

    public DbSet<Models.Task> Task { get; set; }

    public DbSet<Models.Script> Script { get; set; }

    public DbSet<Models.Round> Round { get; set; }

    public DbSet<Models.File> File { get; set; }

    public DbSet<Models.User> User { get; set; }
    
    public DbSet<IdentityUserLogin<long>> UserLogin { get; set; }

    public DbSet<IdentityUserToken<long>> UserToken { get; set; }

    public DbSet<IdentityUserRole<long>> UserRole { get; set; }

    public DbSet<IdentityRole<long>> Role { get; set; }

    protected override void OnModelCreating(Microsoft.EntityFrameworkCore.ModelBuilder b) {
        b.Entity<Models.Submission>(o => {
            o.HasOne(v => v.Task).WithMany(v => v.Submissions).OnDelete(DeleteBehavior.Restrict);
        });
        
        b.Entity<Models.School>(o => {
            o.Property(v => v.Validated)
                .HasDefaultValue(false);
        });

        b.Entity<Models.Correction>(o => {
            o.HasCheckConstraint("CorrectionScoreCheckConstraintLOE100", "Score <= 100");
            o.HasCheckConstraint("CorrectionScoreCheckConstraintMOE0", "Score >= 0");
        });

        b.Entity<Models.File>(o => {
            o.HasIndex(v => v.Guid).HasDatabaseName("FileGuidIndex");
        });
        
        b.Entity<Models.User>(o =>
        {
            o.Ignore(v => v.AccessFailedCount);
            o.Ignore(v => v.LockoutEnabled);
            o.Ignore(v => v.LockoutEnd);
            o.Ignore(v => v.PhoneNumber);
            o.Ignore(v => v.PhoneNumberConfirmed);
            o.Ignore(v => v.TwoFactorEnabled);

            o.HasKey(v => v.Id);
            o.HasIndex(v => v.NormalizedUserName).HasDatabaseName("UserNameIndex");
            o.HasIndex(v => v.NormalizedEmail).HasDatabaseName("EmailIndex");

            o.Property(v => v.ConcurrencyStamp).IsConcurrencyToken();
            o.Property(v => v.UserName).HasMaxLength(80).IsRequired();
            o.Property(v => v.NormalizedUserName).HasMaxLength(80).IsRequired();
            o.Property(v => v.Email).HasMaxLength(80).IsRequired();
            o.Property(v => v.NormalizedEmail).HasMaxLength(80).IsRequired();

            o.HasMany<IdentityUserLogin<long>>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();
            o.HasMany<IdentityUserToken<long>>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();
            o.HasMany<IdentityUserRole<long>>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();
        });

        b.Entity<IdentityRole<long>>(o => {
            o.HasKey(v => v.Id);
            o.Property(v => v.ConcurrencyStamp).IsConcurrencyToken();
            o.Property(v => v.Name).HasMaxLength(80).IsRequired();

            o.HasIndex(v => v.NormalizedName).HasDatabaseName("RoleNameIndex");

            o.HasMany<IdentityUserRole<long>>().WithOne().HasForeignKey(ur => ur.RoleId).IsRequired();
        });

        b.Entity<IdentityUserLogin<long>>()
            .HasKey(v => new { v.LoginProvider, v.ProviderKey });

        b.Entity<IdentityUserToken<long>>()
            .HasKey(v => new { v.UserId, v.LoginProvider, v.Name });

        b.Entity<IdentityUserRole<long>>()
            .HasKey(v => new { v.RoleId, v.UserId });

        base.OnModelCreating(b);
    }
}