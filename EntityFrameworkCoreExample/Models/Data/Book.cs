namespace EntityFrameworkCoreExample.Models.Data
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public ICollection<Genre> Genres { get; set; }
    }
}
