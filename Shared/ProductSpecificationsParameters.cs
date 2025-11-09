using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class ProductSpecificationsParameters
    {
        private const int DefaultPageSize = 5;
        private const int MaxPageSize = 10;
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
        public ProductSortingOptions Sort { get; set; } //= ProductSortingOptions.NameAsc;
        public string? Search { get; set; }
        public int PageIndex { get; set; } = 1;

        private int _pagesize=DefaultPageSize;

        public int PageSize
        {
            get { return _pagesize; }
            set { _pagesize = value>MaxPageSize?MaxPageSize:value; }  
        }






    }
}
