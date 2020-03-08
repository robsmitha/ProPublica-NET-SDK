using ProPublica.Entities.Members;
using ProPublica.Models;
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

        protected List<MemberModel> GetMembers() => _api.GetMembers(DEFAULT_CONGRESS, SENATE);
        protected MemberModel GetMember(string id) => _api.GetMember(id);
    }
}
