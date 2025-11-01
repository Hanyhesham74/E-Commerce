using AutoMapper;
using Domain.Contracts;
using Domain.Entities.ProductModule;
using Services.Specifications;
using Shared;
using Shared.DTOS;
using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    internal class ProductService(IUnitOfWork _unitOfWork,IMapper _mapper) : IProductService
    {
        public async Task<IEnumerable<BrandResultDto>> GetAllBrandsAsync()
        {
            var brands=await _unitOfWork.GetRepository<ProductBrand,int>().GetAllAsync();
            var brandDtos=_mapper.Map<IEnumerable<BrandResultDto>>(brands);
            return brandDtos;
        }

        public async Task<IEnumerable<ProductResultDto>> GetAllProductsAsync(ProductSpecificationsParameters parameters)

        {   var Specifications=new ProductWithBrandAndTypeSpecifications(parameters);   
            var products =await _unitOfWork.GetRepository<Product, int>().GetAllAsync(Specifications); 
            var productDtos = _mapper.Map<IEnumerable<ProductResultDto>>(products);
            return productDtos; 
        }

        public async Task<IEnumerable<TypeResultDto>> GetAllTypesAsync()
        {
            var types =await _unitOfWork.GetRepository<ProductType, int>().GetAllAsync();
            var typeDtos = _mapper.Map<IEnumerable<TypeResultDto>>(types);
            return typeDtos;
        }

        public async Task<ProductResultDto> GetProductById(int id)
        {
            var Specifications=new ProductWithBrandAndTypeSpecifications(id);
            var product =await _unitOfWork.GetRepository<Product, int>().GetByIdAsync(Specifications); 
            var productDto = _mapper.Map<ProductResultDto>(product); 
            return productDto; 
        }
    }
}
