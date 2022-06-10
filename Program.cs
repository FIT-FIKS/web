using Microsoft.EntityFrameworkCore;
using Fiks.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages( );

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<FiksDbContext>(options =>
        options.UseInMemoryDatabase(databaseName: "FIKSTest"));
}
else
{
    // TODO: load database connection string from environmental variable
}

builder.Services.AddIdentityCore<Fiks.Models.User>(o =>
{
    o.Password.RequireDigit = false;
    o.Password.RequireLowercase = false;
    o.Password.RequireNonAlphanumeric = false;
    o.Password.RequireUppercase = false;
    o.Password.RequiredLength = 5;
    o.Password.RequiredUniqueChars = 0;

    /*o.User.AllowedUserNameCharacters =
      "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";*/ // If you want to allow only some chars for username
})
    .AddUserStore<UserStore<Fiks.Models.User, IdentityRole<long>, FiksDbContext, long>>()
    .AddDefaultTokenProviders()
    .AddSignInManager<SignInManager<Fiks.Models.User>>();

builder.Services.AddAuthentication(o =>
{
    o.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
    o.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
    o.DefaultSignInScheme = IdentityConstants.ExternalScheme;
}).AddCookie(IdentityConstants.ApplicationScheme, o =>
{
    o.LogoutPath = new PathString("/Account/Login"); // todo: změnit login path soptíku :)
    o.Events = new Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents()
    {
        OnValidatePrincipal = SecurityStampValidator.ValidatePrincipalAsync
    };
}).AddCookie(IdentityConstants.ExternalScheme, o =>
{
    o.Cookie.Name = IdentityConstants.ExternalScheme;
    o.ExpireTimeSpan = TimeSpan.FromMinutes(5.0);
});

builder.Services.AddScoped<ISecurityStampValidator, SecurityStampValidator<Fiks.Models.User>>();

var app = builder.Build();

// Seed database if empty
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
