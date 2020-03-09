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
            return _mapper.Map<List<BillModel>>(response.results.Select(m => m.bills).FirstOrDefault());
        }
        public BillModel GetBill(string congress, string billId)
        {
            var response = Send<BillsResponse<List<Bill>>>($"{congress}/bills/{billId}.json");
            return _mapper.Map<BillModel>(response.results.Select(b => b).FirstOrDefault());
        }
    }
}
