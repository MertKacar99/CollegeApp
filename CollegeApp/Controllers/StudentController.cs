using CollegeApp.Models;
using CollegeApp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CollegeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        [HttpGet]
        [Route("All", Name = "GetAllStudent")]
        public ActionResult<IEnumerable<Student>> GetStudentStudent()
        {
            // OK - 200 - SUCCESS
            return Ok(CollegeRepository.Students);
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetStudentById")]
        public ActionResult<Student?> GetStudentById(int id)
        {
            //
            if (id == 0)
            {
                return BadRequest();
            }
            return Ok(CollegeRepository.Students.Where(x => x.Id == id).FirstOrDefault());
        }
        [HttpGet]
        [Route("{name:alpha}", Name = "GetStudentByName")]
        public ActionResult<Student?> GetStudentByName(string name)
        {
            // return CollegeRepository.Students.Where(x => x.Name.ToLower() == name.ToLower()).FirstOrDefault();
            return Ok(CollegeRepository.Students.Where(x => x.Name == name).FirstOrDefault());
        }

        [HttpPost]
        [Route("Add", Name = "AddStudent")]
        public ActionResult<Student> AddStudent(Student student)
        {
            CollegeRepository.Students.Add(student);
            return Ok(student);
        }

        [HttpDelete("{id}", Name = "DeleteStudent")]
        public ActionResult<bool> DeleteStudent(int id)
        {
            var student = CollegeRepository.Students.Where(x => x.Id == id).FirstOrDefault();
            if (student != null)
            {
                CollegeRepository.Students.Remove(student);
                return Ok(true);
            }
            return NotFound(false);
        }

        [HttpPut("{id}", Name = "UpdateStudent")]
        public ActionResult<bool> UpdateStudent(int id, Student student)
        {
            var std = CollegeRepository.Students.FirstOrDefault(x => x.Id == id);

            if (std == null)
            {
                return NotFound(false);
            }

            std.Name = student.Name;
            std.Surname = student.Surname;
            std.Address = student.Address;
            std.email = student.email;
            std.BirthYear = student.BirthYear;

            Console.WriteLine($"Öğrenci {std.Id} güncellendi: {std}");

            return Ok(true);
        }
    }
}