using Refactoring.Web.Services.Interfaces;
using System;

namespace Refactoring.Web.Services.Helpers
{
   public class DateTimeResolver : IDateTimeResolver
   {
      public bool IsItTuesday() =>
         DateTime.Now.DayOfWeek == DayOfWeek.Tuesday;

   }
}
