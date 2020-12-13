using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPFEFCore.RepositoryHelper
{
    public class StudentRepositoryHelper
    {

        private DAL.Models.schooldbContext _dbContext;


        public StudentRepositoryHelper()
        {
            _dbContext = new DAL.Models.schooldbContext();
        }



        public List<DAL.Models.Student> GetAll()
        {
            var students = _dbContext.Student;

            return students.ToList();

        }


        public bool Create(DAL.Models.Student student)
        {
            _dbContext.Student.Add(student);
            _dbContext.SaveChanges();

            var studentId = student.StudentId;

            return studentId > 0;
        }


        public bool Update(DAL.Models.Student student)
        {
            var dbData = _dbContext.Student.Where(r => r.StudentId == student.StudentId).FirstOrDefault();

            dbData.StudentName = student.StudentName;
            dbData.StandardId = student.StandardId;

            var totalUddatedEntry = _dbContext.SaveChanges();

            var isUpdateSuccessful = totalUddatedEntry > 0;

            return isUpdateSuccessful;
        }


        public bool Delete(int studentId)
        {
            var dbData = _dbContext.Student.Where(r => r.StudentId == studentId).FirstOrDefault();

            _dbContext.Student.Remove(dbData);
            var totalDeletedEntry = _dbContext.SaveChanges();

            var isDeletionSuccessful = totalDeletedEntry > 0;

            return isDeletionSuccessful;
        }

    }
}
