﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProPublica.Entities.Members
{
    public class MemberCommittee
    {
        public string name { get; set; }
        public string code { get; set; }
        public string api_uri { get; set; }
        public string side { get; set; }
        public string title { get; set; }
        public int? rank_in_party { get; set; }
        public string begin_date { get; set; }
        public string end_date { get; set; }
    }
}
