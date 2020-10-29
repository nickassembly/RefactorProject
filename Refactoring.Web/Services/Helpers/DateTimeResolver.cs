using Refactoring.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactoring.Web.Services.Helpers
{
   public class DateTimeResolver : IDateTimeResolver
   {
      public bool IsItTuesday() => 
         DateTime.Now.DayOfWeek == DayOfWeek.Tuesday;
      
   }
}
