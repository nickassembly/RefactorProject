using Refactoring.Web.Services.Helpers;
using Refactoring.Web.Services.Interfaces;
using System;

namespace Refactoring.Web.Services
{
   public class DealService : IDealService
   {
      private const decimal PmRate = 0.1M;
      private const decimal AmRate = 0.05M;
      private readonly IRandomHelper _randomHelper;

      public DealService(IRandomHelper randomHelper)
      {
         _randomHelper = randomHelper;
      }

      public decimal GenerateDeal(DateTime dateTime)
         => IsAfternoon(dateTime) ? PmRate : AmRate;

      public string GetRandomLocalBusiness() 
         => _randomHelper.GetRandomValueFromList<string>(LocalBusiness.AllBusinesses);

      private static bool IsAfternoon(DateTime dateTime) => dateTime.Hour > 12 && dateTime.Hour < 24;
   }
}