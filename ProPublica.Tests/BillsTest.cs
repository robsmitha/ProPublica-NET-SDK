using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProPublica.Tests
{
    public class BillsTest : BaseTest
    {
        [Test]
        public void GetRecentBillsTest()
        {
            var response = _api.GetUpcomingBills(HOUSE);
            var bills = response.results.Select(m => m.bills).FirstOrDefault();
            Assert.IsNotNull(bills);
        }

        [Test]
        public void GetBill()
        {
            var upcomingBillResponse = _api.GetUpcomingBills(HOUSE);
            var bills = upcomingBillResponse.results.Select(m => m.bills).FirstOrDefault();
            var upcomingBill = bills.FirstOrDefault();
            var billId = upcomingBill?.bill_slug;
            var billResponse = _api.GetBill(upcomingBill?.congress, billId);
            var bill = billResponse.results.Select(b => b).FirstOrDefault();
            Assert.IsNotNull(bill);
        }
    }
}
