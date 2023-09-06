using Exercice02.Data;
using Exercice02.Models;
using Exercice02.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Faire le commentaire ci dessous pour utiliser la FakeTodo
builder.Services.AddScoped<IRepository<Todo>, TodoRepository>();

// Retirer le commentaire ci dessous pour utiliser la FakeTodo
//builder.Services.AddSingleton<IRepository<Monkey>, FakeDbMonkey>();

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Todo}/{action=Index}/{id?}");

app.Run();
