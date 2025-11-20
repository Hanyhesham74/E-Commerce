using Domain.Contracts;
using Domain.Entities.BasketModule;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Presistence.Repositories
{
    public class BasketRepository(IConnectionMultiplexer _connection) : IBasketRepository
    {
        private readonly IDatabase _database=_connection.GetDatabase();
        public async Task<CustomerBasket?> CreateOrUpdateBasketAsync(CustomerBasket Basket, TimeSpan? timeToLive = null)
        {
            var jesonBasket=JsonSerializer.Serialize(Basket);
            var result=await _database.StringSetAsync(Basket.Id, jesonBasket,timeToLive?? TimeSpan.FromDays(30));
            return result ? await GetBasketById(Basket.Id ): null;   
        }

        public async Task<bool> DeleteBasketAsync(string id)
        => await _database.KeyDeleteAsync(id);

        public async Task<CustomerBasket?> GetBasketById(string id)
        {
            var result=await _database.StringGetAsync(id);
            if(result.IsNullOrEmpty) return null;
            return JsonSerializer.Deserialize<CustomerBasket?>(result!);
        }
    }
}
