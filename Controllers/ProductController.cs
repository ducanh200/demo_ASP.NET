using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using T2207A_MVC.Entities;
using T2207A_MVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace T2207A_MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly DataContext _context;
        public ProductController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
           List<Product> products = _context.Products.Include(p => p.category).Include(p => p.brand).ToList();
            
            return View(products);
        }

		public IActionResult List()
		{
			return View();
		}

        public IActionResult Create()
        {
            List<Category> categories = _context.Categories.ToList();
            var selectCategories = new List<SelectListItem>();
            foreach (var c in categories)
            {
                selectCategories.Add(new SelectListItem { Text = c.name, Value = c.id.ToString() });
            }
            List<Brand> brands = _context.Brands.ToList();
            var selectBrands = new List<SelectListItem>();
            foreach (var b in brands)
            {
                selectBrands.Add(new SelectListItem { Text = b.name, Value = b.id.ToString() });
            }

            ViewBag.categories = selectCategories;
            ViewBag.brands = selectBrands;
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(new Product
                {
                    name = model.name,
                    price = model.price,
                    description = model.description,
                    category_id = model.category_id,
                    brand_id = model.brand_id
                });
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            List<Category> categories = _context.Categories.ToList();
            var selectCategories = new List<SelectListItem>();
            foreach (var c in categories)
            {
                selectCategories.Add(new SelectListItem { Text = c.name, Value = c.id.ToString() });
            }
           

            List<Brand> brands = _context.Brands.ToList();
            var selectBrands = new List<SelectListItem>();
            foreach (var b in brands)
            {
                selectBrands.Add(new SelectListItem { Text = b.name, Value = b.id.ToString() });
            }
            ViewBag.categories = selectCategories;
            ViewBag.brands = selectBrands;

            return View();
        }
    }
}
