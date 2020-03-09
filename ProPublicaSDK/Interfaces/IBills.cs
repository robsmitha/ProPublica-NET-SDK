using ProPublicaSDK.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProPublicaSDK.Interfaces
{
    public interface IBills
    {
        List<BillModel> GetUpcomingBills(string chamber);
        BillModel GetBill(string congress, string billId);
    }
}
