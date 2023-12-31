using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PSIUWeb.Data;
using PSIUWeb.Models;
using PSIUWeb.Data.Ef;
using PSIUWeb.Data.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseSqlServer( 
        builder.Configuration.
            GetConnectionString("PsiuContext") 
    ) 
);

//Scoped services 
//Servi�os que s�o registrados para serem criados 
//a cada requisi��o http

builder.Services.AddScoped<IPacientRepositor, EfPacientRepositor>();

builder.Services.AddIdentity<AppUser, IdentityRole>( 
    options =>
    {
        options.User.RequireUniqueEmail = true;
        options.Password.RequiredLength = 6;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireDigit = false;
        options.SignIn.RequireConfirmedPhoneNumber = false;
        options.Lockout.MaxFailedAccessAttempts = 5;
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
    }
)
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();

// Add services to the container.
builder.Services.AddControllersWithViews();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

SeedData.EnsurePopulated(app);

app.Run();
