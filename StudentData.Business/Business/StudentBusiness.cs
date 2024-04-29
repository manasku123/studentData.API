using AutoMapper;
using StudentData.Business.Contract;
using StudentData.Repository.Contract;
using StudentData.ViewModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentData.Business.Business
{
    public class StudentBusiness : IStudentBusiness
    {
        public readonly IStudentRepository _studentRepository;
        public readonly IMapper _mapper;

        public StudentBusiness(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<List<StudentViewModel>> GetStudents()
        {
            var students = await _studentRepository.GetStudents();
            return _mapper.Map<List<StudentViewModel>>(students);
        }

        public async Task<StudentViewModel> GetStudentById(int sId)
        {
            var student = await _studentRepository.GetStudentById(sId);
            return _mapper.Map<StudentViewModel>(student);
        }

        public async Task AddStudent(StudentViewModel student)
        {
            var studentEntity = _mapper.Map<StudentViewModel>(student);
            await _studentRepository.AddStudent(studentEntity);
        }
        public async Task DeleteStudent(int sId)
        {
            await _studentRepository.DeleteStudent(sId);
        }

        public async Task UpdateStudent(StudentViewModel student)
        {
            var studentEntity = _mapper.Map<StudentViewModel>(student);
            await _studentRepository.UpdateStudent(studentEntity);
        }

       
    }

}



