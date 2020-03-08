using ProPublica.Entities;
using ProPublica.Entities.Bills;
using ProPublica.Entities.Committee;
using ProPublica.Entities.Lobbying;
using ProPublica.Entities.Members;
using ProPublica.Entities.Statements;
using ProPublica.Entities.Votes;
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

        private string GetRequestUri(string function) => Endpoint + (!function.StartsWith("/") ? $"/{function}" : function);
        private T Send<T>(string function)
        {
            using HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-API-Key", ApiKey);
            try
            {
                var requestUri = GetRequestUri(function);
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
                var requestUri = GetRequestUri(function);
                var response = await client.GetStringAsync(requestUri);
                return JsonSerializer.Deserialize<T>(response);
            }
            catch (HttpRequestException e)
            {
                throw e;
            }
        }

        #region Members

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

        #region Bills
        public BillsResponse<List<SearchBills>> SearchBills(string query) =>
            Send<BillsResponse<List<SearchBills>>>($"bills/search.json?query={query}");

        public async Task<BillsResponse<List<SearchBills>>> SearchBillsAsync(string query) =>
            await SendAsync<BillsResponse<List<SearchBills>>>($"bills/search.json?query={query}");

        public Response<List<Bill>> GetRecentBills(string congress, string chamber, string type) =>
            Send<Response<List<Bill>>>($"{congress}/{chamber}/bills/{type}.json");
        public async Task<Response<List<Bill>>> GetRecentBillsAsync(string congress, string chamber, string type) =>
            await SendAsync<Response<List<Bill>>>($"{congress}/{chamber}/bills/{type}.json");

        public BillsResponse<List<Bill>> GetRecentBillsBySubject(string subject) =>
            Send<BillsResponse<List<Bill>>>($"bills/subjects/{subject}.json");
        public async Task<BillsResponse<List<Bill>>> GetRecentBillsBySubjectAsync(string subject) =>
            await SendAsync<BillsResponse<List<Bill>>>($"bills/subjects/{subject}.json");

        public async Task<BillsResponse<List<UpcomingBills>>> GetUpcomingBillsAsync(string chamber) =>
            await SendAsync<BillsResponse<List<UpcomingBills>>>($"bills/upcoming/{chamber}.json");

        public BillsResponse<List<UpcomingBills>> GetUpcomingBills(string chamber) =>
            Send<BillsResponse<List<UpcomingBills>>>($"bills/upcoming/{chamber}.json");

        public async Task<BillsResponse<List<Bill>>> GetBillAsync(string congress, string billId) =>
            await SendAsync<BillsResponse<List<Bill>>>($"{congress}/bills/{billId}.json");
        public BillsResponse<List<Bill>> GetBill(string congress, string billId) =>
            Send<BillsResponse<List<Bill>>>($"{congress}/bills/{billId}.json");

        public async Task<Response<List<BillAmendments>>> GetBillAmendmentsAsync(string congress, string billId) =>
            await SendAsync<Response<List<BillAmendments>>>($"{congress}/bills/{billId}/amendments.json");
        public Response<List<BillAmendments>> GetBillAmendments(string congress, string billId) =>
            Send<Response<List<BillAmendments>>>($"{congress}/bills/{billId}/amendments.json");

        public async Task<Response<List<Bill>>> GetBillSubjectsAsync(string congress, string billId) =>
            await SendAsync<Response<List<Bill>>>($"{congress}/bills/{billId}/subjects.json");
        public Response<List<Bill>> GetBillSubjects(string congress, string billId) =>
            Send<Response<List<Bill>>>($"{congress}/bills/{billId}/subjects.json");

        public async Task<BillsResponse<List<Bill>>> GetRelatedBillsAsync(string congress, string billId) =>
            await SendAsync<BillsResponse<List<Bill>>>($"{congress}/bills/{billId}/related.json");
        public BillsResponse<List<Bill>> GetRelatedBills(string congress, string billId) =>
            Send<BillsResponse<List<Bill>>>($"{congress}/bills/{billId}/related.json");

        public async Task<Response<List<BillSubjects>>> GetBillsBySubjectAsync(string query) =>
            await SendAsync<Response<List<BillSubjects>>>($"bills/subjects/search.json?query={query}");
        public Response<List<BillSubjects>> GetBillsBySubject(string query) =>
            Send<Response<List<BillSubjects>>>($"bills/subjects/search.json?query={query}");

        public async Task<Response<List<BillCosponsors>>> GetBillCosponsorsAsync(string congress, string billId) =>
            await SendAsync<Response<List<BillCosponsors>>>($"{congress}/bills/{billId}/cosponsors.json");
        public Response<List<BillCosponsors>> GetBillCosponsors(string congress, string billId) =>
            Send<Response<List<BillCosponsors>>>($"{congress}/bills/{billId}/cosponsors.json");
        #endregion

        #region Votes
        public async Task<Response<RecentVotesResult>> GetRecentVotesAsync(string chamber) =>
            await SendAsync<Response<RecentVotesResult>>($"{chamber}/votes/recent.json");
        public Response<RecentVotesResult> GetRecentVotes(string chamber) =>
            Send<Response<RecentVotesResult>>($"{chamber}/votes/recent.json");

        public async Task<Response<List<VotesByTypeResult>>> GetVotesByTypeAsync(string congress, string chamber, string voteType) =>
            await SendAsync<Response<List<VotesByTypeResult>>>($"{congress}/{chamber}/votes/{voteType}.json");
        public Response<List<VotesByTypeResult>> GetVotesByType(string congress, string chamber, string voteType) =>
            Send<Response<List<VotesByTypeResult>>>($"{congress}/{chamber}/votes/{voteType}.json");

        public async Task<Response<VotesByDateResult>> GetVotesByDateAsync(string chamber, string year, string month) =>
            await SendAsync<Response<VotesByDateResult>>($"{chamber}/votes/{year}/{month}.json");
        public Response<VotesByDateResult> GetVotesByDate(string chamber, string year, string month) =>
            Send<Response<VotesByDateResult>>($"{chamber}/votes/{year}/{month}.json");

        public async Task<Response<VotesByDateResult>> GetVotesByRangeAsync(string chamber, string startDate, string endDate) =>
            await SendAsync<Response<VotesByDateResult>>($"{chamber}/votes/{startDate}/{endDate}.json");
        public Response<VotesByDateResult> GetVotesByRange(string chamber, string startDate, string endDate) =>
            Send<Response<VotesByDateResult>>($"{chamber}/votes/{startDate}/{endDate}.json");

        public async Task<Response<SenateNominationVotesResult>> GetSenateNominationVotesAsync(string congress) =>
            await SendAsync<Response<SenateNominationVotesResult>>($"{congress}/nominations.json");
        public Response<SenateNominationVotesResult> GetSenateNominationVotes(string congress) =>
            Send<Response<SenateNominationVotesResult>>($"{congress}/nominations.json");

        public async Task<Response<List<Explanation>>> GetRecentExplanationsAsync(string congress) =>
            await SendAsync<Response<List<Explanation>>>($"{congress}/explanations.json");
        public Response<List<Explanation>> GetRecentExplanations(string congress) =>
            Send<Response<List<Explanation>>>($"{congress}/explanations.json");
        public async Task<Response<List<Explanation>>> GetRecentExplanationVotesAsync(string congress) =>
            await SendAsync<Response<List<Explanation>>>($"{congress}/explanations/votes.json");
        public Response<List<Explanation>> GetRecentExplanationVotes(string congress) =>
            Send<Response<List<Explanation>>>($"{congress}/explanations/votes.json");

        public async Task<Response<List<Explanation>>> GetRecentExplanationVotesByCategoryAsync(string congress, string category) =>
            await SendAsync<Response<List<Explanation>>>($"{congress}/explanations/votes/{category}.json");
        public Response<List<Explanation>> GetRecentExplanationVotesByCategory(string congress, string category) =>
            Send<Response<List<Explanation>>>($"{congress}/explanations/votes/{category}.json");

        public async Task<ExplanationsResponse<IEnumerable<Explanation>>> GetRecentMemberExplanationsAsync(string memberId, string congress) =>
            await SendAsync<ExplanationsResponse<IEnumerable<Explanation>>>($"members/{memberId}/explanations/{congress}.json");
        public ExplanationsResponse<IEnumerable<Explanation>> GetRecentMemberExplanations(string memberId, string congress) =>
            Send<ExplanationsResponse<IEnumerable<Explanation>>>($"members/{memberId}/explanations/{congress}.json");

        public async Task<ExplanationsResponse<IEnumerable<Explanation>>> GetRecentMemberExplanationVotesAsync(string memberId, string congress) =>
            await SendAsync<ExplanationsResponse<IEnumerable<Explanation>>>($"members/{memberId}/explanations/{congress}/votes.json");
        public ExplanationsResponse<IEnumerable<Explanation>> GetRecentMemberExplanationVotes(string memberId, string congress) =>
            Send<ExplanationsResponse<IEnumerable<Explanation>>>($"members/{memberId}/explanations/{congress}/votes.json");

        public async Task<ExplanationsResponse<IEnumerable<Explanation>>> GetRecentMemberExplanationVotesByCategoryAsync(string memberId, string congress, string category) =>
            await SendAsync<ExplanationsResponse<IEnumerable<Explanation>>>($"members/{memberId}/explanations/{congress}/votes/{category}.json");
        public ExplanationsResponse<IEnumerable<Explanation>> GetRecentMemberExplanationVotesByCategory(string memberId, string congress, string category) =>
            Send<ExplanationsResponse<IEnumerable<Explanation>>>($"members/{memberId}/explanations/{congress}/votes/{category}.json");

        public async Task<Response<RollCallVoteResult>> GetRoleCallVoteAsync(string congress, string chamber, string sessionNumber, string rollCallNumber) =>
            await SendAsync<Response<RollCallVoteResult>>($"{congress}/{chamber}/sessions/{sessionNumber}/votes/{rollCallNumber}.json");
        public Response<RollCallVoteResult> GetRoleCallVote(string congress, string chamber, string sessionNumber, string rollCallNumber) =>
            Send<Response<RollCallVoteResult>>($"{congress}/{chamber}/sessions/{sessionNumber}/votes/{rollCallNumber}.json");
        #endregion

        #region Statements
        public async Task<StatementResponse<IEnumerable<Statement>>> GetRecentStatementsAsync() =>
            await SendAsync<StatementResponse<IEnumerable<Statement>>>($"/statements/latest.json");
        public StatementResponse<IEnumerable<Statement>> GetRecentStatements() =>
            Send<StatementResponse<IEnumerable<Statement>>>($"/statements/latest.json");

        public async Task<StatementResponse<IEnumerable<Statement>>> GetStatementsByDateAsync(string date) =>
            await SendAsync<StatementResponse<IEnumerable<Statement>>>($"/statements/date/{date}.json");
        public StatementResponse<IEnumerable<Statement>> GetStatementsByDate(string date) =>
            Send<StatementResponse<IEnumerable<Statement>>>($"/statements/date/{date}.json");

        public async Task<StatementResponse<IEnumerable<Statement>>> SearchStatementsAsync(string term) =>
            await SendAsync<StatementResponse<IEnumerable<Statement>>>($"/statements/search.json?query={term}");
        public StatementResponse<IEnumerable<Statement>> SearchStatements(string term) =>
            Send<StatementResponse<IEnumerable<Statement>>>($"/statements/search.json?query={term}");

        public async Task<StatementResponse<IEnumerable<Subject>>> GetStatementSubjectsAsync() =>
            await SendAsync<StatementResponse<IEnumerable<Subject>>>($"/statements/subjects.json");
        public StatementResponse<IEnumerable<Subject>> GetStatementSubjects() =>
            Send<StatementResponse<IEnumerable<Subject>>>($"/statements/subjects.json");

        public async Task<StatementResponse<IEnumerable<Statement>>> GetStatementsBySubjectAsync(string subject) =>
            await SendAsync<StatementResponse<IEnumerable<Statement>>>($"/statements/subject/{subject}.json");
        public StatementResponse<IEnumerable<Statement>> GetStatementsBySubject(string subject) =>
            Send<StatementResponse<IEnumerable<Statement>>>($"/statements/subject/{subject}.json");

        public async Task<StatementResponse<IEnumerable<Statement>>> GetStatementsByMemberAsync(string memberId, int congress) =>
            await SendAsync<StatementResponse<IEnumerable<Statement>>>($"/members/{memberId}/statements/{congress}.json");
        public StatementResponse<IEnumerable<Statement>> GetStatementsByMember(string memberId, int congress) =>
            Send<StatementResponse<IEnumerable<Statement>>>($"/members/{memberId}/statements/{congress}.json");

        public async Task<StatementResponse<IEnumerable<Statement>>> GetStatementsByBillAsync(int congress, string billId) =>
            await SendAsync<StatementResponse<IEnumerable<Statement>>>($"{congress}/bills/{billId}/statements");
        public StatementResponse<IEnumerable<Statement>> GetStatementsByBill(int congress, string billId) =>
            Send<StatementResponse<IEnumerable<Statement>>>($"{congress}/bills/{billId}/statements");

        public async Task<StatementResponse<IEnumerable<Statement>>> GetRecentCommitteeStatementsAsync() =>
            await SendAsync<StatementResponse<IEnumerable<Statement>>>($"statements/committees/latest.json");
        public StatementResponse<IEnumerable<Statement>> GetRecentCommitteeStatements() =>
            Send<StatementResponse<IEnumerable<Statement>>>($"statements/committees/latest.json");

        public async Task<StatementResponse<IEnumerable<Statement>>> GetCommitteeStatementsByDateAsync(string date) =>
            await SendAsync<StatementResponse<IEnumerable<Statement>>>($"statements/committees/date/{date}.json");
        public StatementResponse<IEnumerable<Statement>> GetCommitteeStatementsByDate(string date) =>
           Send<StatementResponse<IEnumerable<Statement>>>($"statements/committees/date/{date}.json");

        public async Task<StatementResponse<IEnumerable<Statement>>> GetCommitteeStatementsByCommitteeAsync(string committeeId) =>
            await SendAsync<StatementResponse<IEnumerable<Statement>>>($"statements/committees/{committeeId}.json");
        public StatementResponse<IEnumerable<Statement>> GetCommitteeStatementsByCommittee(string committeeId) =>
            Send<StatementResponse<IEnumerable<Statement>>>($"statements/committees/{committeeId}.json");

        public async Task<StatementResponse<IEnumerable<Statement>>> SearchCommitteeStatementsAsync(string term) =>
            await SendAsync<StatementResponse<IEnumerable<Statement>>>($"statements/committees/search.json?query={term}");
        public StatementResponse<IEnumerable<Statement>> SearchCommitteeStatements(string term) =>
            Send<StatementResponse<IEnumerable<Statement>>>($"statements/committees/search.json?query={term}");
        #endregion

        #region Committees
        public async Task<Response<IEnumerable<CommitteeListResult>>> GetCommitteesAsync(string congress, string chamber) =>
            await SendAsync<Response<IEnumerable<CommitteeListResult>>>($"{congress}/{chamber}/committees.json");
        public Response<IEnumerable<CommitteeListResult>> GetCommittees(string congress, string chamber) =>
            Send<Response<IEnumerable<CommitteeListResult>>>($"{congress}/{chamber}/committees.json");

        public async Task<Response<IEnumerable<CommitteeResult>>> GetCommitteeAsync(string congress, string chamber, string committeeId) =>
            await SendAsync<Response<IEnumerable<CommitteeResult>>>($"{congress}/{chamber}/committees/{committeeId}.json");
        public Response<IEnumerable<CommitteeResult>> GetCommittee(string congress, string chamber, string committeeId) =>
            Send<Response<IEnumerable<CommitteeResult>>>($"{congress}/{chamber}/committees/{committeeId}.json");

        public async Task<Response<IEnumerable<HearingResult>>> GetCommitteeHearingsAsync(string congress) =>
            await SendAsync<Response<IEnumerable<HearingResult>>>($"{congress}/committees/hearings.json");
        public Response<IEnumerable<HearingResult>> GetCommitteeHearings(string congress) =>
            Send<Response<IEnumerable<HearingResult>>>($"{congress}/committees/hearings.json");

        public async Task<Response<IEnumerable<HearingResult>>> GetCommitteeHearingsByCommitteeAsync(string congress, string chamber, string committeeId) =>
            await SendAsync<Response<IEnumerable<HearingResult>>>($"{congress}/{chamber}/committees/{committeeId}/hearings.json");
        public Response<IEnumerable<HearingResult>> GetCommitteeHearingsByCommittee(string congress, string chamber, string committeeId) =>
            Send<Response<IEnumerable<HearingResult>>>($"{congress}/{chamber}/committees/{committeeId}/hearings.json");
        #endregion

        #region Lobbying
        public async Task<Response<IEnumerable<LobbyingListResult>>> GetRecentLobbyingAsync() =>
            await SendAsync<Response<IEnumerable<LobbyingListResult>>>($"lobbying/latest.json");
        public Response<IEnumerable<LobbyingListResult>> GetRecentLobbying() =>
            Send<Response<IEnumerable<LobbyingListResult>>>($"lobbying/latest.json");

        public async Task<Response<IEnumerable<LobbyingListResult>>> SearchLobbyingAsync(string query) =>
            await SendAsync<Response<IEnumerable<LobbyingListResult>>>($"lobbying/search.json?query={query}");
        public Response<IEnumerable<LobbyingListResult>> SearchLobbying(string query) =>
            Send<Response<IEnumerable<LobbyingListResult>>>($"lobbying/search.json?query={query}");

        public async Task<Response<IEnumerable<LobbyingRepresentation>>> GetLobbyingByFilingAsync(string filingId) =>
            await SendAsync<Response<IEnumerable<LobbyingRepresentation>>>($"lobbying/{filingId}.json");
        public Response<IEnumerable<LobbyingRepresentation>> GetLobbyingByFiling(string filingId) =>
            Send<Response<IEnumerable<LobbyingRepresentation>>>($"lobbying/{filingId}.json");
        #endregion

    }
}
