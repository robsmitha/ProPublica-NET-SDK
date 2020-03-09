using ProPublica.Entities;
using ProPublica.Entities.Members;
using ProPublica.Interfaces;
using ProPublica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProPublica
{
    public class Members : BaseAuthorization, IMembers
    {
        public Members(string apiKey) : base(apiKey) { }
        public List<MemberModel> GetMembers(string congress, string chamber)
        {
            var response = Send<Response<List<MemberListResult>>>($"{congress}/{chamber}/members.json");
            return _mapper.Map<List<MemberModel>>(response?.results.Select(m => m.members).FirstOrDefault());
        }
        public MemberModel GetMember(string memberId)
        {
            var response = Send<Response<List<Member>>>($"members/{memberId}.json");
            return _mapper.Map<MemberModel>(response.results.FirstOrDefault());
        }
        public CompareVotePositionsModel CompareVotePositions(string firstMemberId, string secondMemberId, string congress, string chamber)
        {
            var response = Send<Response<List<CompareVotePositionsResult>>>($"members/{firstMemberId}/votes/{secondMemberId}/{congress}/{chamber}.json");
            return _mapper.Map<CompareVotePositionsModel>(response.results.FirstOrDefault());
        }
        public List<MemberModel> GetNewMembers()
        {
            var response = Send<Response<List<MemberListResult>>>($"members/new.json");
            return _mapper.Map<List<MemberModel>>(response.results.Select(m => m.members).FirstOrDefault());
        }
        public List<MemberModel> GetCurrentSenateMembers(string chamber, string state)
        {
            var response = Send<Response<List<MemberListItem>>>($"members/{chamber}/{state}/current.json");
            return _mapper.Map<List<MemberModel>>(response.results);
        }
        public List<MemberModel> GetMembersLeaving(string congress, string chamber)
        {
            var response = Send<Response<List<MemberListResult>>>($"{congress}/{chamber}/members/leaving.json");
            return _mapper.Map<List<MemberModel>>(response?.results.FirstOrDefault().members);
        }
    }
}
