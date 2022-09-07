using System.Diagnostics.CodeAnalysis;
// ReSharper disable ClassNeverInstantiated.Global

#pragma warning disable CS8618

namespace IssueTracker.DataAccess.Models.Products;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
public class Product
{
    public Guid ProductId { get; set; }
    public string ProductName { get; set; }
    public Guid TeamId { get; set; }
    public string TeamName { get; set; }
}