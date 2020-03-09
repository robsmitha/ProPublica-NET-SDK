using ProPublicaSDK.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProPublicaSDK.Interfaces
{
    public interface IStatements
    {
        List<StatementModel> GetRecentStatements();
        List<StatementModel> SearchStatements(string term);
    }
}
