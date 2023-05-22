using System.ComponentModel.DataAnnotations;

namespace StudentAPIWebApp.Models
{
    public class Subject
    {
        public Subject() 
        {
            Grades = new List<Grade>();
        }

        public int Id { get; set; }


        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [Display(Name = "Назва предмету")]
        public string SubjectName { get; set; }

        public virtual ICollection<Grade> Grades { get; set; }
    }
}
