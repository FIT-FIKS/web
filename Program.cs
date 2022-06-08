using Microsoft.EntityFrameworkCore;
using Fiks.Data;

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
