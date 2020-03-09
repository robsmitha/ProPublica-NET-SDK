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
            if (response?.results == null) return new List<MemberModel>();
            var data = response?.results.Select(m => m.members).FirstOrDefault();
            return data != null
                ? _mapper.Map<List<MemberModel>>(data)
                : new List<MemberModel>();
        }
        public MemberModel GetMember(string memberId)
        {
            var response = Send<Response<List<Member>>>($"members/{memberId}.json");
            if (response?.results == null) return new MemberModel();
            var data = response?.results.FirstOrDefault();
            return data != null
                ? _mapper.Map<MemberModel>(data)
                : new MemberModel(); 
        }
        public CompareVotePositionsModel CompareVotePositions(string firstMemberId, string secondMemberId, string congress, string chamber)
        {
            var response = Send<Response<List<CompareVotePositionsResult>>>($"members/{firstMemberId}/votes/{secondMemberId}/{congress}/{chamber}.json");
            if (response?.results == null) return new CompareVotePositionsModel();
            var data = response?.results.FirstOrDefault();
            return data != null 
                ? _mapper.Map<CompareVotePositionsModel>(data) 
                : new CompareVotePositionsModel();
        }
        public List<MemberModel> GetNewMembers()
        {
            var response = Send<Response<List<MemberListResult>>>($"members/new.json");
            if (response?.results == null) return new List<MemberModel>();
            var data = response?.results.Select(m => m.members).FirstOrDefault();
            return data != null
                ? _mapper.Map<List<MemberModel>>(data)
                : new List<MemberModel>();
        }
        public List<MemberModel> GetCurrentSenateMembers(string chamber, string state)
        {
            var response = Send<Response<List<MemberListItem>>>($"members/{chamber}/{state}/current.json");
            if (response?.results == null) return new List<MemberModel>();
            var data = response?.results;
            return data != null 
                ? _mapper.Map<List<MemberModel>>(response?.results)
                : new List<MemberModel>();
        }
        public List<MemberModel> GetMembersLeaving(string congress, string chamber)
        {
            var response = Send<Response<List<MemberListResult>>>($"{congress}/{chamber}/members/leaving.json");
            if (response?.results == null) return new List<MemberModel>();
            var data = response.results.FirstOrDefault()?.members;
            return data != null
                ? _mapper.Map<List<MemberModel>>(data)
                : new List<MemberModel>();
        }
        public List<VoteModel> GetMemberVotes(string memberId)
        {
            var response = Send<Response<IEnumerable<MemberVotesResult>>>($"congress/members/{memberId}/votes");
            if (response?.results == null) return new List<VoteModel>();
            var data = response.results.FirstOrDefault()?.votes;
            return data != null
                ? _mapper.Map<List<VoteModel>>(data)
                : new List<VoteModel>();
        }
    }
}
