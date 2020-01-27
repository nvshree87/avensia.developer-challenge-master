using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Avensia.Storefront.Developertest
{
    public class DefaultExampleProductRepository : IProductRepository
    {
        public IEnumerable<IProductDto> GetProducts(string _fileData)
        {

            List<DefaultProductDto> ProductList = JsonConvert.DeserializeObject<List<DefaultProductDto>>(_fileData);

            return ProductList;
        }

        public IEnumerable<IProductDto> GetProducts(string _fileData, int pageNo, int pageSize)
        {
            List<DefaultProductDto> ProductList = JsonConvert.DeserializeObject<List<DefaultProductDto>>(_fileData);
            return GetPage(ProductList, pageNo, pageSize);
        }

        private List<DefaultProductDto> GetPage(List<DefaultProductDto> list, int page, int pageSize)
        {
            return list.Skip(page * pageSize).Take(pageSize).ToList();
        }
    }
}