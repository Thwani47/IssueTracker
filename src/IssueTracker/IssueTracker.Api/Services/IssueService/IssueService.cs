using System.Data;
using Dapper;
using IssueTracker.DataAccess;
using IssueTracker.DataAccess.Constants;
using IssueTracker.DataAccess.Models;
using IssueTracker.DataAccess.Models.Issue;
using IssueTracker.DataAccess.Providers;

namespace IssueTracker.Api.Services.IssueService;

public class IssueService : IIssueService
{
    private readonly IDataAccess _dapperDataAccess;

    public IssueService(IDataAccess dapperDataAccess)
    {
        _dapperDataAccess = dapperDataAccess;
    }

    public async Task<IssueDataResult> DoGetAllIssues()
    {
        var issues = await _dapperDataAccess.QueryAsync<Issue>(SqlDatabaseProvider.IssueTrackerDatabase,
            DatabaseConstants.GetAllIssuesStoredProc);

        var enumerable = issues.ToList();
        if (enumerable.Any())
        {
            return new IssueDataResult
            {
                Status = AuthRequestStatus.Success,
                Message = "Issues found",
                Data = new Dictionary<string, object>
                {
                    { "issues", enumerable }
                }
            };
        }

        return new IssueDataResult
        {
            Status = AuthRequestStatus.Success,
            Message = "No issues found",
            Data = new Dictionary<string, object>
            {
                { "issues", new List<Issue>() }
            }
        };
    }

    public async Task<IssueDataResult> DoGetIssueById(string issueId)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@IssueId", issueId);
        var issues = await _dapperDataAccess.QueryAsync<Issue>(SqlDatabaseProvider.IssueTrackerDatabase,
            DatabaseConstants.GetIssueByIdStoredProc, parameters);

        var enumerable = issues as Issue[] ?? issues.ToArray();
        if (enumerable.Any())
        {
            return new IssueDataResult
            {
                Message = "Issue found",
                Status = AuthRequestStatus.Success,
                Data = new Dictionary<string, object>
                {
                    { "issue", enumerable.First() }
                }
            };
        }

        return new IssueDataResult
        {
            Status = AuthRequestStatus.Failure,
            Message = "Issue not found"
        };
    }

    public async Task<IssueDataResult> DoAddNewIssue(AddIssueRequest request)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@IssueTitle", request.IssueTitle);
        parameters.Add("@IssueDescription", request.IssueDescription);
        parameters.Add("@ProductId", request.ProductId);
        parameters.Add("@IssuePriority", (int)request.IssuePriority);
        parameters.Add("@ResponseMessage", dbType: DbType.String, size: 100, direction: ParameterDirection.Output);
        await _dapperDataAccess.ExecuteAsync(SqlDatabaseProvider.IssueTrackerDatabase,
            DatabaseConstants.AddNewIssueStoredProc, parameters);

        var response = parameters.Get<string>("ResponseMessage");

        if (response.Equals("Issue Added Successfully"))
        {
            return new IssueDataResult
            {
                Status = AuthRequestStatus.Success,
                Message = response
            };
        }

        return new IssueDataResult
        {
            Message = $"Failed to add issue. {response}",
            Status = AuthRequestStatus.Failure
        };
    }

    public async Task<IssueDataResult> DoUpdateIssueStatus(UpdateIssueStatusRequest request)
    {
        var (issueExists, _) = await CheckIssueExists(request.IssueId);
        if (!issueExists)
        {
            return new IssueDataResult
            {
                Status = AuthRequestStatus.Failure,
                Message = "Issue not found"
            };
        }

        var parameters = new DynamicParameters();
        parameters.Add("@IssueId", request.IssueId);
        parameters.Add("@Status", request.IssueStatus);
        parameters.Add("@ResponseMessage", dbType: DbType.String, size: 100, direction: ParameterDirection.Output);
        await _dapperDataAccess.ExecuteAsync(SqlDatabaseProvider.IssueTrackerDatabase,
            DatabaseConstants.UpdateIssueStatusStoredProc, parameters);

        var response = parameters.Get<string>("ResponseMessage");

        if (response.Equals("Issue Updated Successfully"))
        {
            return new IssueDataResult
            {
                Status = AuthRequestStatus.Success,
                Message = response
            };
        }

        return new IssueDataResult
        {
            Message = $"Failed to update issue. {response}",
            Status = AuthRequestStatus.Failure
        };
    }

    public async Task<IssueDataResult> DoUpdateIssuePriority(UpdateIssuePriorityRequest request)
    {
        var (issueExists, _) = await CheckIssueExists(request.IssueId);
        if (!issueExists)
        {
            return new IssueDataResult
            {
                Status = AuthRequestStatus.Failure,
                Message = "Issue not found"
            };
        }

        var parameters = new DynamicParameters();
        parameters.Add("@IssueId", request.IssueId);
        parameters.Add("@Priority", request.IssuePriority);
        parameters.Add("@ResponseMessage", dbType: DbType.String, size: 100, direction: ParameterDirection.Output);
        await _dapperDataAccess.ExecuteAsync(SqlDatabaseProvider.IssueTrackerDatabase,
            DatabaseConstants.UpdateIssuePriorityStoredProc, parameters);

        var response = parameters.Get<string>("ResponseMessage");

        if (response.Equals("Issue Updated Successfully"))
        {
            return new IssueDataResult
            {
                Status = AuthRequestStatus.Success,
                Message = response
            };
        }

        return new IssueDataResult
        {
            Message = $"Failed to update issue. {response}",
            Status = AuthRequestStatus.Failure
        };
    }

    public async Task<IssueDataResult> DoUpdateIssueAssignee(UpdateIssueAssigneeRequest request)
    {
        var (issueExists, _) = await CheckIssueExists(request.IssueId);
        if (!issueExists)
        {
            return new IssueDataResult
            {
                Status = AuthRequestStatus.Failure,
                Message = "Issue not found"
            };
        }

        var parameters = new DynamicParameters();
        parameters.Add("@IssueId", request.IssueId);
        parameters.Add("@Assignee", request.AssigneeId);
        parameters.Add("@ResponseMessage", dbType: DbType.String, size: 100, direction: ParameterDirection.Output);
        await _dapperDataAccess.ExecuteAsync(SqlDatabaseProvider.IssueTrackerDatabase,
            DatabaseConstants.UpdateIssueAssigneeStoredProc, parameters);

        var response = parameters.Get<string>("ResponseMessage");

        if (response.Equals("Issue Updated Successfully"))
        {
            return new IssueDataResult
            {
                Status = AuthRequestStatus.Success,
                Message = response
            };
        }

        return new IssueDataResult
        {
            Message = $"Failed to update issue. {response}",
            Status = AuthRequestStatus.Failure
        };
    }

    private async Task<(bool, Issue?)> CheckIssueExists(Guid issueId)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@IssueId", issueId);
        var issues = await _dapperDataAccess.QueryAsync<Issue>(SqlDatabaseProvider.IssueTrackerDatabase,
            DatabaseConstants.GetIssueByIdStoredProc, parameters);

        var enumerable = issues.ToList();
        return (enumerable.Any(), enumerable.FirstOrDefault());
    }
}