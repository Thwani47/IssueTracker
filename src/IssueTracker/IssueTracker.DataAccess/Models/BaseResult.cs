using System.Diagnostics.CodeAnalysis;
#pragma warning disable CS8618
namespace IssueTracker.DataAccess.Models;

[SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
[SuppressMessage("ReSharper", "PropertyCanBeMadeInitOnly.Global")]
public class BaseResult
{
    public AuthRequestStatus Status { get; set; } 
    public string Message { get; set; }
    public Dictionary<string, object> Data { get; set; }
}