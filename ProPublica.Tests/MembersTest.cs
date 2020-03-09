using NUnit.Framework;
using ProPublica.Entities.Members;
using ProPublica.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProPublica.Tests
{

    public class MembersTest : BaseTest
    {
        [Test]
        public void GetMembersTest()
        {
            var members = ProPublica.Members.GetMembers(DEFAULT_CONGRESS, SENATE);
            Assert.NotNull(members);
        }
        [Test]
        public void GetMemberTest()
        {
            var members = ProPublica.Members.GetMembers(DEFAULT_CONGRESS, SENATE);
            var member = ProPublica.Members.GetMember(members.FirstOrDefault().id);
            Assert.NotNull(member);
        }
        [Test]
        public void CompareVotePositionsTest()
        {
            var members = ProPublica.Members.GetMembers(DEFAULT_CONGRESS, SENATE);
            var result = ProPublica.Members.CompareVotePositions(
                members.LastOrDefault().id,
                members.FirstOrDefault().id, 
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
    }
}