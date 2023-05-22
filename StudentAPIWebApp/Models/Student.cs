using System.ComponentModel.DataAnnotations;

namespace StudentAPIWebApp.Models
{
    public class Student
    {
        public Student()
        {
            Grades = new List<Grade>();
        }
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [Display(Name = "Прізвище")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [Display(Name = "Ім'я")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [Display(Name = "По-батькові")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [Display(Name = "Номер студентського")]
        public int StudentNumber { get; set; }

        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [Display(Name = "Курс")]
        public int Course { get; set; }

        [Display(Name = "Кафедра")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [Display(Name = "Номер групи")]
        public string Group { get; set; }

        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [Display(Name = "Спеціальність")]
        public string Specialty { get; set; }
        
        public virtual ICollection<Grade> Grades { get; set; }
    }
}
