﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusProject.Models
{
    public class Class
    {
        public int Id { get; set; }
        public string ClassName { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
