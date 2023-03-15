using EntityFrameworkCoreExample.Models.Data;

namespace EntityFrameworkCoreExample.Models
{
    public class Category
    {
        public int Id { get; set; }
        
        public string? Name { get; set; }

        //One-To-Many relationship
        public ICollection<Product> Products { get; set; }
    }
}
