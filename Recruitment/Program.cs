using Microsoft.EntityFrameworkCore;
using Recruitment.Common;
using Recruitment.IService.Serivce;
using Recruitment.Services.Service;


IConfigurationRoot Configuration;

var builder = WebApplication.CreateBuilder(args);

DapperConnection.isDevlopment = true;
var config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
Configuration = config.Build();
DapperConnection.connectionString = Configuration.GetConnectionString("Connection");

// Add services to the container.
builder.Services.AddControllersWithViews();


// Dependency Injection
builder.Services.AddScoped<IQualificationService, QualificationService>();
builder.Services.AddScoped<IExperienceService, ExperienceService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<ICreatejobService, CreatejobService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IListofCandidate, ApplicationformService>();



//builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySQL(DapperConnection.connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
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

app.Run();
