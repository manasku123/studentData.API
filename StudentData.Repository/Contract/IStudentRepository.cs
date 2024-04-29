using StudentData.Entity.Models;
using StudentData.ViewModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentData.Repository.Contract
{
    public interface IStudentRepository
    {
        Task<List<StudentData.Entity.Models.Student>> GetStudents();
        Task<StudentData.Entity.Models.Student> GetStudentById(int Id);
        Task AddStudent(StudentData.Entity.Models.Student student);
        Task UpdateStudent(StudentData.Entity.Models.Student student);
        Task DeleteStudent(int Id);
        Task UpdateStudent(StudentViewModel studentEntity);
        Task AddStudent(StudentViewModel studentEntity);
    }
}
