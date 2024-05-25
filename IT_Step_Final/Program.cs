
using Final_Project;
using Final_Project.Data;
using OnlineStore.Core.Entities;
using OnlineStore.Core.Interfaces;
using OnlineBooking.Persistance.Repositories;
using OnlineBooking.Persistance.UniteOfWorkRelated;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IhotelRepository, HotelRepository>();
builder.Services.AddScoped<IbookingRepository, BookRepository>();
builder.Services.AddScoped<IroomTypeRepository, RoomTypeRepository>();
builder.Services.AddScoped<IUniteOfWork, UniteOfWork>();

//Added AppDbContext 
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationDbContextConnection"))
);

builder.Services.AddIdentity<User,IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();


builder.Services.AddRazorPages();
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
