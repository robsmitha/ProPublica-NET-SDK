using ProPublicaSDK.Entities.Votes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProPublicaSDK.Entities.Members
{
    public class MemberVotesResult
    {
        public string member_id { get; set; }
        public string total_votes { get; set; }
        public string offset { get; set; }
        public List<Vote> votes { get; set; }
    }
}
