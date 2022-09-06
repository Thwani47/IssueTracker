using System.Diagnostics.CodeAnalysis;
#pragma warning disable CS8618
namespace IssueTracker.DataAccess.Models.Users;

[SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
public class UserDataResult : BaseResult
{
    public Dictionary<string, object> Data { get; set; }
}