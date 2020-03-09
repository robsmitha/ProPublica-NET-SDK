using ProPublicaSDK.Entities.Statements;
using ProPublicaSDK.Interfaces;
using ProPublicaSDK.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProPublicaSDK
{
    public class Statements : BaseAuthorization, IStatements
    {
        public Statements(string apiKey) : base(apiKey) { }

        public List<StatementModel> GetRecentStatements()
        {
            var response = Send<StatementResponse<IEnumerable<Statement>>>($"/statements/latest.json");
            if (response?.results != null) return new List<StatementModel>();
            var data = response.results;
            return _mapper.Map<List<StatementModel>>(data);
        }

        public List<StatementModel> SearchStatements(string term)
        {
            var response = Send<StatementResponse<IEnumerable<Statement>>>($"/statements/search.json?query={term}");
            if (response?.results == null) return new List<StatementModel>();
            var data = response.results;
            return _mapper.Map<List<StatementModel>>(data);
        }
    }
}
