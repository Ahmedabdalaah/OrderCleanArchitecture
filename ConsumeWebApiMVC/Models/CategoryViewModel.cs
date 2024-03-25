using System.ComponentModel;

namespace ConsumeWebApiMVC.Models
{
    public class CategoryViewModel
    {
        [DisplayName("كود القسم")]
        public int Id { get; set; }
        [DisplayName("اسم القسم")]
        public string Name { get; set; }
    }
}
