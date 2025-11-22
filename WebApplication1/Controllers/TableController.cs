using Microsoft.AspNetCore.Mvc;
using ResturanrtManagement.Models;
using ResturanrtManagement.Services.Interfaces;

namespace ResturanrtManagement.Controllers
{
    public class TableController : Controller
    {
        private readonly ITableService _service;

        public TableController(ITableService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var tables = await _service.GetAllAsync();
            return View(tables);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Table table)
        {
            if (!ModelState.IsValid) return View(table);

            await _service.CreateAsync(table);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var table = await _service.GetByIdAsync(id);
            if (table == null) return NotFound();
            return View(table);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Table table)
        {
            if (!ModelState.IsValid) return View(table);

            await _service.UpdateAsync(table);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
