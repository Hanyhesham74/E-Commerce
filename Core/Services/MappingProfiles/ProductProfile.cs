using AutoMapper;
using Domain.Entities.ProductModule;
using Shared.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.MappingProfiles
{
    internal class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductResultDto>().
                ForMember(dest => dest.BrandName, options => options.MapFrom(src => src.productBrand.Name)).
                ForMember(dest => dest.TypeName, options => options.MapFrom(src => src.productType.Name));
            CreateMap<ProductBrand, BrandResultDto>();
            CreateMap<ProductType, TypeResultDto>();
        }
    }
}
