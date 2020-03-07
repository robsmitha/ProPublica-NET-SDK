﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProPublica.Entities.Bills
{
    public class BillSubjects
    {
        public string query { get; set; }
        public int num_results { get; set; }
        public int offset { get; set; }
        public List<Subject> subjects { get; set; }
    }
}
