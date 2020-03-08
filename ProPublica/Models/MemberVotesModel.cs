using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProPublica.Models
{
    public class MemberVotesModel
    {
        public List<VoteModel> Votes { get; set; }
        public MemberModel Member { get; set; }
        public MemberVotesModel(List<VoteModel> votes, MemberModel member)
        {
            Votes = votes;
            Member = member;
        }
    }
}
