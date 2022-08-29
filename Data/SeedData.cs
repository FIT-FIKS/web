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

            var season1 = new Season
            {
                Title = "2021/2022",
                Description = "Ročník 2021/2022",
                ID = 1
            };

            var season2 = new Season
            {
                Title = "2022/2023",
                Description = "Ročník 2022/2023", 
                ID = 2
            };


            context.Season.AddRange(
                season1,
                season2  
            );

            var round1 = new Round
            {
                Id =                    0,
                Title =                 "Hledání kočkoholek",
                Descrption =            "Hledání soptíka v sukni s ouškama",
                Penaliazation =         50,
                PenalizationStart =     DateTime.Now.AddMinutes(1),
                OpenFrom =              DateTime.Now.AddSeconds(30),
                OpenTo =                DateTime.Now.AddMinutes(1).AddSeconds(30),
                Season = season1
            };

            var round2 = new Round
            {
                Id =                    0,
                Title =                 "Hledání kočkoholek, část druhá",
                Descrption =            "Hledání modexe v sukni s ouškama",
                Penaliazation =         50,
                PenalizationStart =     DateTime.Now.AddMinutes(1),
                OpenFrom =              DateTime.Now.AddSeconds(30),
                OpenTo =                DateTime.Now.AddMinutes(1).AddSeconds(30),
                Season =                season1
            };

            var round3 = new Round
            {
                Id =                    0,
                Title =                 "Hledání kočkokluka",
                Descrption =            "Hledá se BitNinja",
                Penaliazation =         50,
                PenalizationStart =     DateTime.Now.AddMinutes(1),
                OpenFrom =              DateTime.Now.AddSeconds(30),
                OpenTo =                DateTime.Now.AddMinutes(1).AddSeconds(30),
                Season =                season2
            };

            context.SaveChanges();
        }
    }
}