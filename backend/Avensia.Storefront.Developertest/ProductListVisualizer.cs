using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Avensia.Storefront.Developertest.Enums;

namespace Avensia.Storefront.Developertest
{
    public class ProductListVisualizer
    {
        private readonly IProductRepository _productRepository;
        private readonly string _fileData;

        public ProductListVisualizer(IProductRepository productRepository)
        {
            //currenct directory considered as debug folder
            string workingParentDir = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            _productRepository = productRepository;
            _fileData = File.ReadAllText(Path.Combine(workingParentDir + "\\products.json"));

        }

        //displays all the products from the file price is based on currency selected 
        public void OutputAllProduct(Currency selectedCurrency)
        {

            var products = _productRepository.GetProducts(_fileData);
            if (products != null && products.Any())
            {
                Console.WriteLine($"ProductId  \t    ProductName    \t  ProductPrice({selectedCurrency})  \t      ProductBrand      \t  ProductNumber  ");
                foreach (var product in products)
                {
                    var brand = ((DefaultProductDto)product).Properties.Where(w => w.KeyName == "Brand").Select(x => x.Value).FirstOrDefault();
                    var Dimensions = ((DefaultProductDto)product).Properties.Where(w => w.KeyName == "Dimensions").Select(x => x.Value).FirstOrDefault();
                    var ItemNumber = ((DefaultProductDto)product).Properties.Where(w => w.KeyName == "ItemNumber").Select(x => x.Value).FirstOrDefault();
                    var Description = ((DefaultProductDto)product).Properties.Where(w => w.KeyName == "Description").Select(x => x.Value).FirstOrDefault();

                    Console.WriteLine(string.Format($"{product.Id}  \t  " +
                        $"{product.ProductName.Substring(0, product.ProductName.Length > 15 ? 15 : product.ProductName.Length)}  \t  " +
                        $"{ConvertCurrency(selectedCurrency, product.Price)} \t  " +
                        $"{brand}  \t  " +
                        $"{ItemNumber}  \t  "));
                }
            }
            else
            {
                Console.WriteLine("No Products Found to display");
            }
        }
        
        private decimal ConvertCurrency(Currency selectedCurrency, decimal price)
        {
            decimal convertedPrice = 0.0m;
            switch (selectedCurrency)
            {
                case Currency.USD:
                    convertedPrice = price;
                    break;
                case Currency.GBP:
                    convertedPrice = price * 0.71m;
                    break;
                case Currency.SEK:
                    convertedPrice = price * 8.38m;
                    break;
                case Currency.DKK:
                    convertedPrice = price * 6.06m;
                    break;
            }
            return convertedPrice;
        }
        //displays paginated products price is based on currency selected 
        public void OutputPaginatedProducts(Currency selectedCurrency, int pageNo, int pageSize)
        {
            var products = _productRepository.GetProducts(_fileData, pageNo, pageSize);
            if (products != null && products.Any())
            {
                Console.WriteLine($"ProductId  \t    ProductName    \t  ProductPrice({selectedCurrency})  \t      ProductBrand      \t  ProductNumber  ");
                foreach (var product in products)
                {
                    var brand = ((DefaultProductDto)product).Properties.Where(w => w.KeyName == "Brand").Select(x => x.Value).FirstOrDefault();
                    var Dimensions = ((DefaultProductDto)product).Properties.Where(w => w.KeyName == "Dimensions").Select(x => x.Value).FirstOrDefault();
                    var ItemNumber = ((DefaultProductDto)product).Properties.Where(w => w.KeyName == "ItemNumber").Select(x => x.Value).FirstOrDefault();
                    var Description = ((DefaultProductDto)product).Properties.Where(w => w.KeyName == "Description").Select(x => x.Value).FirstOrDefault();

                    Console.WriteLine(string.Format($"{product.Id}  \t  " +
                        $"{product.ProductName.Substring(0, product.ProductName.Length > 15 ? 15 : product.ProductName.Length)}  \t  " +
                        $"{ConvertCurrency(selectedCurrency, product.Price)} \t  " +
                        $"{brand}  \t  " +
                        $"{ItemNumber}  \t  "));
                }
            }
            else
            {
                Console.WriteLine("No Products Found to display");
            }
        }


        //displays grouped by price products price is based on currency selected
        public void OutputProductGroupedByPriceSegment(Currency selectedCurrency, decimal rangeForIncrement)
        {
            var products = _productRepository.GetProducts(_fileData).Select(x => new
            {
                name = x.ProductName,
                Price = ConvertCurrency(selectedCurrency, x.Price)
            }).OrderBy(o => o.Price);
            Console.WriteLine("\n");

            if (products != null && products.Any())
            {
                for (decimal i = 0; i < products.LastOrDefault().Price;)
                {
                    decimal start = i;
                    decimal end = (i + rangeForIncrement);

                    Console.WriteLine($"{start}{selectedCurrency} - {end}{selectedCurrency}");

                    var rangeProducts = products.Where(w => w.Price >= start && w.Price < end).Select(x => x);
                    foreach (var rangeProduct in rangeProducts)
                        Console.WriteLine(rangeProduct.name + " - " + rangeProduct.Price);

                    i = end;
                    Console.WriteLine("\n");

                }
            }
            else
            {
                Console.WriteLine("No Products Found to display");
            }
        }


    }
}
