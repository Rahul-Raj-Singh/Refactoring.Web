using System;
using System.Threading.Tasks;
using Refactoring.Web.DomainModels;
using Refactoring.Web.Services.Interfaces;

namespace Refactoring.Web.Services.OrderProcessors
{
    public class CountyOrderProcessor : OrderProcessor
    {
        private readonly IPrintAdvertService _printAdvertService;

        public CountyOrderProcessor(IPrintAdvertService printAdvertService, IChamberOfCommerceApi chamberOfCommerceApi)
        {
            _printAdvertService = printAdvertService;
        }
        public override async Task<Order> PrintAdvertAndProcessOrder(Order order)
        {
            var advert = new Advert();
            advert.CreatedOn = DateTime.Now;
            advert.Heading = "County Diner";
            advert.Content = "Kids eat free every Thursday night";
            order.Advert = advert;
            _printAdvertService.PrintAdvert(advert, false);
            order.Status = "Complete";
            await Task.CompletedTask;
            return order;
        }
    }
}