using ProPublica.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProPublica.Interfaces
{
    public interface IMembers
    {
        List<MemberModel> GetMembers(string congress, string chamber);
        MemberModel GetMember(string memberId);
        CompareVotePositionsModel CompareVotePositions(string firstMemberId, string secondMemberId, string congress, string chamber);
        List<MemberModel> GetNewMembers();
        List<MemberModel> GetMembersLeaving(string congress, string chamber);
        List<MemberModel> GetCurrentSenateMembers(string chamber, string state);
    }
}
