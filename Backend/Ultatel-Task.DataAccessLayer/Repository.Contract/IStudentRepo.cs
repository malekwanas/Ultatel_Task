﻿using Ultatel_Task.Models;

namespace Ultatel_Task.DataAccessLayer.Repository.Contract
{
    public interface IStudentRepo
    {
        IEnumerable<Student> GetAllStudents(int pageIndex = 0, int pageSize = 5);
        IEnumerable<Student> SearchStudents(string? fullName, int? minAge, int? maxAge, string? country, Gender? gender, int pageIndex = 0, int pageSize = 5);
        Student GetStudentById(int studentId);
        Student DeleteStudent(int studentId);
        void UpdateStudent(Student student);
        bool EmailExists(string email);
        Student AddStudent(Student student);

    }
}
