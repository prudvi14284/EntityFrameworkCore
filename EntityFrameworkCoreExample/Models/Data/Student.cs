using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCoreExample.Models.Data
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        //One-To-One relationship
        public StudentAddress StudentAddress { get; set; }

        [NotMapped]
        public string NotMapped { get; set;}
    }
}
