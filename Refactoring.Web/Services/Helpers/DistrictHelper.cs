using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactoring.Web.Services.Helpers
{
   public static class District
   {
      public static string Cambridge => "Cambridge";
      public static string Downtown => "Downtown";
      public static string County => "County";
      public static string Middleton => "Middleton";

      public static IEnumerable<string> StandardDistricts => new List<string>
      {
         Cambridge, Downtown, County, Middleton
      };
   }
}
