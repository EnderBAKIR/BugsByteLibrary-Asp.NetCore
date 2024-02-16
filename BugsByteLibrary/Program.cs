using Core.Layer.IRepositories;
using Core.Layer.IService;
using Core.Layer.IUnitOfWorks;
using Core.Layer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repository.Layer;
using Repository.Layer.Repositories;
using Repository.Layer.UnitOfWorks;
using Service.Layer.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<ICommentRepository , CommentRepository>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IBlogRepository , BlogRepository>();
builder.Services.AddScoped<IBlogService , BlogService>();
builder.Services.AddScoped<IUnitOfWork , UnitOfWork>();
builder.Services.AddScoped<ICategoryRepository , CategoryRepository>();
builder.Services.AddScoped<ICategoryService , CategoryService>();



builder.Services.AddHttpContextAccessor();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<AppDbContext>();

//builder.Services.Configure<IdentityOptions>(opt => //eðer identity serverýn kendi email doðrulama sistemini kullanmak istiyorsak bu kod bloðunu kullanmalýyýz
                                                        //Ama biz kendimiz bir mail doðrulama iþlemi gerçekleþtiricez kendi senaryomuz ve gereksinimlerimize göre yapýcaðýz
//{
//    opt.SignIn.RequireConfirmedEmail = true;
//});

builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});

builder.Services.AddControllersWithViews();

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
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");




app.Run();
