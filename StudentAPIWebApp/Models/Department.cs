using System.ComponentModel.DataAnnotations;

namespace StudentAPIWebApp.Models
{
    public class Department
    {
        public Department() 
        {
            Students = new List<Student>();
        }
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [Display(Name = "Назва кафедри")]
        public string DepartmentName { get; set; }

        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [Display(Name = "Факультет/Інститут")]
        public string Faculty { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
