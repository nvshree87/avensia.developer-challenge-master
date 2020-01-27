using System.Collections.Generic;
using Avensia.Storefront.Developertest.Enums;

namespace Avensia.Storefront.Developertest
{
    public class DefaultProductDto : IProductDto
    {
        public string Id { get; set; }
        public string ProductName { get; set; }
        public string CategoryId { get; set; }
        public decimal Price { get; set; }
        public Currency SelectedCurrency { get; set; }
        public List<Properties> Properties { get; set; }

    }

    public class Properties
    {
        public string KeyName { get; set; }
        public string Value { get; set; }
    }
}