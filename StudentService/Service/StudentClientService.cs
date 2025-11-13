using StudentService.Model;
using System.Net.Http;

namespace StudentService.Service
{
    public class StudentClientService(HttpClient client)
    {


        public  async Task<Course?> GetCourseByIdAsync(int id)
        {
            try
            {
                return await client.GetFromJsonAsync<Course>($"/Course/{id}");

            }

            catch(Exception ex)
            {
                return null;
            }
        }


    }
}
