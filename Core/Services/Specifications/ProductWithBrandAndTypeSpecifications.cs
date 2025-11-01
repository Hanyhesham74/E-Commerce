using Domain.Entities.ProductModule;
using Shared;
using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Specifications
{
    internal class ProductWithBrandAndTypeSpecifications: BaseSpecifications<Product, int>
    {
        public ProductWithBrandAndTypeSpecifications(ProductSpecificationsParameters parameters)
            : base(p=>(!parameters.TypeId.HasValue || p.TypeId==parameters.TypeId)&&(!parameters.BrandId.HasValue || p.BrandId==parameters.BrandId))
        {
            AddInclude(p => p.productBrand);
            AddInclude(p => p.productType);

            switch(parameters.Sort)
            {
                case ProductSortingOptions.PriceAsc:
                    AddOrderBy(p => p.Price);
                    break;
                case ProductSortingOptions.PriceDesc:
                    AddOrderByDescending(p => p.Price);
                    break;
                case ProductSortingOptions.NameDesc:
                    AddOrderByDescending(p => p.Name);
                    break;
                case ProductSortingOptions.NameAsc:
                    AddOrderBy(p => p.Name);
                    break;

                default:
                    break;
            }
        }

        public ProductWithBrandAndTypeSpecifications(int id) : base(p => p.Id == id)
        {
            AddInclude(p => p.productBrand);
            AddInclude(p => p.productType);
        }
    }
}
