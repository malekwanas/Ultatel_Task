using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ultatel_Task.BusinessLogicLayer.Services.Contract;
using Ultatel_Task.DataAccessLayer.DTO;
using Ultatel_Task.Models;

namespace Ultatel_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;
        public StudentController(IStudentService _studentService)
        {
            studentService = _studentService;
        }
        //----------------------------------------------------------
        private string GetAdminName()
        {
            var adminName = User.Claims.FirstOrDefault(c => c.Type == "name")?.Value;

            if (adminName == null) { return null; }
            return adminName;
        }
        //----------------------------------------------------------
        [HttpGet("GetAllStudents")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllStudents(int pageIndex = 0, int pageSize = 5)
        {
            var Students = studentService.GetAllStudents_UsingPagination(pageIndex, pageSize);
            return Ok(Students);
        }
        //----------------------------------------------------------
        [HttpGet("SearchStudentsByFilter")]
        [Authorize(Roles = "Admin")]
        public IActionResult SearchStudents(string? fullName, int? minAge, int? maxAge, string? country, Gender? gender, int pageIndex = 0, int pageSize = 5)
        {
            var students = studentService.SearchStudents(fullName, minAge, maxAge, country, gender, pageIndex, pageSize);
            if (students.Count() < 1) { return BadRequest("No students found."); }

            return Ok(students);
        }
        //----------------------------------------------------------
        [HttpDelete("DeleteStudent/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteSpecificStudent(int id)
        {
            var DeletedStd = studentService.DeleteStudent(id);
            return Ok(DeletedStd);
        }
        //----------------------------------------------------------
        [HttpPut("UpdateStudent/{studentId}")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateStudent(int studentId, StudentDTO studentDto)
        {
            var adminName = GetAdminName();
            if (adminName == null) { return Unauthorized("Admin name not found in token."); }

            try
            {
                var result = studentService.UpdateStudent(studentId, studentDto, adminName);

                if (result == null) { return NotFound("No changes detected."); }

                return Ok(result);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //----------------------------------------------------------
        [HttpPost("AddStudent")]
        [Authorize(Roles = "Admin")]
        public IActionResult AddStudent(StudentDTO studentDto)
        {
            var adminName = User.Claims.FirstOrDefault(c => c.Type == "name")?.Value;
            if (adminName == null) { return Unauthorized("Admin name not found in token."); }

            try
            {
                var addedStudent = studentService.AddStudent(studentDto, adminName);
                return Ok(addedStudent);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
        //----------------------------------------------------------
        }
    }
