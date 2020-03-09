using ProPublicaSDK.Entities;
using ProPublicaSDK.Entities.Committee;
using ProPublicaSDK.Interfaces;
using ProPublicaSDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProPublicaSDK
{
    public class Committees : BaseAuthorization, ICommittees
    {
        public Committees(string apiKey) : base(apiKey) { }
        public CommitteeModel GetCommittee(string committeeId, string congress, string chamber)
        {
            var response = Send<Response<IEnumerable<CommitteeResult>>>($"{congress}/{chamber}/committees/{committeeId}.json");
            if (response?.results == null) return new CommitteeModel();

            var data = response.results.FirstOrDefault();
            return _mapper.Map<CommitteeModel>(data);
        }

        public List<CommitteeModel> GetCommittees(string congress, string chamber)
        {
            var response = Send<Response<IEnumerable<CommitteeListResult>>>($"{congress}/{chamber}/committees.json");
            if (response.results == null) return new List<CommitteeModel>();

            var data = response.results.Select(m => m.committees).FirstOrDefault();
            return data != null
                ? _mapper.Map<List<CommitteeModel>>(data)
                : new List<CommitteeModel>();
        }
    }
}
