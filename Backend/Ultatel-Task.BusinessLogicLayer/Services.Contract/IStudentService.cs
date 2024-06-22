using Ultatel_Task.DataAccessLayer.DTO;
using Ultatel_Task.Models;

namespace Ultatel_Task.BusinessLogicLayer.Services.Contract
{
    public interface IStudentService
    {
        IEnumerable<StudentDTO> GetAllStudents_UsingPagination(int pageIndex = 0, int pageSize = 5);
        StudentDTO DeleteStudent(int id);
        IEnumerable<StudentDTO> SearchStudents(string? fullName, int? minAge, int? maxAge, string? country, Gender? gender, int pageIndex = 0, int pageSize = 5);
        StudentDTO UpdateStudent(int studentId, StudentDTO studentDto, string adminName);
        StudentDTO AddStudent(StudentDTO studentDto, string adminName);
    }
}
