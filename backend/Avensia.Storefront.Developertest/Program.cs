using System;
using Avensia.Storefront.Developertest.Enums;
using StructureMap;

namespace Avensia.Storefront.Developertest
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new Container(new DefaultRegistry());
            Currency selectedCurrency = Currency.USD;

            var productListVisualizer = container.GetInstance<ProductListVisualizer>();

            var shouldRun = true;
            DisplayOptions();

            while (shouldRun)
            {
                Console.Write("Enter an ProductListingOption: ");
                var input = Console.ReadKey();
                Console.WriteLine("\n");
                switch (input.Key)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        Console.WriteLine("Printing all products");
                        productListVisualizer.OutputAllProduct(selectedCurrency);
                        break;
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        Console.WriteLine("Printing paginated products");
                        int pageSize = 0;
                        int pageNo = 0;
                        for (int retry = 0; retry < 3 && pageSize <= 0; retry++)
                        {
                            Console.Write("Enter PageSize: ");
                            pageSize = Convert.ToInt32(Console.ReadLine());
                            if (pageSize <= 0 && retry != 2)
                                Console.WriteLine("Invalid PageSize. Give Value Greater than 1");
                        }
                        if (pageSize > 0)
                        {
                            for (int retry = 0; retry < 3 && pageNo <= 0; retry++)
                            {
                                Console.Write("Enter PageNo: ");
                                pageNo = Convert.ToInt32(Console.ReadLine());
                                if (pageNo <= 0 && retry != 2)
                                    Console.WriteLine("Invalid PageSize. Give Value Greater than 1");
                            }
                            if (pageNo > 0)                                
                            {
                                Console.WriteLine("\n");
                                if (pageNo > 0 && pageSize > 0)
                                    productListVisualizer.OutputPaginatedProducts(selectedCurrency, pageNo - 1, pageSize);
                            }
                            else
                            {
                                Console.WriteLine("Invalid PageNo even after 2 retries. So Stopping Paginated Display of Products");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid PageSize even after 2 retries. So Stopping Paginated Display of Products");
                        }

                        break;
                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        decimal rangeForIncrement = 0.0m;

                        for (int retry = 0; retry < 3 && rangeForIncrement <= 0.0m; retry++)
                        {
                            Console.Write("Enter Value for Increment to decide range: ");
                            rangeForIncrement = Convert.ToDecimal(Console.ReadLine());
                            if (rangeForIncrement <= 0 && retry != 2)
                                Console.WriteLine("Invalid Increment Value. Give Value Greater than 1");
                        }
                        if (rangeForIncrement > 0)
                        {
                            Console.WriteLine("Printing products grouped by price");
                            productListVisualizer.OutputProductGroupedByPriceSegment(selectedCurrency, rangeForIncrement);
                        }
                        else
                        {
                            Console.WriteLine("Invalid Increment Value even after 2 retries. So Stopping Paginated Display of Products");
                        }
                        break;
                    case ConsoleKey.D4:
                        Console.WriteLine("Which Currency you would like to choose ");
                        Console.WriteLine("Press 1 for: USD");
                        Console.WriteLine("Press 2 for: GBP");
                        Console.WriteLine("Press 3 for: SEK");
                        Console.WriteLine("Press 4 for: DKK");
                        Console.Write("Enter an Currency option: ");
                        switch (Console.ReadKey().Key)
                        {
                            case ConsoleKey.D1:
                                selectedCurrency = Currency.USD;
                                break;
                            case ConsoleKey.D2:
                                selectedCurrency = Currency.GBP;
                                break;
                            case ConsoleKey.D3:
                                selectedCurrency = Currency.SEK;
                                break;
                            case ConsoleKey.D4:
                                selectedCurrency = Currency.DKK;
                                break;
                            default:
                                selectedCurrency = Currency.USD;
                                Console.WriteLine("Currency Not Supported. Hence setting to default USD.");
                                break;
                        }
                        Console.WriteLine("\n");
                        break;
                    case ConsoleKey.D5:
                        try
                        {
                            throw new NotImplementedException();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Program() - ExceptionThrown ");
                            Helper.DisplayException(ex);
                        }
                        break;
                    case ConsoleKey.Q:
                        shouldRun = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option!");
                        break;
                }

                Console.WriteLine();
                DisplayOptions();
            }

            Console.Write("\n\rPress any key to exit!");
            Console.ReadKey();
        }

        private static void DisplayOptions()
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1 - Print all products");
            Console.WriteLine("2 - Print paginated products");
            Console.WriteLine("3 - Print products grouped by price");
            Console.WriteLine("4 - Change Currency");
            Console.WriteLine("5 - This option is not implemented");
            Console.WriteLine("q - Quit");
        }
    }
}
