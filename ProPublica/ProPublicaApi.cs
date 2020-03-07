using ProPublica.Entities;
using ProPublica.Entities.Members;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProPublica
{
    public class ProPublicaApi
    {
        private const string Endpoint = "https://api.propublica.org/congress/v1";
        private string ApiKey { get; set; }

        public ProPublicaApi(string apiKey = null)
        {
            ApiKey = apiKey;
        }

        private string FormatRequestUri(string function) => Endpoint + (!function.StartsWith("/") ? $"/{function}" : function);

        private async Task<T> SendAsync<T>(string function)
        {
            using HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-API-Key", ApiKey);
            try
            {
                var requestUri = FormatRequestUri(function);
                var response = await client.GetStringAsync(requestUri);
                return JsonSerializer.Deserialize<T>(response);
            }
            catch (HttpRequestException e)
            {
                throw e;
            }
        }

        #region Members Api
        public async Task<Response<IEnumerable<MemberListResult>>> GetMembers(string congress, string chamber) =>
            await SendAsync<Response<IEnumerable<MemberListResult>>>($"{congress}/{chamber}/members.json");

        public async Task<Response<List<Member>>> GetMember(string memberId) =>
            await SendAsync<Response<List<Member>>>($"members/{memberId}.json");

        public async Task<Response<List<MemberListResult>>> GetNewMembers() =>
            await SendAsync<Response<List<MemberListResult>>>($"members/new.json");

        public async Task<Response<IEnumerable<MemberListItem>>> GetCurrentSenateMembers(string chamber, string state) =>
            await SendAsync<Response<IEnumerable<MemberListItem>>>($"members/{chamber}/{state}/current.json");

        public async Task<Response<IEnumerable<MemberListItem>>> GetCurrentHouseMembers(string chamber, string state, string district) =>
            await SendAsync<Response<IEnumerable<MemberListItem>>>($"members/{chamber}/{state}/{district}/current.json");

        public async Task<Response<List<MemberListResult>>> GetMembersLeaving(string congress, string chamber) =>
            await SendAsync<Response<List<MemberListResult>>>($"{congress}/{chamber}/members/leaving.json");

        public async Task<Response<IEnumerable<MemberVotesResult>>> GetMemberVotes(string memberId) =>
            await SendAsync<Response<IEnumerable<MemberVotesResult>>>($"members/{memberId}/votes.json");

        public async Task<Response<IEnumerable<CompareVotePositionsResult>>> CompareVotePositions(string firstMemberId, string secondMemberId, string congress, string chamber) =>
            await SendAsync<Response<IEnumerable<CompareVotePositionsResult>>>($"members/{firstMemberId}/votes/{secondMemberId}/{congress}/{chamber}.json");

        public async Task<Response<IEnumerable<CompareBillSponsorshipsResult>>> CompareBillSponsorships(string firstMemberId, string secondMemberId, string congress, string chamber) =>
            await SendAsync<Response<IEnumerable<CompareBillSponsorshipsResult>>>($"members/{firstMemberId}/bills/{secondMemberId}/{congress}/{chamber}.json");

        public async Task<Response<IEnumerable<MemberBillsResult>>> GetMemberBillsByType(string memberId, string type) =>
            await SendAsync<Response<IEnumerable<MemberBillsResult>>>($"members/{memberId}/bills/{type}.json");

        public async Task<Response<List<Expenses>>> GetOfficeExpenses(string memberId, string year, string quarter) =>
            await SendAsync<Response<List<Expenses>>>($"members/{memberId}/office_expenses/{year}/{quarter}.json");

        public async Task<Response<List<Expenses>>> GetMemberOfficeExpensesByCategory(string memberId, string category) =>
            await SendAsync<Response<List<Expenses>>>($"members/{memberId}/office_expenses/category/{category}.json");

        public async Task<Response<List<Expenses>>> GetOfficeExpensesByCategory(string category, string year, string quarter) =>
            await SendAsync<Response<List<Expenses>>>($"office_expenses/category/{category}/{year}/{quarter}.json");
        #endregion
    }
}
