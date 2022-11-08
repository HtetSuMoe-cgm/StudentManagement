using LoginAndCRUDCoreProject.Data;
using LoginAndCRUDCoreProject.Models;
using LoginAndCRUDCoreProject.Repositories;
using LoginAndCRUDCoreProject.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>options.UseSqlServer(connectionString));

//builder.Services.AddDbContext<StudentdbContext>(options =>options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<User>().AddRoles<IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdministratorRole",
         policy => policy.RequireRole("Admin"));
});

builder.Services.AddScoped<IStudentRepository, StudentRepository>();

builder.Services.AddScoped<IStudentService, StudentService>();

builder.Services.AddScoped<ICourseRepository, CourseRepository>();

builder.Services.AddScoped<ICourseService, CourseService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    IdentityResult result;
    var services = scope.ServiceProvider;
    var _userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
    var _roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var roleExist = await _roleManager.RoleExistsAsync("Admin");
    if (!roleExist)
    {
        result = await _roleManager.CreateAsync(new IdentityRole("Admin"));
        result = await _roleManager.CreateAsync(new IdentityRole("User"));
    }

    var config = scope.ServiceProvider.GetRequiredService<IConfiguration>();
    var admin = await _userManager.FindByEmailAsync(config["AdminCredentials:Email"]);
    if (admin == null)
    {
        admin = new User()
        {
            Name = config["AdminCredentials:Name"],
            UserName = config["AdminCredentials:Email"],
            Email = config["AdminCredentials:Email"],
            EmailConfirmed = true
        };
        var password = config.GetValue<string>("AdminCredentials:Password:Value");
        result = await _userManager.CreateAsync(admin, password);
        if (result.Succeeded)
        {
            result = await _userManager.AddToRoleAsync(admin, "Admin");
            if (!result.Succeeded)
            {
                // todo: process errors
            }
        }
    }
    //SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

//app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
