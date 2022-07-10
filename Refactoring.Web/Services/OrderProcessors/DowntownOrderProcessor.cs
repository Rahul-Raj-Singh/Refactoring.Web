using System;
using System.Threading.Tasks;
using Refactoring.Web.DomainModels;
using Refactoring.Web.Services.Interfaces;

namespace Refactoring.Web.Services.OrderProcessors
{
    public class DowntownOrderProcessor : OrderProcessor
    {
        private readonly IPrintAdvertService _printAdvertService;

        public DowntownOrderProcessor(IPrintAdvertService printAdvertService, IChamberOfCommerceApi chamberOfCommerceApi)
        {
            _printAdvertService = printAdvertService;
        }
        public override async Task<Order> PrintAdvertAndProcessOrder(Order order)
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday || DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
            {
                _printAdvertService.PrintAdvert(null, true);
            }
            var advert = new Advert();
            advert.Heading = "Downtown Coffee Roasters";
            advert.CreatedOn = DateTime.Now;
            advert.Content = "Get a free coffee drink when you buy 1lb of coffee beans";
            order.Advert = advert;
            _printAdvertService.PrintAdvert(advert, false);
            order.Status = "Complete";
            await Task.CompletedTask;
            return order;
        }
    }
}