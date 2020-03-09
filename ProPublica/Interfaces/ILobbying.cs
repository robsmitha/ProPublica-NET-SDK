using ProPublica.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProPublica.Interfaces
{
    public interface ILobbying
    {
        List<LobbyingRepresentationModel> GetRecentLobbyingRepresentations();
    }
}
