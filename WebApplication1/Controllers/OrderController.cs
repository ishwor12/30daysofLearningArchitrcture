using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ResturanrtManagement.Models;
using ResturanrtManagement.Services.Implementation;
using ResturanrtManagement.Services.Interfaces;

namespace ResturanrtManagement.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _service;
        private readonly ITableService _tableservice;
        private readonly IMenuItemService _menuitemservice;

        public OrderController(IOrderService service ,ITableService tableservice,IMenuItemService menuItemservice)
        {
            _service = service;
            _tableservice = tableservice;
            _menuitemservice = menuItemservice;
        }
        private async Task LoadDropdownData()
        { 
            ViewBag.Tables = new SelectList(await _tableservice.GetAllAsync(), "TableId", "TableNumber");
            ViewBag.MenuItems = await _menuitemservice.GetAllAsync();
      

        }
        public async Task<IActionResult> Index()
        {
            var orders = await _service.GetAllAsync();
            return View(orders);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await LoadDropdownData();
            var model = new Order
            {
                OrderItems = new List<OrderItem> { new OrderItem()}
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Order order)
        {
            // 1. Check if the model (Master) is valid
            if (!ModelState.IsValid)
            {
                await LoadDropdownData();
        
                return View(order);
            }
            try
            {
                // 2. Check if there is at least one Order Item (Detail)
                if (order.OrderItems == null || order.OrderItems.Count == 0)
                {
                    ModelState.AddModelError("OrderItems", "An order must contain at least one menu item.");
                    await LoadDropdownData();
                    return View(order);
                }

                await _service.CreateAsync(order);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                // 4️⃣ Add error to model state
                ModelState.AddModelError("", "Something went wrong while saving the order.");
                // 6️⃣ Return the view WITH the entered model
                return View(order);
            }
        }



        public async Task<IActionResult> Edit(int id)
        {
            await LoadDropdownData(); // Load tables and menu items for the form
            var order = await _service.GetByIdAsync(id);
            if (order == null) return NotFound();
            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Order order)
        {
            if (!ModelState.IsValid)
            {
                await LoadDropdownData();
                return View(order);
            }

            // Your service must handle updating both Order and OrderItems
            await _service.UpdateAsync(order);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
