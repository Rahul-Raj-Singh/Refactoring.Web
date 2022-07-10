using System;
using Refactoring.Web.DomainModels;
using Refactoring.Web.Services.Interfaces;

namespace Refactoring.Web.Services
{
    public class PrintAdvertService : IPrintAdvertService
    {
        public void PrintAdvert(Advert advert, bool IsDefaultAdvert)
        {
            if (IsDefaultAdvert)
            {
                Console.WriteLine("Printing Default Advert");
            }
            else
            {
                Console.WriteLine("Printing Custom Advert: " + advert.Heading);
            }
            System.Threading.Thread.Sleep(3000);
        }
    }
}