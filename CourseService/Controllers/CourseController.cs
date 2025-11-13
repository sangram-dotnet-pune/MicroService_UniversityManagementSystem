using CourseService.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {

        private readonly CourseDbContext _context;

        public CourseController(CourseDbContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<ActionResult<List<Course>>> GetCourse() => _context.Courses.AsNoTracking().ToList();


        [HttpGet(("{id:int}"))]
        public async Task<ActionResult<Course>>GetCourseById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invaild Course Id");
            }

            var course=await _context.Courses.FirstOrDefaultAsync(x=>x.Id==id);

            if (course == null) return NotFound("No course with this Id");

            return Ok(course);
        }
    }
}
