using ProPublica.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProPublica.Interfaces
{
    public interface ICommittees
    {
        List<CommitteeModel> GetCommittees(string congress, string chamber);
        CommitteeModel GetCommittee(string id, string congress, string chamber);
    }
}
