using System;
using Refactoring.Web.Services.Interfaces;

namespace Refactoring.Web.Common
{
    public class DateTimeResolver : IDateTimeResolver
    {
        public bool IsTodayTuesday() => DateTime.Now.DayOfWeek == DayOfWeek.Tuesday;
    }

}