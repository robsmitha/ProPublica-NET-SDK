using NUnit.Framework;
using ProPublicaSDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProPublicaSDK.Tests
{
    public class VotesTest : BaseTest
    {
        private List<VoteModel> votes;
        private List<VoteModel> Votes
        {
            get => votes ??= ProPublica.Votes.GetRecentVotes(HOUSE);
            set => votes = value;
        }
        [Test]
        public void GetRecentVotes()
        {
            Assert.IsNotNull(Votes);
        }
        [Test]
        public void GetVote()
        {
            var vote = Votes.FirstOrDefault();
            var roleCallVote = ProPublica.Votes.GetRoleCallVote(vote.congress, vote.chamber, vote.session, vote.roll_call);
            Assert.IsNotNull(roleCallVote);
        }
    }
}
