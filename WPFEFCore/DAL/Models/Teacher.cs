using System;
using System.Collections.Generic;

namespace WPFEFCore.DAL.Models
{
    public partial class Teacher
    {
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public int? StandardId { get; set; }
        public int? TeacherType { get; set; }
    }
}
