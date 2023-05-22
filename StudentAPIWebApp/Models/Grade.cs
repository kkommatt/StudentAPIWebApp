using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace StudentAPIWebApp.Models
{
    public class Grade
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public int SubjectId { get; set; }

        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [Display(Name = "Оцінка")]
        public int GradeValue { get; set; }

        public virtual Student Student { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
