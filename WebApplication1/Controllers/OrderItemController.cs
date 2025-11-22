using Microsoft.AspNetCore.Mvc;
using ResturanrtManagement.Models;
using ResturanrtManagement.Services.Interfaces;

namespace ResturanrtManagement.Controllers
{
    public class OrderItemController : Controller
    {
        private readonly IOrderItemService _service;

        public OrderItemController(IOrderItemService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _service.GetAllAsync();
            return View(items);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(OrderItem item)
        {
            if (!ModelState.IsValid) return View(item);

            await _service.CreateAsync(item);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(OrderItem item)
        {
            if (!ModelState.IsValid) return View(item);

            await _service.UpdateAsync(item);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
