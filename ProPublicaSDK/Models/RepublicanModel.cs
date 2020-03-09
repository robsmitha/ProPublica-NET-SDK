using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProPublicaSDK.Models
{
    public class RepublicanModel
    {
        public int yes { get; set; }
        public int no { get; set; }
        public int present { get; set; }
        public int not_voting { get; set; }
        public string majority_position { get; set; }
    }
}
