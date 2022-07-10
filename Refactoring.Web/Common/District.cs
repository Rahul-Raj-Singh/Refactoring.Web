using System;
using System.Collections.Generic;

namespace Refactoring.Web.Common
{
    public static class District
    {
        public const string CAMBRIDGE = "Cambridge";
        public const string DOWNTOWN = "Downtown";
        public const string COUNTY = "County";
        public const string MIDDLETON = "Middleton";
        public static IEnumerable<string> GetAllDistricts => new[] { CAMBRIDGE, DOWNTOWN, COUNTY, MIDDLETON };

        public static int GetDistrictIDByName(string district)
        {

            if (district.ToLower() == DOWNTOWN.ToLower())   return 11;
            if (district.ToLower() == COUNTY.ToLower())     return 23;
            if (district.ToLower() == MIDDLETON.ToLower())  return 18;
            if (district.ToLower() == CAMBRIDGE.ToLower())  return 42;

            throw new InvalidOperationException($"Cannot find ID for district: {district}");
        }
    }
}
