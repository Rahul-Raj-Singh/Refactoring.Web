using System;
using Refactoring.Web.Common;
using Refactoring.Web.Services.Interfaces;
using Refactoring.Web.Services.OrderProcessors;

namespace Refactoring.Web.Services
{
    public class DistrictOrderProcessorFactory : IDistrictOrderProcessorFactory
    {
        private readonly IPrintAdvertService _printAdvertService;
        private readonly IChamberOfCommerceApi _chamberOfCommerceApi;
        private readonly IDealService _dealService;
        private readonly IDateTimeResolver _dateTimeResolver;
        private readonly IRandomHelper _randomHelper;

        public DistrictOrderProcessorFactory(
            IPrintAdvertService printAdvertService, 
            IChamberOfCommerceApi chamberOfCommerceApi, 
            IDealService dealService,
            IDateTimeResolver dateTimeResolver,
            IRandomHelper randomHelper)
        {
            _printAdvertService = printAdvertService;
            _chamberOfCommerceApi = chamberOfCommerceApi;
            _dealService = dealService;
            _dateTimeResolver = dateTimeResolver;
            _randomHelper = randomHelper;
        }
        public OrderProcessor For(string district)
        {
            if (district.ToLower() == District.CAMBRIDGE.ToLower())
                return new CambridgeOrderProcessor(_printAdvertService, _chamberOfCommerceApi, _dateTimeResolver);

            if (district.ToLower() == District.MIDDLETON.ToLower())
                return new MiddletonOrderProcessor(_printAdvertService, _chamberOfCommerceApi, _dealService, _randomHelper);

            if (district.ToLower() == District.COUNTY.ToLower())
                return new CountyOrderProcessor(_printAdvertService, _chamberOfCommerceApi);

            if (district.ToLower() == District.DOWNTOWN.ToLower())
                return new DowntownOrderProcessor(_printAdvertService, _chamberOfCommerceApi);

            throw new InvalidOperationException($"No OrderProcessor available for district: {district}");
        }
    }
}