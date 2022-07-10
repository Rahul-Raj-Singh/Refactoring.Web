using System;
using System.Threading.Tasks;
using Refactoring.Web.Common;
using Refactoring.Web.DomainModels;
using Refactoring.Web.Services.Interfaces;

namespace Refactoring.Web.Services.OrderProcessors
{
    public class MiddletonOrderProcessor : OrderProcessor
    {
        private readonly IPrintAdvertService _printAdvertService;
        private readonly IChamberOfCommerceApi _chamberOfCommerceApi;
        private readonly IDealService _dealService;
        private readonly IRandomHelper _randomHelper;

        public MiddletonOrderProcessor(IPrintAdvertService printAdvertService, 
        IChamberOfCommerceApi chamberOfCommerceApi, 
        IDealService dealService,
        IRandomHelper randomHelper)
        {
            _printAdvertService = printAdvertService;
            _chamberOfCommerceApi = chamberOfCommerceApi;
            _dealService = dealService;
            _randomHelper = randomHelper;
        }
        public override async Task<Order> PrintAdvertAndProcessOrder(Order order)
        {
            var deal = _dealService.GenerateDeal(DateTime.Now);
            var biz = _randomHelper.GetRandomItemFromCollection<string>(Business.GetAllBusiness);

            var result = await _chamberOfCommerceApi.GetFor(District.MIDDLETON);

            var advert = new Advert();
            advert.CreatedOn = DateTime.Now;
            advert.Heading = "Middleton " + biz;
            advert.Content = "Get " + deal * 100 + "Percent off your next purchase!";  
            advert.ImageUrl = result.ThumbnailUrl;
            
            order.Advert = advert;
            _printAdvertService.PrintAdvert(advert, false);
            order.Status = "Complete";

            return order;
        }
    }
}