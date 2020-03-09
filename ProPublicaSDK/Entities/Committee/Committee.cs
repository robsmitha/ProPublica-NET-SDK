﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProPublicaSDK.Entities.Committee
{
    public class Committee
    {
        public string id { get; set; }
        public string name { get; set; }
        public string chamber { get; set; }
        public string url { get; set; }
        public string api_uri { get; set; }
        public string chair { get; set; }
        public string chair_id { get; set; }
        public string chair_party { get; set; }
        public string chair_state { get; set; }
        public string chair_uri { get; set; }
        public string ranking_member_id { get; set; }
        public List<Subcommittee> subcommittees { get; set; }
    }
}
