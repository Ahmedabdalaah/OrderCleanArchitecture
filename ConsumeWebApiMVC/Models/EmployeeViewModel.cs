using System.ComponentModel;

namespace ConsumeWebApiMVC.Models
{
    public class EmployeeViewModel
    {
        [DisplayName("كود الموظف")]
        public int Id { get; set; }
        [DisplayName("اسم الموظف")]
        public string Name { get; set; }
        [DisplayName("ايميل الموظف")]
        public string Email { get; set; }
        [DisplayName("هاتف الموظف")]
        public string Phone { get; set; }
        [DisplayName("عنوان الموظف")]
        public string Address { get; set; }
        [DisplayName(" القسم التابع له")]
        public int CategoryId { get; set; }
    }
}
