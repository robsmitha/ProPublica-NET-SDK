using NUnit.Framework;
using ProPublica.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProPublica.Tests
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
