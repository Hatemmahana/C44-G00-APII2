using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Abstraction.Contracts;
using Shared.Dtos;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ProductsController(IServiceManager _serviceManager) : ControllerBase
    {
        //Get All Products
        [HttpGet("Products")]
        public async Task<ActionResult<IEnumerable<ProductResultDto>>> GetAllProductsAsync()
        => Ok(await _serviceManager.productService.GetAllProductAsync());


        //Get All Products Brand
        [HttpGet("Brands")]
        public async Task<ActionResult<IEnumerable<BrandResultDto>>> GetAlltBrandsAsync()

           => Ok(await _serviceManager.productService.GetAllBrandAsync());

        //Get All Products Types
        [HttpGet("Types")]
        public async Task<ActionResult<IEnumerable<TypeResultDto>>> GetAlltTypesAsync()

           => Ok(await _serviceManager.productService.GetAllTypesAsync());

        //Get Product By Id
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductResultDto>> GetProductByIdAsync(int id)
            =>Ok(await _serviceManager.productService.GetProductByIdAsync(id));

    }
}
