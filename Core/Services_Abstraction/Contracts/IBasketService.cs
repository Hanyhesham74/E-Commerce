using Shared.DTOS.BasketModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Abstraction.Contracts
{
    public interface IBasketService
    {
        Task<BasketDto> GetBasketAsync(string id);

        Task<bool> DeleteBasketAsync(string id);

        Task<BasketDto> CreateOrUpdateBasketAsync( BasketDto basketDto);
    }
}
