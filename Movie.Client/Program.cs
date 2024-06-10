using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.Net.Http.Headers;
using Movie.Client.Data;
using Movies.Client.ApiServices;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MovieClientContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MovieClientContext") 
    ?? throw new InvalidOperationException("Connection string 'MovieClientContext' not found.")));
//builder.Services.AddHttpClient("IDPClient", client =>
//{
//    client.BaseAddress = new Uri("https://localhost:5005/");
//    client.DefaultRequestHeaders.Clear();
//    client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
//});
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IMovieApiService, MovieApiService>();
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
})
  .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
 .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, option =>
                {
                    option.Authority = "https://localhost:5005";
    option.ClientId = "movies_mvc_client";
    option.ClientSecret = "secret";
    option.ResponseType = "code";

    option.Scope.Add("openid");
    option.Scope.Add("profile");

    option.SaveTokens = true;
    option.GetClaimsFromUserInfoEndpoint= true;
});
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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
