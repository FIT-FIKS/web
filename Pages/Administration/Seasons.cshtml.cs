using Fiks.Data;
using Fiks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Fiks.Pages.Administration;

public class SeasonsModel : PageModel
{
    /// Instance of object that can be used for logging
    private readonly ILogger logger;
    /// Database context, can be used for querying and modifications
    private readonly FiksDbContext context;

    public SeasonsModel(ILogger<SeasonsModel> logger, FiksDbContext context)
    {
        this.logger = logger;
        this.context = context;
    }

    /// Object that is sent from frontend and generated from filling a form.
    [BindProperty]
    public Season Season { get; set; }
    /// List of objects that are passed to frontend and filled into a table.
    /// User can list through them and display their detail (such as rounds in given season)
    public IList<Season> Seasons;
    
    /// Return all seasons in database
    public IActionResult OnGet()
    {
        Seasons = context.Season.ToList();
        return Page();
    }

    /// User sent a post request. Verify that it contains a valid Season object, and if so, insert
    /// it into database.
    public IActionResult OnPost()
    {
        if (!ModelState.IsValid) return OnGet();
        
        var ent = context.Season.Add(Season);
        context.SaveChanges();

        return RedirectToPage("./Seasons", ent.Entity.Id);
    }
}