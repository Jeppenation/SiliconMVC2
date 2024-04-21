using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Infrastructure.Secretes;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();



builder.Services.AddDbContext<AppDataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<FeatureItemRepository>();
builder.Services.AddScoped<FeatureRepository>();
builder.Services.AddScoped<FeatureService>();
builder.Services.AddIdentity<UserEntity, IdentityRole>(x =>
{
    x.SignIn.RequireConfirmedAccount = false;
    x.Password.RequiredLength = 8;
    x.User.RequireUniqueEmail = true;

}).AddEntityFrameworkStores<AppDataContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.Cookie.HttpOnly = true;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    options.ExpireTimeSpan = TimeSpan.FromHours(1);
    options.SlidingExpiration = true;
});

var secret = new ThirdPartySecretes();

builder.Services.AddAuthentication()
    .AddFacebook(x =>
    {
        x.AppId = secret.FacebookAppId;
        x.AppSecret = secret.FacebookAppSecret;
        x.Fields.Add("first_name");
        x.Fields.Add("last_name");
    })
    .AddGoogle(x =>
    {
        x.ClientId = secret.GoogleClientId;
        x.ClientSecret = secret.GoogleClientSecret;
    });


builder.Services.AddHttpClient();




var app = builder.Build();

app.Use(async (context, next) =>
{
    await next();

    if (context.Response.StatusCode == 404)
    {
        context.Request.Path = "/Home/NotFound";
        await next();
    }
});

app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Home}/{id?}");
app.Run();
