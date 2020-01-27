using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avensia.Storefront.Developertest
{
    public static class Helper
    {
        public static void DisplayException(Exception ex)
        {
            Console.WriteLine($"Exception Message : {ex.Message}");
            Console.WriteLine($"Exception Stacktrace : {ex.StackTrace}");
            Console.WriteLine($"Exception InnerException : {ex.InnerException}");
        }
    }
}
