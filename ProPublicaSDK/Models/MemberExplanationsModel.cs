using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProPublicaSDK.Models
{
    public class MemberExplanationsModel
    {
        public MemberModel Member { get; set; }
        public List<ExplanationModel> Explanations { get; set; }
        public MemberExplanationsModel(List<ExplanationModel> explanations, MemberModel member)
        {
            Member = member;
            Explanations = explanations;
        }
    }
}
