using System.Collections.Generic;

namespace Refactoring.Web.Services.Interfaces
{
    public interface IRandomHelper
    {
        T GetRandomItemFromCollection<T>(IEnumerable<T> collection);
    }

}