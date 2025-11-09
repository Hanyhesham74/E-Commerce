using Shared;
using Shared.DTOS;
using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Contracts
{
    public interface IProductService
    {
        Task<PaginatedResult<ProductResultDto>>GetAllProductsAsync(ProductSpecificationsParameters parameters);  
        Task<IEnumerable<BrandResultDto>>GetAllBrandsAsync();
        Task<IEnumerable<TypeResultDto>>GetAllTypesAsync();
        Task<ProductResultDto> GetProductById(int id);


    }
}
