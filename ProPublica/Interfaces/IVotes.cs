using ProPublica.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProPublica.Interfaces
{
    public interface IVotes
    {
        List<VoteModel> GetRecentVotes(string chamber);
        VoteModel GetRoleCallVote(string congress, string chamber, string sessionNumber, string rollCallNumber);
    }
}
