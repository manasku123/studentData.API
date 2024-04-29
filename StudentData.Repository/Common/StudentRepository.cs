using Microsoft.EntityFrameworkCore;
using StudentData.Entity.Models;
using StudentData.Repository.Contract;
using StudentData.ViewModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentData.Repository.Common
{
    public class StudentRepository : IStudentRepository
    {
        public readonly DbContext _dbContext;
        public StudentRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<StudentData.Entity.Models.Student>> GetStudents()
        {
            return await _dbContext.Set<StudentData.Entity.Models.Student>().ToListAsync();
        }

        public async Task<StudentData.Entity.Models.Student> GetStudentById(int Id)
        {
            return await _dbContext.Set<Student>().FindAsync(Id);
        }

        public async Task AddStudent(StudentData.Entity.Models.Student student)
        {
            await _dbContext.Set<StudentData.Entity.Models.Student>().AddAsync(student);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateStudent(StudentData.Entity.Models.Student student)
        {
            _dbContext.Entry(student).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteStudent(int Id)
        {
            var student = await _dbContext.Set<StudentData.Entity.Models.Student>().FindAsync(Id);
            if (student != null)
            {
                _dbContext.Set<StudentData.Entity.Models.Student>().Remove(student);
                await _dbContext.SaveChangesAsync();
            }
        }

        Task IStudentRepository.UpdateStudent(StudentViewModel studentEntity)
        {
            throw new NotImplementedException();
        }

        Task IStudentRepository.AddStudent(StudentViewModel studentEntity)
        {
            throw new NotImplementedException();
        }
    }
}





