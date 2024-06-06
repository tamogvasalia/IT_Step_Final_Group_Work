
using OnlineStore.Core.Entities;
using OnlineStore.Core.Interfaces;
using OnlineBooking.Persistance.Repositories;
using OnlineBooking.Persistance.UniteOfWorkRelated;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using OnlineBooking.Domain.Mapper;
using OnlineBooking.Domain.Interfaces;
using OnlineBooking.Domain.Services;
using IT_Step_Final.Data;
using Microsoft.AspNetCore.Identity.UI.Services;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//inject scopes
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IhotelRepository, HotelRepository>();
builder.Services.AddScoped<IbookingRepository, BookRepository>();
builder.Services.AddScoped<IroomTypeRepository, RoomTypeRepository>();
builder.Services.AddScoped<IUniteOfWork, UniteOfWork>();

builder.Services.AddScoped<IbookingRelate, BookRelatedServices>();
builder.Services.AddScoped<IroomRelatedServices,RoomRelatedServices>();
builder.Services.AddScoped<IUserRelated,UserRelatedServices>();


//inject mapper
builder.Services.AddAutoMapper(typeof(AuttoMapper));

//Added AppDbContext 
builder.Services.AddDbContext<ApplicationDbContext>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

    }
);

builder.Services.AddIdentity<User,IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultUI()
    .AddDefaultTokenProviders();

/*builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "http://localhost:42130",
            ValidAudience = "http://localhost:42130",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("65E255FF-F399-42D4-9C7F-D5D08B0EC285")),
        };
    });*/


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
