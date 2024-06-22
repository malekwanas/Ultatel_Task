using Ultatel_Task.DataAccessLayer.Repository.Contract;
using Ultatel_Task.Models;

namespace Ultatel_Task.DataAccessLayer.Repository
{
    public class StudentRepo : IStudentRepo
    {
        private readonly Ultatel_DBContext db;
        public StudentRepo(Ultatel_DBContext context)
        { 
            db = context;
        }
        //----------------------------------------------
        public IEnumerable<Student> GetAllStudents(int pageIndex = 0, int pageSize = 5)
        {
            // Calculate offset
            var skipCount = pageIndex * pageSize;

            return db.Students.Where(s => !s.IsDeleted).OrderBy(s => s.Student_ID).Skip(skipCount).Take(pageSize).ToList();
        }
        //----------------------------------------------
        public IEnumerable<Student> SearchStudents(string? fullName, int? minAge, int? maxAge, string? country, Gender? gender, int pageIndex = 0, int pageSize = 5)
        {
            var currentDate = DateOnly.FromDateTime(DateTime.UtcNow);

            var query = db.Students.Where(s => !s.IsDeleted).AsQueryable();

            // Apply filters conditionally
            if (!string.IsNullOrEmpty(fullName)) { query = query.Where(s => (s.FirstName + " " + s.LastName).Contains(fullName)); }

            if (minAge.HasValue)
            {
                var minBirthDate = currentDate.AddYears(-minAge.Value);
                query = query.Where(s => s.BirthDate <= minBirthDate);
            }

            if (maxAge.HasValue)
            {
                    var maxBirthDate = currentDate.AddYears(-maxAge.Value);
                query = query.Where(s => s.BirthDate >= maxBirthDate);
            }

            if (!string.IsNullOrEmpty(country)) { query = query.Where(s => s.Country == country); }

            if (gender.HasValue) { query = query.Where(s => s.Gender == gender); }

            // Calculate offset
            var skipCount = pageIndex * pageSize;

            return query.OrderBy(s => s.Student_ID).Skip(skipCount).Take(pageSize).ToList();
        }
        //----------------------------------------------
        public Student GetStudentById(int studentId)
        {
            return db.Students.SingleOrDefault(s => s.Student_ID == studentId && !s.IsDeleted);
        }
        //----------------------------------------------
        public Student DeleteStudent(int studentId)
        {
            Student std = db.Students.SingleOrDefault(a=>a.Student_ID == studentId);
            if (std == null) { return null; }

            std.IsDeleted = true;
            db.SaveChanges();

            return std;
        }     
        //----------------------------------------------
        public void UpdateStudent(Student student)
        {
            db.Students.Update(student);
            db.SaveChanges();
        }
        //----------------------------------------------
        public bool EmailExists(string email)
        {
            return db.Students.Any(s => s.Student_Email == email && !s.IsDeleted);
        }
        //----------------------------------------------
        public Student AddStudent(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
            return student;
        }
        //----------------------------------------------
    }
}
