// --- 1. BUILDER SETUP ---
using Microsoft.EntityFrameworkCore;
using ResturanrtManagement.ApplicationDbContext;
using ResturanrtManagement.Repositories.Implementation;
using ResturanrtManagement.Repositories.Interfaces;
using ResturanrtManagement.Services.Implementation;
using ResturanrtManagement.Services.Interfaces;


var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

// --- 2. DATABASE CONNECTION (Step 1 & 2) ---
// IMPORTANT: You must configure a connection string named 'DefaultConnection' 
// in your appsettings.json file for this to work.
services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

// --- 3. ARCHITECTURE SETUP (Step 3 & 4) ---

// Register the Generic Repository Implementation (DLL/Data Access Layer)
services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

// Register the specific Service Implementations (BLL/Business Logic Layer)
services.AddScoped<IMenuItemService, MenuItemService>();
services.AddScoped<IOrderItemService, OrderItemService>();
services.AddScoped<ITableService, TableService>();
services.AddScoped<IOrderService, OrderService>();
// --- 4. MVC & OTHER SERVICES ---
services.AddControllersWithViews();

// --- 5. APP BUILD AND RUN ---
var app = builder.Build();

// Configure the HTTP request pipeline...

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Menu}/{action=Index}/{id?}");

app.Run();
