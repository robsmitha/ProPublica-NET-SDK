using AutoMapper;
using ProPublicaSDK.Models;
using System.Text.RegularExpressions;

namespace ProPublicaSDK.Utilities
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Entities.Members.MemberListItem, MemberModel>();

            CreateMap<Entities.Members.Member, MemberModel>()
                .ForMember(m => m.party, opt => opt.MapFrom( src => src.current_party))
                .ForMember(m => m.id, opt => opt.MapFrom(src => src.member_id));

            CreateMap<Entities.Members.Role, RoleModel>();
            CreateMap<Entities.Members.CompareVotePositionsResult, CompareVotePositionsModel>();

            CreateMap<Entities.Bills.Bill, BillModel>();
            CreateMap<Entities.Bills.Vote, VoteModel>();
            CreateMap<Entities.Bills.Action, ActionModel>();
            CreateMap<Entities.Bills.Version, VersionModel>();
            CreateMap<Entities.Bills.CosponsorsByParty, CosponsorsByPartyModel>();
            CreateMap<Entities.Bills.Amendment, AmendmentModel>();

            CreateMap<Entities.Bills.UpcomingBill, BillModel>()
                .ForMember(m => m.title, opt => opt.MapFrom(src => src.description))
                .ForMember(m => m.bill_id, opt => opt.MapFrom(src => src.bill_slug));


            CreateMap<Entities.Votes.Vote, VoteModel>();
            CreateMap<Entities.Votes.Position, PositionModel>();
            CreateMap<Entities.Votes.Democratic, DemocraticModel>();
            CreateMap<Entities.Votes.Republican, RepublicanModel>();
            CreateMap<Entities.Votes.Independent, IndependentModel>();
            CreateMap<Entities.Votes.Total, TotalModel>();

            CreateMap<Entities.Subject, SubjectModel>();
            CreateMap<Entities.Members.Expenses, ExpensesModel>();
            CreateMap<Entities.Statements.Statement, StatementModel>();
            CreateMap<Entities.Votes.Explanation, ExplanationModel>();

            CreateMap<Entities.Committee.Committee, CommitteeModel>();
            CreateMap<Entities.Committee.CommitteeResult, CommitteeModel>();
            CreateMap<Entities.Committee.Subcommittee, SubcommitteeModel>();
            CreateMap<Entities.Committee.Hearing, HearingModel>();
            CreateMap<Entities.Committee.FormerMember, CommitteeMemberModel>();
            CreateMap<Entities.Committee.CurrentMember, CommitteeMemberModel>();

            CreateMap<Entities.Lobbying.Filing, FilingModel>();
            CreateMap<Entities.Lobbying.LobbyingClient, LobbyingClientModel>();
            CreateMap<Entities.Lobbying.LobbyingRegistrant, LobbyingRegistrantModel>();
            CreateMap<Entities.Lobbying.LobbyingRepresentation, LobbyingRepresentationModel>();
            CreateMap<Entities.Lobbying.Lobbyist, LobbyistModel>();
        }
    }
}
