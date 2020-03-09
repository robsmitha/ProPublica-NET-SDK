using ProPublica.Entities.Bills;
using ProPublica.Interfaces;
using ProPublica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProPublica
{
    public class Bills : BaseAuthorization, IBills
    {
        public Bills(string apiKey) : base(apiKey) { }
        public List<BillModel> GetUpcomingBills(string chamber)
        {
            var response = Send<BillsResponse<List<UpcomingBills>>>($"bills/upcoming/{chamber}.json");
            if (response?.results == null) return new List<BillModel>();
            var data = response.results.Select(m => m.bills).FirstOrDefault();
            return data != null
                ? _mapper.Map<List<BillModel>>(data)
                : new List<BillModel>();
        }
        public BillModel GetBill(string congress, string billId)
        {
            var response = Send<BillsResponse<List<Bill>>>($"{congress}/bills/{billId}.json");
            if (response?.results == null) return new BillModel();
            var data = response.results.Select(b => b).FirstOrDefault();
            return data != null
                ? _mapper.Map<BillModel>(data)
                : new BillModel();
        }
    }
}
