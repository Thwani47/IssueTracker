using IssueTracker.Api.Services.ProductService;
using IssueTracker.DataAccess.Models;
using IssueTracker.DataAccess.Models.Products;
using Microsoft.AspNetCore.Mvc;

namespace IssueTracker.Api.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly ILogger<ProductsController> _logger;

    public ProductsController(IProductService productService, ILogger<ProductsController> logger)
    {
        _productService = productService;
        _logger = logger;
    }
    
    [HttpGet("all")]
    public async Task<IActionResult> GetAllProducts()
    {
        try
        {
            var result = await _productService.DoGetAllProducts();

            if (result.Status == AuthRequestStatus.Failure)
            {
                return NotFound(new { result.Message });
            }

            return Ok(new { result.Message, result.Data });
        }
        catch (Exception e)
        {
            _logger.LogWarning($"Error fetching all products: {e.Message}");
            return BadRequest(new { Message = "Error fetching products" });
        }
    }

    [HttpGet("productId/{productId}")]
    public async Task<IActionResult> GetTeam(string productId)
    {
        try
        {
            var result = await _productService.DoGetProductById(productId);

            if (result.Status == AuthRequestStatus.Failure)
            {
                return NotFound(new { result.Message });
            }

            return Ok(new { result.Message, result.Data });
        }
        catch (Exception e)
        {
            _logger.LogWarning($"Error fetching product: {e.Message}");
            return BadRequest(new { Message = "Error fetching product" });
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddNewTeam([FromBody] AddProductRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(new { Message = "Invalid request" });
        try
        {
            var result = await _productService.DoAddNewProduct(request);

            if (result.Status == AuthRequestStatus.Failure)
            {
                return NotFound(new { Message = "Failed to add new product" });
            }

            return Ok(new { result.Message, result.Data });
        }
        catch (Exception e)
        {
            _logger.LogWarning($"Error adding new product: {e.Message}");
            return BadRequest(new { Message = "Error adding new product" });
        }
    }
}