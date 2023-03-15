using EntityFrameworkCoreExample.Models;
using EntityFrameworkCoreExample.Models.Data;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkCoreExample.Controllers
{
    public class CategoryController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        public CategoryController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objectCategory = _databaseContext.Category;
            return View(objectCategory);
        }
        
        //Get Create
        public IActionResult Create()
        {
            return View();
        }

        //Post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _databaseContext.Category.Add(obj);
                    _databaseContext.SaveChanges(); //For reflectioin change to the database
                    return RedirectToAction("Index");
                }
            }
            catch(Exception ex)
            {
                return Content(ex.Message);
            }
            return View(obj);
        }

        //Get Edit
        public IActionResult Update(int? id) 
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _databaseContext.Category.Find(id);
            if(categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        //Post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Category obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _databaseContext.Category.Update(obj);
                    _databaseContext.SaveChanges(); //For reflectioin change to the database
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
            return View();
        }

        public IActionResult GetById(int id)
        {
            var category = _databaseContext.Category.Find(id);
            return Json(category);
        }

        public IActionResult GetAll(int id)
        {
            var categories = _databaseContext.Category.ToList();
            return Json(categories);
        }

        //Get Delete
        public IActionResult Delete(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _databaseContext.Category.Find(id);
            if(categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        //Post Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int id)
        {
            try
            {
                var category = _databaseContext.Category.Find(id);
                if (category == null)
                {
                    return NotFound();
                }
                else
                {
                    _databaseContext.Category.Remove(category);
                    _databaseContext.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IActionResult GetProduct()
        {
            var products = (from p in _databaseContext.Product
                            join c in _databaseContext
                            on p.CategoryId equals c.Id
                            select new Product
                            {
                                Id = p.Id,
                                ProductName = p.ProductName,
                                CategoryId = p.CategoryId,
                                Cost = p.Cost,
                                CategoryName = p.CategoryName,
                            }).ToList();
            return View(products);
                            
        }
    }
}
