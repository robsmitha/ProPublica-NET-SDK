using ProPublica.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProPublica.Interfaces
{
    public interface IStatements
    {
        List<StatementModel> GetRecentStatements();
        List<StatementModel> SearchStatements(string term);
    }
}
