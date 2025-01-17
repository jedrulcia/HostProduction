using HostProduction.Configurations;
using HostProduction.Contracts;
using HostProduction.Data;
using HostProduction.Repositories;
using HostProduction.Web.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
	.AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddScoped<IEquipmentPlacementContractsRepository, EquipmentPlacementContractsRepository>();
builder.Services.AddScoped<IProductionFacilityRepository, ProductionFacilityRepository>();
builder.Services.AddScoped<IProcessEquipmentTypeRepository, ProcessEquipmentTypeRepository>();

string sendGridConnectionString = builder.Configuration.GetConnectionString("SendGridConnectionString");
string sendFromEmailAddress = builder.Configuration.GetValue<string>("SendFromEmail");
string sendToEmailAddress = builder.Configuration.GetValue<string>("SendToEmail");
builder.Services.AddTransient<IEmailSender, EmailSender>(provider => new EmailSender(sendGridConnectionString, sendFromEmailAddress, sendToEmailAddress));

builder.Services.AddAutoMapper(typeof(MapperConfig));

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
