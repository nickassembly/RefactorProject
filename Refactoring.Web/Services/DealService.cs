using Refactoring.Web.Services.Helpers;
using Refactoring.Web.Services.Interfaces;
using System;
using System.Linq;

namespace Refactoring.Web.Services
{
   public class DealService : IDealService
   {

      private const decimal PmRate = 0.1M;
      private const decimal AmRate = 0.05M;



      public decimal GenerateDeal(DateTime dateTime)
         => IsAfternoon(dateTime) ? PmRate : AmRate;    
 
      public string GetRandomLocalBusiness()
      {
         var localBusinesses = LocalBusiness.AllBusinesses;
         var random = new Random();
         var idx = random.Next(localBusinesses.Count);
         return localBusinesses.ToList()[idx];
      }

      private static bool IsAfternoon(DateTime dateTime) => dateTime.Hour > 12 && dateTime.Hour < 24;
   }
}