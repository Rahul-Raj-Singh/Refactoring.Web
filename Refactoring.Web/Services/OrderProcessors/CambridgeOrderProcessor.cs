using System;
using System.Threading.Tasks;
using Refactoring.Web.Common;
using Refactoring.Web.DomainModels;
using Refactoring.Web.Services.Interfaces;

namespace Refactoring.Web.Services.OrderProcessors
{
    public partial class CambridgeOrderProcessor : OrderProcessor
    {
        private readonly IPrintAdvertService _printAdvertService;
        private readonly IChamberOfCommerceApi _chamberOfCommerceApi;
        private readonly IDateTimeResolver _dateTimeResolver;

        public CambridgeOrderProcessor(
            IPrintAdvertService printAdvertService,
            IChamberOfCommerceApi chamberOfCommerceApi,
            IDateTimeResolver dateTimeResolver)
        {
            _printAdvertService = printAdvertService;
            _chamberOfCommerceApi = chamberOfCommerceApi;
            _dateTimeResolver = dateTimeResolver;
        }
        public override async Task<Order> PrintAdvertAndProcessOrder(Order order)
        {
            var advert = new Advert();
            advert.CreatedOn = DateTime.Now;
            advert.Heading = "Cambridge Bakery";
            advert.Content = "Custom Birthday and Wedding Cakes";
            if (_dateTimeResolver.IsTodayTuesday())
            {
                var result = await _chamberOfCommerceApi.GetFor(District.CAMBRIDGE);
                advert.ImageUrl = result.ThumbnailUrl;
            }
            order.Advert = advert;
            _printAdvertService.PrintAdvert(advert, false);
            order.Status = "Complete";

            return order;
        }
    }
}