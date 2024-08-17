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
        [Route("All",Name = "GetAllStudent")]
        public IEnumerable<Student> GetStudentStudent()
        {
            return  CollegeRepository.Students; 
        }

        [HttpGet]       
        [Route("{id}:int",Name = "GetStudentById")]
        public Student GetStudentById(int id)
        {
            return CollegeRepository.Students.Where(x => x.Id == id).FirstOrDefault();
        }

        

        [HttpGet]
        [Route("{name:alpha}",Name = "GetStudentByName")]
        public Student GetStudentByName(string name)
        {
            // return CollegeRepository.Students.Where(x => x.Name.ToLower() == name.ToLower()).FirstOrDefault();
            return CollegeRepository.Students.Where(x => x.Name == name).FirstOrDefault();
        }

        [HttpPost]
        [Route("Add",Name = "AddStudent")]
        public Student AddStudent(Student student)
        {
            CollegeRepository.Students.Add(student);
            return student;
        }

        [HttpDelete("{id}",Name = "DeleteStudent")]
        public bool DeleteStudent(int id){
            var student = CollegeRepository.Students.Where(x => x.Id == id).FirstOrDefault();
            CollegeRepository.Students.Remove(student);
            return true;
        }
    }
}