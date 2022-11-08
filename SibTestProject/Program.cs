using Microsoft.EntityFrameworkCore;
using SibTestProjectDB;
using System.Reflection;
using SibTestProjectDB.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SibTestProjectDB.Commands.Users.Get.UserList;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Context>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("Sqlite"));
});
builder.Services.AddScoped<IUserContext, Context>();
builder.Services.AddScoped<IMyObjectContext, Context>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<Context>();
    db.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
app.UseHsts();



app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
using (var scope = app.Services.CreateScope())
{
    var service = scope.ServiceProvider;
    try
    {
        var cintext = service.GetRequiredService<Context>();
    }
    catch (Exception exception)
    {
        Console.WriteLine(exception);
    }
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
