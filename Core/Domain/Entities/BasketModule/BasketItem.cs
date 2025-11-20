using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.BasketModule
{
    public class BasketItem
    {
        public string Id { get; set; }=string.Empty;
        public ICollection<BasketItem> BasketItems { get; set; }
    }
}
