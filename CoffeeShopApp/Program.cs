using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CoffeeShopApp.Data;
using Microsoft.AspNetCore.Identity;
using CoffeeShopApp.Identity;
using CoffeeShopApp.Repository.IRepository;
using CoffeeShopApp.Repository;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<CoffeeShopAppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CoffeeShopAppContext") ?? throw new InvalidOperationException("Connection string 'CoffeeShopAppContext' not found.")));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<CoffeeShopAppContext>();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings.
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 8;
    options.Password.RequiredUniqueChars = 0;
});

builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

var secretMessage = builder.Configuration["SecretMessage"];

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
