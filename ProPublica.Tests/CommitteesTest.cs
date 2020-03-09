using NUnit.Framework;
using ProPublica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProPublica.Tests
{
    public class CommitteesTest : BaseTest
    {
        private List<CommitteeModel> committees;
        public List<CommitteeModel>Committees
        {
            get => committees ??= ProPublica.Committees.GetCommittees(DEFAULT_CONGRESS, HOUSE);
            set => committees = value;
        }
        [Test]
        public void GetCommittees() 
        {
            Assert.IsNotNull(Committees);
        }
        [Test]
        public void GetCommittee()
        {
            var committee = Committees.FirstOrDefault();
            Assert.IsNotNull(committee);
        }
    }
}
