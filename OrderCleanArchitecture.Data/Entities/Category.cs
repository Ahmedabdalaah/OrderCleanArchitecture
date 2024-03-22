using System.ComponentModel.DataAnnotations;

namespace OrderCleanArchitecture.Data.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Employee>? Employees { get; set; }

    }
}
