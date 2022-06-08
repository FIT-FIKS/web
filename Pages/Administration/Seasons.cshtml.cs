using Fiks.Data;
using Fiks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Fiks.Pages.Administration;

public class SeasonsModel : PageModel
{
    private readonly ILogger logger;
    private readonly SeasonContext context;

    public SeasonsModel(ILogger<SeasonsModel> logger, SeasonContext context)
    {
        this.logger = logger;
        this.context = context;
    }

    [BindProperty]
    public Season Season { get; set; }
    public IList<Season> Seasons;
    
    public IActionResult OnGet()
    {
        Seasons = context.Season.ToList();
        return Page();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid) return OnGet();
        
        var ent = context.Season.Add(Season);
        context.SaveChanges();

        return RedirectToPage("./Seasons", ent.Entity.ID);
    }
}