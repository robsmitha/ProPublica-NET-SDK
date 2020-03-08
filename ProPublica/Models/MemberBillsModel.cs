using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProPublica.Models
{
    public class MemberBillsModel
    {
        public List<BillModel> bills { get; set; }
        public MemberModel Member { get; set; }
        public MemberBillsModel(List<BillModel> bills, MemberModel member)
        {
            this.bills = bills;
            Member = member;
        }
    }
}
