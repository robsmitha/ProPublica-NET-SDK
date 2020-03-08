using ProPublica.Entities.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProPublica.Tests
{
    public class BaseTest
    {
        protected const string API_KEY = "YOUR_API_KEY";
        protected const string SENATE = "senate";
        protected const string HOUSE = "house";
        protected const string DEFAULT_CONGRESS = "116";
        protected readonly ProPublicaApi _api = new ProPublicaApi(API_KEY);

        protected List<MemberListItem> GetMembers()
        {
            var response = _api.GetMembers(DEFAULT_CONGRESS, SENATE);
            return response.results.Select(m => m.members).FirstOrDefault();
        }
        protected Member GetMember(string id)
        {
            var response = _api.GetMember(id);
            return response.results.FirstOrDefault();
        }
    }
}
