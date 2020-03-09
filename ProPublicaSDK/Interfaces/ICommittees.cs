using ProPublicaSDK.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProPublicaSDK.Interfaces
{
    public interface ICommittees
    {
        List<CommitteeModel> GetCommittees(string congress, string chamber);
        CommitteeModel GetCommittee(string id, string congress, string chamber);
    }
}
