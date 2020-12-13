using System;
using System.Collections.Generic;

namespace WPFEFCore.DAL.Models
{
    public partial class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Location { get; set; }
        public int? TeacherId { get; set; }
    }
}
