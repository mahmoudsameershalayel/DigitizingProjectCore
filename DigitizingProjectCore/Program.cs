using DigitizingProjectCore;
using DigitizingProjectCore.AutoMapper;
using DigitizingProjectCore.Data;
using DigitizingProjectCore.Models;
using DigitizingProjectCore.Resources;
using DigitizingProjectCore.Services.AboutUsService;
using DigitizingProjectCore.Services.Auth;
using DigitizingProjectCore.Services.BrandService;
using DigitizingProjectCore.Services.CategoryNewsService;
using DigitizingProjectCore.Services.CategoryProductService;
using DigitizingProjectCore.Services.CategoryServiceService;
using DigitizingProjectCore.Services.CityService;
using DigitizingProjectCore.Services.ConfigurationService;
using DigitizingProjectCore.Services.ContactUsService;
using DigitizingProjectCore.Services.DistributorService;
using DigitizingProjectCore.Services.HomeBageService;
using DigitizingProjectCore.Services.JobApplicationService;
using DigitizingProjectCore.Services.JobService;
using DigitizingProjectCore.Services.LocalizationService;
using DigitizingProjectCore.Services.NewsService;
using DigitizingProjectCore.Services.PageService;
using DigitizingProjectCore.Services.PhotoGalleryService;
using DigitizingProjectCore.Services.ProductService;
using DigitizingProjectCore.Services.ServiceService;
using DigitizingProjectCore.Services.SettingService;
using DigitizingProjectCore.Services.SolutionService;
using DigitizingProjectCore.Services.UserService;
using DigitizingProjectCore.ViewComponents;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using System.Globalization;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("FLConnection") ?? throw new InvalidOperationException("Connection string 'FLConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddSingleton<LocalizationService>();
builder.Services.AddLocalization(Options => Options.ResourcesPath = "Resources");
builder.Services.AddMvc()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization(Options =>
    {
        Options.DataAnnotationLocalizerProvider = (type, factory) =>
        {
            var assemplyName = new AssemblyName(typeof(ApplicationResource).GetTypeInfo().Assembly.FullName!);
            return factory.Create("ApplicationResource", assemplyName.Name!);
        };
    });
    
builder.Services.Configure<RequestLocalizationOptions>(options =>
{

    var supportedCulture = new[]
   {
        new CultureInfo("en"),
        new CultureInfo("ar"),

    };

    options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture(culture: "en", uiCulture: "en");
    options.SupportedCultures = supportedCulture;
    options.SupportedUICultures = supportedCulture;

});



builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredUniqueChars = 1;
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 1;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.SignIn.RequireConfirmedAccount = false;
})
  .AddEntityFrameworkStores<ApplicationDbContext>()
  .AddDefaultUI()
  .AddDefaultTokenProviders();

builder.Services.AddControllersWithViews();
builder.Services.ConfigureApplicationCookie(Options =>
{
    Options.LoginPath = "/Auth/Login";
    Options.AccessDeniedPath = "/Denied";
}
);

builder.Services.AddAutoMapper(typeof(ApplicationProfile).Assembly);
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ISolutionService, SolutionService>();
builder.Services.AddScoped<ICategoryProductService, CategoryProductService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<IDistributorService, DistributorService>();
builder.Services.AddScoped<ICategoryServiceService, CategoryServiceService>();
builder.Services.AddScoped<IServiceService, ServiceService>();
builder.Services.AddScoped<ICategoryNewsService, CategoryNewsService>();
builder.Services.AddScoped<INewsService, NewsService>();
builder.Services.AddScoped<IJobService, JobService>();
builder.Services.AddScoped<IJobApplicationService, JobApplicationService>();
builder.Services.AddScoped<IPhotoGalleryService, PhotoGalleryService>();
builder.Services.AddScoped<IAboutUsService, AboutUsService>();
builder.Services.AddScoped<IPageService, PageService>();
builder.Services.AddScoped<ISettingService, SettingService>();
builder.Services.AddScoped<IContactUsService, ContactUsService>();
builder.Services.AddScoped<IConfigurationService, ConfigurationService>();
builder.Services.AddScoped<IHomePageService, HomePageService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<LayoutViewComponent>();

//Set Context DB in Session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.Cookie.Name = "aspNetCore";
    options.IdleTimeout = TimeSpan.FromSeconds(5);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});



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
app.UseSession();

var locOptions = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(locOptions.Value);


app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "MyArea",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
