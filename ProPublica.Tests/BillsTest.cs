using NUnit.Framework;
using ProPublica.Interfaces;
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
            var bills = ProPublica.Bills.GetUpcomingBills(HOUSE);
            Assert.IsNotNull(bills);
        }

        [Test]
        public void GetBill()
        {
            var bills = ProPublica.Bills.GetUpcomingBills(HOUSE);
            var upcomingBill = bills.FirstOrDefault();
            var bill = ProPublica.Bills.GetBill(upcomingBill?.congress, upcomingBill?.bill_slug);
            Assert.IsNotNull(bill);
        }
    }
}
