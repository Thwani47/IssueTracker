using System.Diagnostics.CodeAnalysis;

#pragma warning disable CS8618
namespace IssueTracker.DataAccess.Models.Authentication;

[SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
public class RegisterResult : BaseResult
{
    public Dictionary<string, object> Data { get; set; }
}