using Domain.Contracts;
using Microsoft.AspNetCore.Mvc;
using Services_Abstraction.Contracts;
using Shared;
using Shared.DTOS;
using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(IServiceManger _serviceManger): ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductResultDto>>> GetAllProductsAsync([FromQuery]ProductSpecificationsParameters parameters)
        => Ok(await _serviceManger.ProductService.GetAllProductsAsync(parameters));   
        [HttpGet("brands")]
        public async Task<ActionResult<IEnumerable<BrandResultDto>>> GetAllBrandsAsync()
            => Ok( await _serviceManger.ProductService.GetAllBrandsAsync());
        [HttpGet("types")]
        public async Task<ActionResult<IEnumerable<TypeResultDto>>> GetAllTypesAsync()
            => Ok( await _serviceManger.ProductService.GetAllTypesAsync());
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductResultDto>> GetProductById(int id)
            => Ok( await _serviceManger.ProductService.GetProductById(id));

    }
}
