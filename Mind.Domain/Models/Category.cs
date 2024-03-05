namespace Mind.Domain.Models;

public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public DateTime CreatedDt { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }