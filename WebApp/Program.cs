using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Radzen;
using System.Text;
using WebApp;
using WebApp.Areas.Identity;
using WebApp.Data;
using WebApp.Models;
using WebApp.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPendaftaranService, PendaftaranService>();
builder.Services.AddScoped<IPersyaratanService,PersyaratanService>();
builder.Services.AddScoped<IInformasiService, InformasiService>();

builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();

var key = Encoding.UTF8.GetBytes(builder.Configuration["AppSettings:Secret"]!);

//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
//}).AddJwtBearer(o =>
//{
//    o.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidIssuer = builder.Configuration["AppSettings:Issuer"],
//        ValidAudience = builder.Configuration["AppSettings:Audience"],
//        IssuerSigningKey = new SymmetricSecurityKey(key),
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        ValidateLifetime = true,
//        ValidateIssuerSigningKey = true
//    };
//});
//builder.Services.AddAuthorization();


//ServiceProviderFactory.CurrentProvider = builder.Services.BuildServiceProvider();


var app = builder.Build();

// Configure the HTTP request pipeline.

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetService<ApplicationDbContext>();
    var userManager = scope.ServiceProvider.GetService<UserManager<ApplicationUser>>();
    dbContext.Database.EnsureCreated();

    if (!dbContext.Roles.Any())
    {
        dbContext.Roles.Add(new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" });
        dbContext.Roles.Add(new IdentityRole { Name = "Pendaftar", NormalizedName = "PENDAFTAR" });
        dbContext.SaveChanges();
    }


   if (!dbContext.Users.Any())
    {
        var user = new ApplicationUser { Name = "Admin", Email = "ocph23.test@gmail.com", UserName = "ocph23.test@gmail.com", EmailConfirmed = true };
        var adminCreated = await userManager.CreateAsync(user, "Sony@77");
        if (adminCreated.Succeeded)
        {
            await userManager.AddToRoleAsync(user, "Admin");
        }
    }
}

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
app.UseMiddleware<JwtMiddleware>();
app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();




public class ServiceProviderFactory
{
    public static IServiceProvider CurrentProvider { get; internal set; }

    public static T resolve<T>()
    {
        return CurrentProvider.GetService<T>();
    }
}