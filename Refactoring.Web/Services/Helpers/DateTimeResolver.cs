using Refactoring.Web.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Refactoring.Web.Services.Helpers
{
   public class DateTimeResolver : IDateTimeResolver
   {
      public bool IsItTuesday() =>
         DateTime.Now.DayOfWeek == DayOfWeek.Tuesday;

      public bool IsItTheWeekend()
      {
         var weekendDays = new List<DayOfWeek>
         { DayOfWeek.Saturday, DayOfWeek.Sunday};

         return weekendDays.Contains(DateTime.Now.DayOfWeek);

      }

   }
}
