using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentData.Business.Contract;
using StudentData.ViewModels.ViewModel;

namespace StudentData.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public readonly IStudentBusiness _studentBusiness;

        public StudentController(IStudentBusiness studentBusiness)
        {
            _studentBusiness = studentBusiness;
        }
        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _studentBusiness.GetStudents();
            return Ok(students);
        }
        [HttpGet("{sId}")]
        public async Task<IActionResult> GetStudentById(int sId)
        {
            var student = await _studentBusiness.GetStudentById(sId);
            if (student == null)
                return NotFound();
            return Ok(student);
        }
        [HttpPost]
        public async Task<IActionResult> AddStudent(StudentViewModel student)
        {
            await _studentBusiness.AddStudent(student);
            return Ok();
        }
        [HttpDelete("{sId}")]
        public async Task<IActionResult> DeleteStudent(int sId)
        {
            await _studentBusiness.DeleteStudent(sId);
            return Ok();
        }

        [HttpPut("{sId}")]
        public async Task<IActionResult> UpdateStudent(int sId, StudentViewModel student)
        {
            if (sId != student.Id)
                return BadRequest();

            await _studentBusiness.UpdateStudent(student);
            return Ok();
        }
    }
}




