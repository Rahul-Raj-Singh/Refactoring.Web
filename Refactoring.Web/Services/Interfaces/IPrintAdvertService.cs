using Refactoring.Web.DomainModels;

namespace Refactoring.Web.Services.Interfaces
{
    public interface IPrintAdvertService
    {
        void PrintAdvert(Advert advert, bool IsDefaultAdvert);
    }
}