using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Week_8_SCDLab.Data;
using Week_8_SCDLab.Models;

namespace Week_8_SCDLab.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ProductsController(ApplicationDbContext db) => _db = db;

        // GET: /Products
        public async Task<IActionResult> Index()
        {
            var products = await _db.Products.ToListAsync();
            return View(products);
        }

        // GET: /Products/Create
        public IActionResult Create() => View();

        // POST: /Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (!ModelState.IsValid) return View(product);
            _db.Products.Add(product);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: /Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var product = await _db.Products.FindAsync(id);
            return product == null ? NotFound() : View(product);
        }

        // POST: /Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            if (id != product.ProductId) return BadRequest();
            if (!ModelState.IsValid) return View(product);
            _db.Update(product);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: /Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var product = await _db.Products.FindAsync(id);
            return product == null ? NotFound() : View(product);
        }

        // POST: /Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var p = await _db.Products.FindAsync(id);
            if (p != null)
            {
                _db.Products.Remove(p);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: /Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var product = await _db.Products.FirstOrDefaultAsync(p => p.ProductId == id);
            return product == null ? NotFound() : View(product);
        }
    }
}
