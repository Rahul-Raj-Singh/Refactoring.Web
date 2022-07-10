using System;
using System.Threading.Tasks;
using Refactoring.Web.DomainModels;
using Refactoring.Web.Services.Interfaces;

namespace Refactoring.Web.Services
{
    public class OrderService : IOrderService
    {
        private readonly IDistrictOrderProcessorFactory _orderProcessorFactory;

        public OrderService(IDistrictOrderProcessorFactory orderProcessorFactory)
        {
            _orderProcessorFactory = orderProcessorFactory;
        }
        public async Task<Order> ProcessOrder(Order order)
        {
            order.Id = Guid.NewGuid().ToString();
            order.CreatedOn = DateTime.Now;
            order.UpdatedOn = DateTime.Now;

            var orderProcessor = _orderProcessorFactory.For(order.District.ToLower());
            var processsedOrder = await orderProcessor.PrintAdvertAndProcessOrder(order);

            return processsedOrder;
        }
    }
}