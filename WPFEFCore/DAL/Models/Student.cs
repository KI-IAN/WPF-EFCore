using System;
using System.Collections.Generic;

namespace WPFEFCore.DAL.Models
{
    public partial class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StandardId { get; set; }
        public DateTime? RowVersion { get; set; }
    }
}
