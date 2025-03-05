using DoAnCuoiKiNhom3BanDienThoaiDiDong_Admin.Controllers;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddHttpClient<HomeController>();
builder.Services.AddHttpClient<BlogsController>();
builder.Services.AddHttpClient<CartDetailsController>();
builder.Services.AddHttpClient<CartsController>();
builder.Services.AddHttpClient<CategoriesController>();
builder.Services.AddHttpClient<ProductController>();
builder.Services.AddHttpClient<UserController>(); 

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "PetStoreCookie";
        options.LoginPath = "/User/Login";
    });

// Register session services
builder.Services.AddSession();

// Register IHttpContextAccessor
builder.Services.AddHttpContextAccessor();

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

// Đặt tuyến đường mặc định là User/Login
// Map controller routes
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
       name: "default",
       pattern: "{controller=User}/{action=Login}/{id?}");

});

app.Run();