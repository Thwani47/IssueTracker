using IssueTracker.DataAccess.Models.Team;

namespace IssueTracker.Api.Services.TeamService;

public interface ITeamService
{
    Task<TeamDataResult> DoGetAllTeams();

    Task<TeamDataResult> DoGetTeamById(string teamId);

    Task<TeamDataResult> DoAddNewTeam(AddTeamRequest request);
}