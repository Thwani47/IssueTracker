using IssueTracker.DataAccess.Models.Issue;

namespace IssueTracker.Api.Services.IssueService;

public interface IIssueService
{
    Task<IssueDataResult> DoGetAllIssues();
    Task<IssueDataResult> DoGetIssueById(string issueId);
    Task<IssueDataResult> DoAddNewIssue(AddIssueRequest request);
    Task<IssueDataResult> DoUpdateIssueStatus(UpdateIssueStatusRequest request);
    Task<IssueDataResult> DoUpdateIssuePriority(UpdateIssuePriorityRequest request);
    Task<IssueDataResult> DoUpdateIssueAssignee(UpdateIssueAssigneeRequest request);
}