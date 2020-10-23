using Refactoring.Web.Services.Helpers;
using Refactoring.Web.Services.Interfaces;
using Refactoring.Web.Services.OrderProcessors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactoring.Web.Services
{
   public class DistrictOrderFactory : IDistrictOrderFactory
   {
      private readonly IChamberOfCommerceApi _chamberOfCommerceApi;
      private readonly IAdvertPrinter _printer;
      private readonly IDealService _dealService;

      public DistrictOrderFactory(IChamberOfCommerceApi chamberOfCommerceApi, IAdvertPrinter printer, IDealService dealService)
      {
         _chamberOfCommerceApi = chamberOfCommerceApi;
         _printer = printer;
         _dealService = dealService;
      }
      public OrderProcessor For(string district)
      {
         if (district.ToLower() == District.Cambridge)
         {
            return new CambridgeOrderProcessor(_chamberOfCommerceApi, _printer);
         }

         if (district.ToLower() == District.Middleton)
         {
            return new MiddletonOrderProcessor(_dealService, _chamberOfCommerceApi, _printer);
         }

         if (district.ToLower() == District.County)
         {
            return new CountyOrderProcessor(_printer);
         }

         if (district.ToLower() == District.Downtown)
         {
            return new DowntownOrderProcessor(_printer);
         }

         throw new NotImplementedException($"No Processor for {district}");

      }
   }
}
