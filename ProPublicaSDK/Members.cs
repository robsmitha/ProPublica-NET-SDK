using ProPublicaSDK.Entities;
using ProPublicaSDK.Entities.Members;
using ProPublicaSDK.Entities.Statements;
using ProPublicaSDK.Entities.Votes;
using ProPublicaSDK.Interfaces;
using ProPublicaSDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProPublicaSDK
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
        public List<BillModel> GetMemberBills(string memberId)
        {
            var response = Send<Response<IEnumerable<MemberBillsResult>>>($"congress/members/{memberId}/bills/introduced");
            if (response?.results == null) return new List<BillModel>();
            var data = response.results.FirstOrDefault()?.bills;
            return data != null
                ? _mapper.Map<List<BillModel>>(data)
                : new List<BillModel>();
        }
        public List<BillModel> GetMemberCosponsoredBills(string memberId)
        {
            var response = Send<Response<IEnumerable<MemberBillsResult>>>($"congress/members/{memberId}/bills/cosponsored");
            if (response?.results == null) return new List<BillModel>();
            var data = response.results.FirstOrDefault()?.bills;
            return data != null
                ? _mapper.Map<List<BillModel>>(data)
                : new List<BillModel>();
        }
        public List<StatementModel> GetMemberStatements(string memberId, string congress)
        {
            var response = Send<StatementResponse<List<Statement>>>($"congress/members/{memberId}/statements/{congress}");
            if (response?.results == null) return new List<StatementModel>();
            var data = response.results;
            return _mapper.Map<List<StatementModel>>(data);
        }
        public List<ExpensesModel> GetMemberExpenses(string id, int year, int quarter)
        {
            var response = Send<Response<IEnumerable<Expenses>>>($"congress/members/office_expenses/{id}/{year}/{quarter}");
            if (response?.results == null) return new List<ExpensesModel>();
            var data = response.results;
            return _mapper.Map<List<ExpensesModel>>(data);
        }
        public List<ExplanationModel> GetMemberExplanations(string memberId, string congress)
        {
            var response = Send<Response<List<Explanation>>>($"congress/members/{memberId}/explanations/{congress}");
            if (response?.results == null) return new List<ExplanationModel>();
            var data = response.results;
            return _mapper.Map<List<ExplanationModel>>(data);
        }
    }
}
