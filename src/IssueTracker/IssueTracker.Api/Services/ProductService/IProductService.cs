using IssueTracker.DataAccess.Models.Products;

namespace IssueTracker.Api.Services.ProductService;

public interface IProductService
{
    Task<ProductDataResult> DoGetAllProducts();

    Task<ProductDataResult> DoGetProductById(string productId);

    Task<ProductDataResult> DoAddNewProduct(AddProductRequest request);
}