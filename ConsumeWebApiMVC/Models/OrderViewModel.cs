using System.ComponentModel;

namespace ConsumeWebApiMVC.Models
{
    public class OrderViewModel
    {
        [DisplayName("كود الطلب")]
        public int Id { get; set; }
        [DisplayName("اسم الطلب")]
        public string Name { get; set; }
        [DisplayName("وصف الطلب")]
        public string Description { get; set; }
        [DisplayName("  الموظف المسئول")]
        public int EmployeeId { get; set; }
    }
}
