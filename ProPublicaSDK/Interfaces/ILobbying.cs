using ProPublicaSDK.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProPublicaSDK.Interfaces
{
    public interface ILobbying
    {
        List<LobbyingRepresentationModel> GetRecentLobbyingRepresentations();
    }
}
