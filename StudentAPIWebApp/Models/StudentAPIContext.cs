using Microsoft.EntityFrameworkCore;

namespace StudentAPIWebApp.Models
{
    public class StudentAPIContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Grade> Grades { get; set; }

        public StudentAPIContext(DbContextOptions<StudentAPIContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
