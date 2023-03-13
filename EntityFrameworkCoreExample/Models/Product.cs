using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCoreExample.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Column(TypeName ="nvarchar(100)")]
        [MinLength(5)]
        [Required]
        public string? ProductName { get; set; }

        [Column(TypeName ="decimal(5,2)")]
        public decimal Cost { get; set; }
        [Column("Category_Id")]
        public int CategoryId { get; set; }
    }
}
