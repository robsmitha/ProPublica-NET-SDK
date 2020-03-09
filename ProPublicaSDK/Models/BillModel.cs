﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProPublicaSDK.Models
{
    public class BillModel
    {
        public string bill_id { get; set; }
        public string bill_slug { get; set; }
        public string congress { get; set; }
        public string bill { get; set; }
        public string bill_type { get; set; }
        public string number { get; set; }
        public string bill_uri { get; set; }
        public string title { get; set; }
        public string short_title { get; set; }
        public string sponsor_title { get; set; }
        public string sponsor { get; set; }
        public string sponsor_id { get; set; }
        public string sponsor_uri { get; set; }
        public string sponsor_party { get; set; }
        public string sponsor_state { get; set; }
        public string gpo_pdf_uri { get; set; }
        public string congressdotgov_url { get; set; }
        public string govtrack_url { get; set; }
        public string introduced_date { get; set; }
        public bool? active { get; set; }
        public string last_vote { get; set; }
        public string house_passage { get; set; }
        public string senate_passage { get; set; }
        public string enacted { get; set; }
        public string vetoed { get; set; }
        public int? cosponsors { get; set; }
        public CosponsorsByPartyModel cosponsors_by_party { get; set; }
        public int? withdrawn_cosponsors { get; set; }
        public string primary_subject { get; set; }
        public string committees { get; set; }
        public List<string> committee_codes { get; set; }
        public List<string> subcommittee_codes { get; set; }
        public string latest_major_action_date { get; set; }
        public string latest_major_action { get; set; }
        public string house_passage_vote { get; set; }
        public string senate_passage_vote { get; set; }
        public string summary { get; set; }
        public string summary_short { get; set; }
        public DateTime? scheduled_at { get; set; }
        public string consideration { get; set; }
        public List<VersionModel> versions { get; set; }
        public List<ActionModel> actions { get; set; }
        public List<VoteModel> votes { get; set; }
        public List<BillModel> related_bills { get; set; }
        public List<SubjectModel> subjects { get; set; }
        public List<StatementModel> statments { get; set; }
    }
}
