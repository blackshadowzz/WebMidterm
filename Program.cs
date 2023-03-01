using WebMidterm.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>();

var app = builder.Build();

app.UseStaticFiles();

app.MapDefaultControllerRoute();


app.Run();
