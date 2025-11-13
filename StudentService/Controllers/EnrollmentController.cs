using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentService.Model;
using StudentService.Service;
using System.Threading.Tasks;
using StudentService.Service;

namespace StudentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly EnrollmentDbContext _context;

        private readonly StudentClientService _studentClientService;

        public EnrollmentController(EnrollmentDbContext context, StudentClientService service)
        {
            _context = context;
            _studentClientService = service;
        }


        [HttpGet]

        public ActionResult<List<Enrollment>> GetEnrollments() =>  _context.Enrollments.AsNoTracking().ToList();


        [HttpPost]

        public async Task<ActionResult<Enrollment>> CreateEnrollment([FromBody] EnrollmentDTO enrollmentDTO)
        {

            if (enrollmentDTO == null) return BadRequest("not data");

            var student =await  _context.Enrollments.FirstOrDefaultAsync(x=>x.StudentId==enrollmentDTO.StudentId);
            if (student != null) return BadRequest($"Student with id {enrollmentDTO.StudentId} already exits");

            var course = await _studentClientService.GetCourseByIdAsync(enrollmentDTO.CourseId);

            if (course == null) return NotFound("No Course Found");


            Enrollment enrollment = new Enrollment()
            {

                CourseId = enrollmentDTO.CourseId,
                CourseTitle = course.Title,
                StudentId = enrollmentDTO.StudentId,
                StudentName = enrollmentDTO.StudentName,

            };

             _context.Enrollments.Add(enrollment);
            await _context.SaveChangesAsync();

            return Ok(enrollment);

        }


    }
}
