using NUnit.Framework;
using ProPublica.Entities.Members;
using ProPublica.Interfaces;
using ProPublica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProPublica.Tests
{

    public class MembersTest : BaseTest
    {
        private List<MemberModel> members;
        public List<MemberModel> Members
        {
            get => members ??= ProPublica.Members.GetMembers(DEFAULT_CONGRESS, SENATE);
            set => members = value;
        }
        [Test]
        public void GetMembersTest()
        {
            Assert.NotNull(Members);
        }
        [Test]
        public void GetMemberTest()
        {
            var member = ProPublica.Members.GetMember(Members.FirstOrDefault().id);
            Assert.NotNull(member);
        }
        [Test]
        public void CompareVotePositionsTest()
        {
            var result = ProPublica.Members.CompareVotePositions(
                Members.LastOrDefault().id,
                Members.FirstOrDefault().id, 
                DEFAULT_CONGRESS, 
                SENATE);
            Assert.IsNotNull(result);
        }
        [Test]
        public void GetNewMembers()
        {
            var members = ProPublica.Members.GetNewMembers();
            Assert.IsNotNull(members);
        }
        [Test]
        public void GetCurrentSenateMembers()
        {
            var members = ProPublica.Members.GetCurrentSenateMembers(SENATE, "FL");
            Assert.IsNotNull(members);
        }
        [Test]
        public void GetMembersLeaving()
        {
            var members = ProPublica.Members.GetMembersLeaving(DEFAULT_CONGRESS, HOUSE);
            Assert.IsNotNull(members);
        }
        [Test]
        public void GetMemberVotes()
        {
            var member = Members.FirstOrDefault();
            var votes = ProPublica.Members.GetMemberVotes(member?.id);
            Assert.IsNotNull(votes);
        }
        [Test]
        public void GetMemberBills()
        {
            var member = Members.FirstOrDefault();
            var bills = ProPublica.Members.GetMemberBills(member.id);
            Assert.IsNotNull(bills);
        }
        [Test]
        public void GetMemberCosponsoredBills()
        {
            var member = Members.FirstOrDefault();
            var cosponsoredBills = ProPublica.Members.GetMemberCosponsoredBills(member.id);
            Assert.IsNotNull(cosponsoredBills);
        }
        [Test]
        public void GetMemberStatements()
        {
            var member = Members.FirstOrDefault();
            var statements = ProPublica.Members.GetMemberStatements(member.id, DEFAULT_CONGRESS);
            Assert.IsNotNull(statements);
        }
        [Test]
        public void GetMemberExpenses()
        {
            var member = Members.FirstOrDefault();
            var expenses = ProPublica.Members.GetMemberExpenses(member.id, DateTime.Now.Year, 1);
            Assert.IsNotNull(expenses);
        }
        [Test]
        public void GetMemberExplanations()
        {
            var member = Members.FirstOrDefault();
            var explanations = ProPublica.Members.GetMemberExplanations(member.id, DEFAULT_CONGRESS);
            Assert.IsNotNull(explanations);
        }
    }
}