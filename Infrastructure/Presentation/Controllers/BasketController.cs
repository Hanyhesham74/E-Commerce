using Microsoft.AspNetCore.Mvc;
using Services_Abstraction.Contracts;
using Shared.DTOS.BasketModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    public class BasketController(IServiceManger _serviceManger):ApiController
    {
        [HttpGet]
        public async Task<ActionResult<BasketDto>> GetBasketAsync(string id)
            =>Ok(await _serviceManger.BasketService.GetBasketAsync(id));
        [HttpPost]
        public async Task<ActionResult<BasketDto>> CreateOrUpdateBasketAsync(BasketDto basket)
            =>Ok(await _serviceManger.BasketService.CreateOrUpdateBasketAsync(basket));
        [HttpDelete]
        public async Task<ActionResult> DeleteBasket(string id)
        {
            await _serviceManger.BasketService.DeleteBasketAsync(id);
            return NoContent();
        }
    }
}
