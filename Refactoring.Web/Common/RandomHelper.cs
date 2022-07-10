using System;
using System.Collections.Generic;
using System.Linq;
using Refactoring.Web.Services.Interfaces;

namespace Refactoring.Web.Common
{
    public class RandomHelper : IRandomHelper
    {
        public T GetRandomItemFromCollection<T>(IEnumerable<T> collection)
        {
            var list = collection.ToList();
            var random = new Random();
            return list[random.Next(list.Count)];
        }
    }

}