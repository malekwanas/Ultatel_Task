using AutoMapper;
using Ultatel_Task.BusinessLogicLayer.Services.Contract;
using Ultatel_Task.DataAccessLayer.DTO;
using Ultatel_Task.DataAccessLayer.Repository.Contract;
using Ultatel_Task.Models;

namespace Ultatel_Task.BusinessLogicLayer.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepo StudentRepository;
        private readonly IMapper mapper;

        public StudentService(IStudentRepo _StudentRepository, IMapper _mapper) 
        {
            mapper = _mapper;
            StudentRepository = _StudentRepository;
        }
        //------------------------------------------------------------------------------
        public IEnumerable<StudentDTO> GetAllStudents_UsingPagination(int pageIndex = 0, int pageSize = 5)
        {
            var Students = StudentRepository.GetAllStudents(pageIndex, pageSize);
            var StudentsDTO = mapper.Map<IEnumerable<StudentDTO>>(Students);
            return StudentsDTO;
        }
        //------------------------------------------------------------------------------
        public int ReturnStudentsCount()
        {
            return StudentRepository.CountOfStudents();
        }
        //------------------------------------------------------------------------------
        public StudentDTO DeleteStudent(int id)
        {
            var Deleted = StudentRepository.DeleteStudent(id);
            var DeletedDTO = mapper.Map<StudentDTO>(Deleted);
            return DeletedDTO;
        }
        //------------------------------------------------------------------------------
        public IEnumerable<StudentDTO> SearchStudents(string? fullName, int? minAge, int? maxAge, string? country, Gender? gender, int pageIndex = 0, int pageSize = 5)
        {
            var students = StudentRepository.SearchStudents(fullName, minAge, maxAge, country, gender, pageIndex, pageSize);
            var studentsDTO = mapper.Map<IEnumerable<StudentDTO>>(students);
            return studentsDTO;
        }
        //------------------------------------------------------------------------------
        public int CountFilteredStudents(string? fullName, int? minAge, int? maxAge, string? country, Gender? gender)
        {
            return StudentRepository.CountFilteredStudents(fullName, minAge, maxAge, country, gender);
        }
        //------------------------------------------------------------------------------
        public StudentDTO UpdateStudent(int studentId, StudentDTO studentDto, string adminName)
        {
            var existingStudent = StudentRepository.GetStudentById(studentId);

            if (existingStudent == null) { return null; }

            // Check if the email already exists for an active student
            var emailExists = StudentRepository.GetAllStudents().Any(s => s.Student_Email == studentDto.Student_Email && s.Student_ID != studentId);

            if (emailExists)
            {
                throw new Exception("Email already exists for another active student.");
            }

            bool changesDetected = false;

            if (existingStudent.FirstName != studentDto.FirstName)
            {
                existingStudent.FirstName = studentDto.FirstName;
                changesDetected = true;
            }

            if (existingStudent.LastName != studentDto.LastName)
            {
                existingStudent.LastName = studentDto.LastName;
                changesDetected = true;
            }

            if (existingStudent.Country != studentDto.Country)
            {
                existingStudent.Country = studentDto.Country;
                changesDetected = true;
            }

            if (existingStudent.Gender != studentDto.Gender)
            {
                existingStudent.Gender = studentDto.Gender;
                changesDetected = true;
            }

            if (existingStudent.BirthDate != studentDto.BirthDate)
            {
                existingStudent.BirthDate = studentDto.BirthDate;
                changesDetected = true;
            }

            if (existingStudent.Student_Email != studentDto.Student_Email)
            {
                existingStudent.Student_Email = studentDto.Student_Email;
                changesDetected = true;
            }

            if (changesDetected)
            {
                existingStudent.LastAuditedBy = adminName;
                StudentRepository.UpdateStudent(existingStudent);
            }

            return changesDetected ? mapper.Map<StudentDTO>(existingStudent) : null;
        }
        //------------------------------------------------------------------------------
        public StudentDTO AddStudent(StudentDTO studentDto, string adminName)
        {
            if ( StudentRepository.EmailExists(studentDto.Student_Email) ) { throw new Exception("Email already exists for another active student."); }

            var student = mapper.Map<Student>(studentDto);
            student.StudentCreatedBy = adminName;
            student.LastAuditedBy = null;

            var addedStudent = StudentRepository.AddStudent(student);
            return mapper.Map<StudentDTO>(addedStudent);
        }
        //------------------------------------------------------------------------------
    }
}
