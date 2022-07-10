using System.Collections.Generic;

namespace Refactoring.Web.Common
{
    public static class Business
    {
        public const string BARBERSHOP = "Barbershop";
        public const string SHOE_STORE = "Shoe Store";
        public const string PIZZA_PLACE = "Pizza Place";
        public const string DINER = "Diner";
        public const string AUTO_REPAIR = "Auto Repair";
        public const string PHARMACY = "Pharmacy";
        public const string GROCERY = "Grocery";
        public const string BAKERY = "Bakery";

        public static IEnumerable<string> GetAllBusiness => new List<string> {BARBERSHOP, SHOE_STORE, PIZZA_PLACE, DINER, AUTO_REPAIR, PHARMACY, GROCERY, BAKERY};
    }
}