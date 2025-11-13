using Microsoft.EntityFrameworkCore;

namespace StudentService.Model
{
    public class EnrollmentDbContext(DbContextOptions<EnrollmentDbContext>options):DbContext(options)
    {

        public DbSet<Enrollment> Enrollments { get; set; }
    }
}
