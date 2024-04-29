using StudentData.ViewModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentData.Business.Contract
{
    public interface IStudentBusiness
    {
        Task<List<StudentViewModel>> GetStudents();
        Task<StudentViewModel> GetStudentById(int sId);
        Task AddStudent(StudentViewModel student);
        Task DeleteStudent(int sId);
        Task UpdateStudent(StudentViewModel student);
    }
}
