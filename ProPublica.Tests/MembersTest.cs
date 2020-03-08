using NUnit.Framework;
using ProPublica.Entities.Members;
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
            var members = GetMembers();
            Assert.NotNull(members);
        }
        [Test]
        public void GetMemberTest()
        {
            var members = GetMembers();
            var member = GetMember(members.FirstOrDefault().id);
            Assert.NotNull(member);
        }
        [Test]
        public void CompareVotePositionsTest()
        {
            var members = GetMembers();
            var result = _api.CompareVotePositions(
                members.LastOrDefault().id,
                members.FirstOrDefault().id, 
                DEFAULT_CONGRESS, 
                SENATE);
            Assert.IsNotNull(result);
        }
    }
}