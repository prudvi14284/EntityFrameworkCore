using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCoreExample.Models.Data
{
    public class Genre
    {
        [Key]
        public string GenreId { get; set; }
        public string? Name { get; set; }
    }
}
