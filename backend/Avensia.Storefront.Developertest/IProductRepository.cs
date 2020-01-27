using System.Collections.Generic;

namespace Avensia.Storefront.Developertest
{
    public interface IProductRepository
    {
        IEnumerable<IProductDto> GetProducts(string _fileData);
        IEnumerable<IProductDto> GetProducts(string _fileData, int pageNo, int pageSize);

    }
}