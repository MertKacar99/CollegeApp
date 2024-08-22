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
            // var students = new List<StudentDto>();
            // foreach (var item in CollegeRepository.Students){
            //     StudentDto obj = new StudentDto();
            //     {
            //         obj.Id = item.Id;
            //         obj.Name = item.Name;
            //         obj.Surname = item.Surname;
            //         obj.Address = item.Address;
            //         obj.email = item.email;
            //         obj.BirthYear = item.BirthYear;
            //     };
            //     students.Add(obj);
            // }

            var students = CollegeRepository.Students.Select(n => new StudentDto()
            {
                Id = n.Id,
                Name = n.Name,
                Surname = n.Surname,
                Address = n.Address,
                email = n.email,
                BirthYear = n.BirthYear
            });
            // OK - 200 - SUCCESS
            return Ok(students);
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetStudentById")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        
        public ActionResult<StudentDto?> GetStudentById(int id)
        {
            //
            if (id == 0)
            {
                return BadRequest();
            }
        
            Student? student =  CollegeRepository.Students.Where(x => x.Id == id).FirstOrDefault();
            if (student == null){
                return NotFound($"{id} id numarasına sahip Ogrenci Bulunamadi");
            }

            var studentDto = new StudentDto{
                Id = student.Id,
                Name = student.Name,
                Surname = student.Surname,
                Address = student.Address,
                email = student.email,
                BirthYear = student.BirthYear
            };                
            

            return Ok(studentDto);
        
        }
        [HttpGet]
        [Route("{name:alpha}", Name = "GetStudentByName")]
        public ActionResult<Student?> GetStudentByName(string name)
        {
            // return CollegeRepository.Students.Where(x => x.Name.ToLower() == name.ToLower()).FirstOrDefault();
            Student? student = CollegeRepository.Students.Where(x => x.Name == name).FirstOrDefault();
            if (student == null){
                return NotFound( $"{name} isimli Ogrenci Bulunamadi");
            }

                var studentDto = new StudentDto{
                Id = student.Id,
                Name = student.Name,
                Surname = student.Surname,
                Address = student.Address,
                email = student.email,
                BirthYear = student.BirthYear
            };     
            return Ok(studentDto);
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