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



        public List<DAL.Models.Student> GetStudents()
        {
            var students = _dbContext.Student;

            return students.ToList();

        }


    }
}
