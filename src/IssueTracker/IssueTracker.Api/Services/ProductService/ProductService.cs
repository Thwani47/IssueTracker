using System.Data;
using Dapper;
using IssueTracker.DataAccess;
using IssueTracker.DataAccess.Constants;
using IssueTracker.DataAccess.Models;
using IssueTracker.DataAccess.Models.Products;
using IssueTracker.DataAccess.Providers;

namespace IssueTracker.Api.Services.ProductService;

public class ProductService : IProductService
{
    private readonly IDataAccess _dapperDataAccess;

    public ProductService(IDataAccess dapperDataAccess)
    {
        _dapperDataAccess = dapperDataAccess;
    }

    public async Task<ProductDataResult> DoGetAllProducts()
    {
        var products = await _dapperDataAccess.QueryAsync<Product>(SqlDatabaseProvider.IssueTrackerDatabase,
            DatabaseConstants.GetAllProductsStoredProc);

        var enumerable = products.ToList();
        if (enumerable.Any())
        {
            return new ProductDataResult
            {
                Status = AuthRequestStatus.Success,
                Message = "Products found",
                Data = new Dictionary<string, object>
                {
                    { "products", enumerable }
                }
            };
        }

        return new ProductDataResult
        {
            Status = AuthRequestStatus.Success,
            Message = "No products found",
            Data = new Dictionary<string, object>
            {
                { "products", new List<Product>() }
            }
        };
    }

    public async Task<ProductDataResult> DoGetProductById(string productId)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@ProductId", productId);
        var products = await _dapperDataAccess.QueryAsync<Product>(SqlDatabaseProvider.IssueTrackerDatabase,
            DatabaseConstants.GetProductByIdStoredProc, parameters);

        var enumerable = products as Product[] ?? products.ToArray();
        if (enumerable.Any())
        {
            return new ProductDataResult
            {
                Message = "Product found",
                Status = AuthRequestStatus.Success,
                Data = new Dictionary<string, object>
                {
                    { "product", enumerable.First() }
                }
            };
        }

        return new ProductDataResult
        {
            Status = AuthRequestStatus.Failure,
            Message = "Product not found"
        };
    }

    public async Task<ProductDataResult> DoAddNewProduct(AddProductRequest request)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@ProductName", request.ProductName);
        parameters.Add("@TeamId", request.TeamId);
        parameters.Add("@ResponseMessage", dbType: DbType.String, size: 100, direction: ParameterDirection.Output);
        await _dapperDataAccess.ExecuteAsync(SqlDatabaseProvider.IssueTrackerDatabase,
            DatabaseConstants.AddNewProductStoredProc, parameters);

        var response = parameters.Get<string>("ResponseMessage");

        if (response.Equals("Product Added Successfully"))
        {
            return new ProductDataResult
            {
                Status = AuthRequestStatus.Success,
                Message = response
            };
        }

        return new ProductDataResult
        {
            Message = $"Failed to add product. {response}",
            Status = AuthRequestStatus.Failure
        };
    }
}