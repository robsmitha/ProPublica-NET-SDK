﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProPublica.Entities.Votes
{
    public class RecentVotesResult
    {
        public string chamber { get; set; }
        public int offset { get; set; }
        public int num_results { get; set; }
        public List<Vote> votes { get; set; }
    }
}
