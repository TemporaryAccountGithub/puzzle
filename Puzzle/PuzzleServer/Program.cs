var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseHsts();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "puzzle",
    pattern: "puzzleSolver/{type}",
    defaults: new { controller = "Puzzle", action = "Post" });

app.Run();
