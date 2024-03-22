using System.ComponentModel.DataAnnotations.Schema;

namespace OrderCleanArchitecture.Data.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }
    }
}
