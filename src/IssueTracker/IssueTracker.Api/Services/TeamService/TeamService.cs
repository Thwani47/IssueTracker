using System.Data;
using Dapper;
using IssueTracker.DataAccess;
using IssueTracker.DataAccess.Constants;
using IssueTracker.DataAccess.Models;
using IssueTracker.DataAccess.Models.Team;
using IssueTracker.DataAccess.Providers;

namespace IssueTracker.Api.Services.TeamService;

public class TeamService : ITeamService
{
    private readonly IDataAccess _dapperDataAccess;

    public TeamService(IDataAccess dapperDataAccess)
    {
        _dapperDataAccess = dapperDataAccess;
    }

    public async Task<TeamDataResult> DoGetAllTeams()
    {
        var teams = await _dapperDataAccess.QueryAsync<Team>(SqlDatabaseProvider.IssueTrackerDatabase,
            DatabaseConstants.GetAllTeamsStoredProc);

        var enumerable = teams.ToList();
        if (enumerable.Any())
        {
            return new TeamDataResult
            {
                Status = AuthRequestStatus.Success,
                Message = "Teams found",
                Data = new Dictionary<string, object>
                {
                    {"teams", enumerable}
                }
            };
        }

        return new TeamDataResult
        {
            Status = AuthRequestStatus.Failure,
            Message = "No teams found"
        };
    }

    public async Task<TeamDataResult> DoGetTeamById(string teamId)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@TeamId", teamId);
        var teams = await _dapperDataAccess.QueryAsync<Team>(SqlDatabaseProvider.IssueTrackerDatabase,
            DatabaseConstants.GetTeamByIdStoredProc, parameters);

        var enumerable = teams as Team[] ?? teams.ToArray();
        if (enumerable.Any())
        {
            return new TeamDataResult
            {
                Message = "Team found",
                Status = AuthRequestStatus.Success,
                Data = new Dictionary<string, object>
                {
                    { "team", enumerable.First() }
                }
            };
        }

        return new TeamDataResult
        {
            Status = AuthRequestStatus.Failure,
            Message = "Team not found"
        };
    }

    public async Task<TeamDataResult> DoAddNewTeam(AddTeamRequest request)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@TeamName", request.TeamName);
        parameters.Add("@TeamLead", request.TeamLead);
        parameters.Add("@ResponseMessage", dbType: DbType.String, size:100, direction: ParameterDirection.Output);
        await _dapperDataAccess.ExecuteAsync(SqlDatabaseProvider.IssueTrackerDatabase,
            DatabaseConstants.AddNewTeamStoredProc, parameters);

        var response = parameters.Get<string>("ResponseMessage");

        if (response.Equals("Team Added Successfully"))
        {
            return new TeamDataResult
            {
                Status = AuthRequestStatus.Success,
                Message = response
            };
        }

        return new TeamDataResult
        {
            Message = $"Failed to add team. {response}",
            Status = AuthRequestStatus.Failure
        };
    }
}