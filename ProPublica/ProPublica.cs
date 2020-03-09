using AutoMapper;
using ProPublica.Entities;
using ProPublica.Entities.Bills;
using ProPublica.Entities.Committee;
using ProPublica.Entities.Lobbying;
using ProPublica.Entities.Members;
using ProPublica.Entities.Statements;
using ProPublica.Entities.Votes;
using ProPublica.Interfaces;
using ProPublica.Models;
using ProPublica.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProPublica
{
    public class ProPublica
    {
        private string ApiKey { get; set; }
        public ProPublica(string apiKey) 
        {
            ApiKey = apiKey;
        }

        private Members members;
        public Members Members
        {
            get => members ??= new Members(ApiKey);
            set => members = value;
        }

        private Bills bills;
        public Bills Bills
        {
            get => bills ??= new Bills(ApiKey);
            set => bills = value;
        }

    }
}
