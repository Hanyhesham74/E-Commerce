using Shared.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResultDto>>GetAllProductsAsync();
        Task<IEnumerable<BrandResultDto>>GetAllBrandsAsync();
        Task<IEnumerable<TypeResultDto>>GetAllTypesAsync();
        Task<ProductResultDto> GetProductById(int id);


    }
}
