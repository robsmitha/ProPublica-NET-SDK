﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProPublica.Entities.Votes
{
    public class Nomination
    {
        public string nomination_id { get; set; }
        public string number { get; set; }
        public string name { get; set; }
        public string agency { get; set; }
    }
}
