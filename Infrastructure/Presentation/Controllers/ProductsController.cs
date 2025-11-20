using Domain.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services_Abstraction.Contracts;
using Shared;
using Shared.DTOS;
using Shared.Enums;
using Shared.ErrorModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
  
    public class ProductsController(IServiceManger _serviceManger): ApiController 
    { 
        [HttpGet]
        public async Task<ActionResult<PaginatedResult<ProductResultDto>>> GetAllProductsAsync([FromQuery]ProductSpecificationsParameters parameters)
        => Ok(await _serviceManger.ProductService.GetAllProductsAsync(parameters));    
        [HttpGet("brands")]
        public async Task<ActionResult<IEnumerable<BrandResultDto>>> GetAllBrandsAsync()
            => Ok( await _serviceManger.ProductService.GetAllBrandsAsync());
        [HttpGet("types")]
        public async Task<ActionResult<IEnumerable<TypeResultDto>>> GetAllTypesAsync()
            => Ok( await _serviceManger.ProductService.GetAllTypesAsync());
        [ProducesResponseType(typeof(ProductResultDto),StatusCodes.Status200OK)]
       
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductResultDto>> GetProductById(int id)
            => Ok( await _serviceManger.ProductService.GetProductById(id));

    }
}
