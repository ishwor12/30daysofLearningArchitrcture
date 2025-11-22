using Microsoft.AspNetCore.Mvc;
using ResturanrtManagement.Models.Entities;
using ResturanrtManagement.Services.Interfaces;
using ResturanrtManagement.Models.Enum;


using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly IMenuItemService _menuService;
        private readonly ITableService _tableService;
        private readonly IOrderService _orderService;

        public HomeController(
            IMenuItemService menuService,
            ITableService tableService,
            IOrderService orderService)
        {
            _menuService = menuService;
            _tableService = tableService;
            _orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            var menu = (await _menuService.GetAllAsync()).ToList();
            var tables = (await _tableService.GetAllAsync()).ToList();
            var orders = (await _orderService.GetAllAsync()).OrderByDescending(o => o.DateTimePlaced).Take(10).ToList();

            var vm = new DashboardModel
            {
                MenuItems = menu,
                Tables = tables,
                RecentOrders = orders,
                TotalOrders = orders.Count,
                TotalRevenue = orders.Sum(o => o.TotalAmount),

                FreeTables = tables.Count(t => t.Status == TableStatus.Free),
                SeatedTables = tables.Count(t => t.Status == TableStatus.Seated),
                ReservedTables = tables.Count(t => t.Status == TableStatus.Reserved),
                NeedsCleaningTables = tables.Count(t => t.Status == TableStatus.NeedsCleaning)
            };

            return View(vm);
        }
    }
}

