using CollegeApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CollegeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        [HttpGet("GetStudentName")]
        public IEnumerable<Student> GetStudentStudent()
        {
            return new List<Student>{
                new Student
                {
                    Id = 1,
                    Name = "Ahmet",
                    Surname = "Yılmaz",
                    email = "ahmet@yılmaz.com",
                    BirthYear = 1999,
                    Address = "Istanbul"
                },
                new Student
            {
                Id = 2,
                Name = "Mehmet",
                Surname = "Yılmaz",
                email = "mehmet@yılmaz.com",
                BirthYear = 1999,
                Address = "Istanbul"
            }
            };
        }
    }
}