using ProPublica.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProPublica.Interfaces
{
    public interface IBills
    {
        List<BillModel> GetUpcomingBills(string chamber);
        BillModel GetBill(string congress, string billId);
    }
}
