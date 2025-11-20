using Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Abstraction.Contracts
{
    public interface IServiceManger
    {
        public IProductService ProductService { get; } 
        public IBasketService BasketService { get; }
    }
}
