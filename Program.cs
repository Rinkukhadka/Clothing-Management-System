using ProductManagementSystem.Services;
using ProductManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//register services


//To use DB
builder.Services.AddScoped<IproductRepository, DBCrud>();

builder.Services.AddScoped<IFileUpload, FileUpload>();


builder.Services.AddDbContext<ProductContext>(options => options.UseSqlServer("Server=DESKTOP-AQCP1HL\\SQLEXPRESS;Database=CCAD9Product;TrustServerCertificate = true;Trusted_Connection=true;MultipleActiveResultSets=True"));

builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Lockout.MaxFailedAccessAttempts = 5;
}).AddEntityFrameworkStores<UserContext>();

builder.Services.AddDbContext<UserContext>(options => options.UseSqlServer("Server=DESKTOP-AQCP1HL\\SQLEXPRESS;Database=CCAD9ProductUsers;TrustServerCertificate = true;Trusted_Connection=true;MultipleActiveResultSets=True"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

using(var scope=app.Services.CreateScope())
{
    var dbcontext = scope.ServiceProvider.GetRequiredService<ProductContext>();
    dbcontext.Database.EnsureCreated(); // creating DB
    var userdbcontext = scope.ServiceProvider.GetRequiredService<UserContext>();
    userdbcontext.Database.EnsureCreated(); // creating DB
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
