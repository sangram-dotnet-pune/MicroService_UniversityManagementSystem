using StudentService.Model;
using System.Net.Http;

namespace StudentService.Service
{
    public class StudentClientService(HttpClient client)
    {


        public  async Task<Course?> GetCourseByIdAsync(int id)
        {
          
            return await client.GetFromJsonAsync<Course>($"/Course/{id}");
        }


    }
}
