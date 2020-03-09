using ProPublicaSDK.Entities;
using ProPublicaSDK.Entities.Votes;
using ProPublicaSDK.Interfaces;
using ProPublicaSDK.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProPublicaSDK
{
    public class Votes : BaseAuthorization, IVotes
    {
        public Votes(string apiKey) : base(apiKey) { }
        public List<VoteModel> GetRecentVotes(string chamber)
        {
            var response = Send<Response<RecentVotesResult>>($"{chamber}/votes/recent.json");
            if (response?.results == null) return new List<VoteModel>();
            var data = response.results.votes;
            return data != null
                ? _mapper.Map<List<VoteModel>>(data)
                : new List<VoteModel>();
        }

        public VoteModel GetRoleCallVote(string congress, string chamber, string sessionNumber, string rollCallNumber)
        {
            var response = Send<Response<RollCallVoteResult>>($"{congress}/{chamber}/sessions/{sessionNumber}/votes/{rollCallNumber}.json");
            if (response?.results == null) return new VoteModel();
            var data = response.results.votes.vote;
            return data != null
                ? _mapper.Map<VoteModel>(data)
                : new VoteModel();
        }
    }
}
