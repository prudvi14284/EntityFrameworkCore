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
        public IActionResult Add()
        {
            var category = new Category
            {
                Name = "category"
            };
            _databaseContext.Category.Add(category);
            _databaseContext.SaveChanges(); //For reflectioin change to the database
            return View();
        }
    }
}
