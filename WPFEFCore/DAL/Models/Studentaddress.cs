﻿using System;
using System.Collections.Generic;

namespace WPFEFCore.DAL.Models
{
    public partial class Studentaddress
    {
        public int StudentId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
