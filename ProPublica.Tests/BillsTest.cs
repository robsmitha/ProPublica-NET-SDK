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
            var bills = _api.GetUpcomingBills(HOUSE);
            Assert.IsNotNull(bills);
        }

        [Test]
        public void GetBill()
        {
            var bills = _api.GetUpcomingBills(HOUSE);
            var upcomingBill = bills.FirstOrDefault();
            var bill = _api.GetBill(upcomingBill?.congress, upcomingBill?.bill_slug);
            Assert.IsNotNull(bill);
        }
    }
}
