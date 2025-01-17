using HostProduction.Configurations;
using HostProduction.Contracts;
using HostProduction.Data;
using HostProduction.Repositories;
using HostProduction.Web.Services;
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
builder.Services.AddSingleton<IEquipmentPlacementContractsRepository, EquipmentPlacementContractsRepository>();
builder.Services.AddSingleton<IProductionFacilityRepository, ProductionFacilityRepository>();
builder.Services.AddSingleton<IProcessEquipmentTypeRepository, ProcessEquipmentTypeRepository>();

// Email Sender configuration
string sendGridConnectionString = builder.Configuration.GetConnectionString("SendGridConnectionString") ?? throw new InvalidOperationException("Connection string 'SendGridConnectionString' not found.");
string sendFromEmailAddress = builder.Configuration.GetValue<string>("SendFromEmail") ?? throw new InvalidOperationException("Value 'SendFromEmail' not found.");
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
