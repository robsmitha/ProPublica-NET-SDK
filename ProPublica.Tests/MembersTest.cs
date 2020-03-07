using NUnit.Framework;
using ProPublica.Entities.Members;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProPublica.Tests
{

    public class MembersTest
    {
        private const string API_KEY = "YOUR_API_KEY";
        private const string DEFAULT_SENATE = "senate";
        private const string DEFAULT_CONGRESS = "116";
        private readonly ProPublicaApi _api = new ProPublicaApi(API_KEY);
        [SetUp]
        public void Setup()
        { 
        }

        private List<MemberListItem> GetMembers()
        {
            var response = _api.GetMembers(DEFAULT_CONGRESS, DEFAULT_SENATE);
            return response.results.Select(m => m.members).FirstOrDefault();
        }
        private Member GetMember(string id)
        {
            var response = _api.GetMember(id);
            return response.results.FirstOrDefault();
        }
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
            var response = _api.CompareVotePositions(
                members.LastOrDefault().id,
                members.FirstOrDefault().id, 
                DEFAULT_CONGRESS, 
                DEFAULT_SENATE);
            Assert.IsNotNull(response?.results);
        }
    }
}