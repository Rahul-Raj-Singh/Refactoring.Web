using System;
using System.Collections.Generic;
using System.Linq;
using Refactoring.Web.Common;
using Refactoring.Web.Services.Interfaces;

namespace Refactoring.Web.Services
{

    public class DealService : IDealService
    {
        private const decimal AmRate = 0.05M;
        private const decimal PmRate = 0.1M;
        public decimal GenerateDeal(DateTime dateTime)
        {
            return IsAfterNoon(dateTime) ? PmRate : AmRate;
        }

        public string GetRandomLocalBusiness()
        {
            var lbs = Business.GetAllBusiness.ToList();
            var random = new Random();
            var idx = random.Next(lbs.Count);
            return lbs[idx];
        }

        private bool IsAfterNoon(DateTime dateTime) => dateTime.Hour > 12 && dateTime.Hour < 24;
    }
}