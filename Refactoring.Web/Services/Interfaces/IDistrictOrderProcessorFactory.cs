using Refactoring.Web.Services.OrderProcessors;

namespace Refactoring.Web.Services.Interfaces
{
    public interface IDistrictOrderProcessorFactory
    {
        OrderProcessor For(string district);
    }
}