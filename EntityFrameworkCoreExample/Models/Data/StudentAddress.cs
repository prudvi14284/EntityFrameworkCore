namespace EntityFrameworkCoreExample.Models.Data
{
    public class StudentAddress
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        //Naming convention for foreing key is ParentTableNameId
        public int StudentId { get; set; }

        //One-To-One relationship
        public Student Student { get; set; }
    }
}
