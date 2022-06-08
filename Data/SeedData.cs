using Fiks.Models;
using Microsoft.EntityFrameworkCore;
namespace Fiks.Data;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new FiksDbContext(serviceProvider.GetRequiredService<DbContextOptions<FiksDbContext>>()))
        {
            if (context == null || context.Season == null) throw new ArgumentNullException("No season in context");

            if (context.Season.Any()) return; // already seeded
            
            context.Season.AddRange(
                new Season
                {
                    Title = "2021/2022",
                    Description = "Ročník 2021/2022"
                },
                new Season
                {
                    Title = "2022/2023",
                    Description = "Ročník 2022/2023"
                }
            );

            context.SaveChanges();
        }
    }
}