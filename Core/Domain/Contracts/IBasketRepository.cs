using Domain.Entities.BasketModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IBasketRepository
    {
        //get
        Task<CustomerBasket?> GetBasketById(string id);
        //create.update
        Task<CustomerBasket?> CreateOrUpdateBasketAsync(CustomerBasket Basket,TimeSpan? timeToLive=null);
        //delete
        Task<bool>DeleteBasketAsync(string id);


    }
}
