using Microsoft.EntityFrameworkCore;

namespace CourseService.Model
{
    public class CourseDbContext(DbContextOptions<CourseDbContext>options):DbContext(options)
    {

      public  DbSet<Course> Courses { get; set; }
    }
}
