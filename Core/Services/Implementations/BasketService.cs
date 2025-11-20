using AutoMapper;
using Domain.Contracts;
using Domain.Entities.BasketModule;
using Domain.Exceptions;
using Services_Abstraction.Contracts;
using Shared.DTOS.BasketModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    internal class BasketService(IBasketRepository _basketRepository,IMapper _mapper) : IBasketService
    {
        public async Task<BasketDto> CreateOrUpdateBasketAsync(BasketDto basketDto)
        {
            var basket=_mapper.Map<CustomerBasket>(basketDto);
            var CreatedOrUpdatedBasket=await _basketRepository.CreateOrUpdateBasketAsync(basket);
            return CreatedOrUpdatedBasket is null ? throw new Exception("Can Not Created Or Updated"):
                       _mapper.Map<BasketDto>(CreatedOrUpdatedBasket);
        }

        public async Task<bool> DeleteBasketAsync(string id)
        =>await _basketRepository.DeleteBasketAsync(id);

        public async Task<BasketDto> GetBasketAsync(string id)
        {
            var basket=await _basketRepository.GetBasketById(id);
            return basket is null?throw new BasketNotFoundException(id): 
                _mapper.Map<BasketDto>(basket);
        }
    }
}
