using InventoryTrackingSystem.Data;
using InventoryTrackingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InventoryTrackingSystem.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
      
        public ProductController(ApplicationDbContext context)
        {
            _context = context; 
        }

        public async Task<IActionResult> Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            List<Category> categories = _context.Categories.ToList();
            ViewBag.Categories = categories.Select(temp =>
              new SelectListItem() { Text = temp.Name, Value = temp.Id.ToString() }
            );
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            _context.Products.Add(product); 
            return View(product);
        }

        public async Task<IActionResult> Edit(int id)
        {

            List<Category> categories = _context.Categories.ToList();
            ViewBag.Categories = categories.Select(temp =>
              new SelectListItem() { Text = temp.Name, Value = temp.Id.ToString() }
            );

            var product = _context.Products.FirstOrDefault(x => x.Id == id);

            if (product == null) return NotFound();
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            _context.Products.Update(product);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var product =  _context.Products.FirstOrDefault(x => x.Id == id);
            if (product == null) return NotFound();
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product  = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return RedirectToAction("Create", "Product");
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
