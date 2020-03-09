using NUnit.Framework;
using ProPublica.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProPublica.Tests
{
    public class StatementsTest : BaseTest
    {
        private List<StatementModel> statements;
        public List<StatementModel> Statements
        {
            get => statements ??= ProPublica.Statements.GetRecentStatements();
            set => statements = value;
        }
        [Test]
        public void GetRecentStatements()
        {
            Assert.IsNotNull(Statements);
        }
        [Test]
        public void SearchStatements()
        {
            var statements = ProPublica.Statements.SearchStatements("oil");
            Assert.IsNotNull(statements);
        }
    }
}
