using HostProduction.Configurations;
using HostProduction.Contracts;
using HostProduction.Data;
using HostProduction.Repositories;
using HostProduction.Web.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Database configuration
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
	.AddEntityFrameworkStores<ApplicationDbContext>();

// Dependency Injection
builder.Services.AddScoped<IEquipmentPlacementContractsRepository, EquipmentPlacementContractsRepository>();
builder.Services.AddScoped<IProductionFacilityRepository, ProductionFacilityRepository>();
builder.Services.AddScoped<IProcessEquipmentTypeRepository, ProcessEquipmentTypeRepository>();

// Email Sender configuration
string sendGridConnectionString = builder.Configuration.GetConnectionString("SendGridConnectionString");
string sendFromEmailAddress = builder.Configuration.GetValue<string>("SendFromEmail");
builder.Services.AddTransient<IEmailSender, EmailSender>(provider => new EmailSender(sendGridConnectionString, sendFromEmailAddress));

// Automapper
builder.Services.AddAutoMapper(typeof(MapperConfig));

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
