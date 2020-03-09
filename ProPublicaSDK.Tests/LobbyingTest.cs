using NUnit.Framework;
using ProPublicaSDK.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProPublicaSDK.Tests
{
    public class LobbyingTest : BaseTest
    {
        private List<LobbyingRepresentationModel> lobbyingRepresentations;
        private List<LobbyingRepresentationModel> LobbyingRepresentations
        {
            get => lobbyingRepresentations ??= ProPublica.Lobbying.GetRecentLobbyingRepresentations();
            set => lobbyingRepresentations = value;
        }

        [Test]
        public void GetRecentLobbyingRepresentations()
        {
            Assert.IsNotNull(LobbyingRepresentations);
        }
    }
}
