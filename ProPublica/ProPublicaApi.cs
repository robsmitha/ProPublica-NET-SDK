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
        private T Send<T>(string function)
        {
            using HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-API-Key", ApiKey);
            try
            {
                var requestUri = FormatRequestUri(function);
                var response = client.GetStringAsync(requestUri).Result;
                return JsonSerializer.Deserialize<T>(response);
            }
            catch (HttpRequestException e)
            {
                throw e;
            }
        }
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


        public Response<IEnumerable<MemberListResult>> GetMembers(string congress, string chamber) =>
            Send<Response<IEnumerable<MemberListResult>>>($"{congress}/{chamber}/members.json");

        public Response<List<Member>> GetMember(string memberId) =>
            Send<Response<List<Member>>>($"members/{memberId}.json");

        public Response<List<MemberListResult>> GetNewMembers() =>
            Send<Response<List<MemberListResult>>>($"members/new.json");

        public Response<IEnumerable<MemberListItem>> GetCurrentSenateMembers(string chamber, string state) =>
            Send<Response<IEnumerable<MemberListItem>>>($"members/{chamber}/{state}/current.json");

        public Response<IEnumerable<MemberListItem>> GetCurrentHouseMembers(string chamber, string state, string district) =>
            Send<Response<IEnumerable<MemberListItem>>>($"members/{chamber}/{state}/{district}/current.json");

        public Response<List<MemberListResult>> GetMembersLeaving(string congress, string chamber) =>
            Send<Response<List<MemberListResult>>>($"{congress}/{chamber}/members/leaving.json");

        public Response<IEnumerable<MemberVotesResult>> GetMemberVotes(string memberId) =>
            Send<Response<IEnumerable<MemberVotesResult>>>($"members/{memberId}/votes.json");

        public Response<IEnumerable<CompareVotePositionsResult>> CompareVotePositions(string firstMemberId, string secondMemberId, string congress, string chamber) =>
            Send<Response<IEnumerable<CompareVotePositionsResult>>>($"members/{firstMemberId}/votes/{secondMemberId}/{congress}/{chamber}.json");

        public Response<IEnumerable<CompareBillSponsorshipsResult>> CompareBillSponsorships(string firstMemberId, string secondMemberId, string congress, string chamber) =>
            Send<Response<IEnumerable<CompareBillSponsorshipsResult>>>($"members/{firstMemberId}/bills/{secondMemberId}/{congress}/{chamber}.json");

        public Response<IEnumerable<MemberBillsResult>> GetMemberBillsByType(string memberId, string type) =>
            Send<Response<IEnumerable<MemberBillsResult>>>($"members/{memberId}/bills/{type}.json");

        public Response<List<Expenses>> GetOfficeExpenses(string memberId, string year, string quarter) =>
            Send<Response<List<Expenses>>>($"members/{memberId}/office_expenses/{year}/{quarter}.json");

        public Response<List<Expenses>> GetMemberOfficeExpensesByCategory(string memberId, string category) =>
            Send<Response<List<Expenses>>>($"members/{memberId}/office_expenses/category/{category}.json");

        public Response<List<Expenses>> GetOfficeExpensesByCategory(string category, string year, string quarter) =>
            Send<Response<List<Expenses>>>($"office_expenses/category/{category}/{year}/{quarter}.json");

        public async Task<Response<IEnumerable<MemberListResult>>> GetMembersAsync(string congress, string chamber) =>
            await SendAsync<Response<IEnumerable<MemberListResult>>>($"{congress}/{chamber}/members.json");

        public async Task<Response<List<Member>>> GetMemberAsync(string memberId) =>
            await SendAsync<Response<List<Member>>>($"members/{memberId}.json");

        public async Task<Response<List<MemberListResult>>> GetNewMembersAsync() =>
            await SendAsync<Response<List<MemberListResult>>>($"members/new.json");

        public async Task<Response<IEnumerable<MemberListItem>>> GetCurrentSenateMembersAsync(string chamber, string state) =>
            await SendAsync<Response<IEnumerable<MemberListItem>>>($"members/{chamber}/{state}/current.json");

        public async Task<Response<IEnumerable<MemberListItem>>> GetCurrentHouseMembersAsync(string chamber, string state, string district) =>
            await SendAsync<Response<IEnumerable<MemberListItem>>>($"members/{chamber}/{state}/{district}/current.json");

        public async Task<Response<List<MemberListResult>>> GetMembersLeavingAsync(string congress, string chamber) =>
            await SendAsync<Response<List<MemberListResult>>>($"{congress}/{chamber}/members/leaving.json");

        public async Task<Response<IEnumerable<MemberVotesResult>>> GetMemberVotesAsync(string memberId) =>
            await SendAsync<Response<IEnumerable<MemberVotesResult>>>($"members/{memberId}/votes.json");

        public async Task<Response<IEnumerable<CompareVotePositionsResult>>> CompareVotePositionsAsync(string firstMemberId, string secondMemberId, string congress, string chamber) =>
            await SendAsync<Response<IEnumerable<CompareVotePositionsResult>>>($"members/{firstMemberId}/votes/{secondMemberId}/{congress}/{chamber}.json");

        public async Task<Response<IEnumerable<CompareBillSponsorshipsResult>>> CompareBillSponsorshipsAsync(string firstMemberId, string secondMemberId, string congress, string chamber) =>
            await SendAsync<Response<IEnumerable<CompareBillSponsorshipsResult>>>($"members/{firstMemberId}/bills/{secondMemberId}/{congress}/{chamber}.json");

        public async Task<Response<IEnumerable<MemberBillsResult>>> GetMemberBillsByTypeAsync(string memberId, string type) =>
            await SendAsync<Response<IEnumerable<MemberBillsResult>>>($"members/{memberId}/bills/{type}.json");

        public async Task<Response<List<Expenses>>> GetOfficeExpensesAsync(string memberId, string year, string quarter) =>
            await SendAsync<Response<List<Expenses>>>($"members/{memberId}/office_expenses/{year}/{quarter}.json");

        public async Task<Response<List<Expenses>>> GetMemberOfficeExpensesByCategoryAsync(string memberId, string category) =>
            await SendAsync<Response<List<Expenses>>>($"members/{memberId}/office_expenses/category/{category}.json");

        public async Task<Response<List<Expenses>>> GetOfficeExpensesByCategoryAsync(string category, string year, string quarter) =>
            await SendAsync<Response<List<Expenses>>>($"office_expenses/category/{category}/{year}/{quarter}.json");
        #endregion

    }
}
