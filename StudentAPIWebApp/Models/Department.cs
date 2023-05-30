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


        [Display(Name = "Назва кафедри")]
        public string DepartmentName { get; set; }

        [Display(Name = "Факультет/Інститут")]
        public string Faculty { get; set; }
        public virtual ICollection<Student>? Students { get; set; }
    }
}
