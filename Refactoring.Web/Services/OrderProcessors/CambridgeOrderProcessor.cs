using Refactoring.Web.DomainModels;
using Refactoring.Web.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Refactoring.Web.Services.OrderProcessors
{
   public class CambridgeOrderProcessor : OrderProcessor
   {
      private readonly IChamberOfCommerceApi _chamberOfCommerceApi;
      private readonly IAdvertPrinter _printer;
      private readonly IDateTimeResolver _dateResolver;

      public CambridgeOrderProcessor(IChamberOfCommerceApi chamberOfCommerceApi, IAdvertPrinter printer, IDateTimeResolver dateResolver)
      {
         _chamberOfCommerceApi = chamberOfCommerceApi;
         _printer = printer;
         _dateResolver = dateResolver;
      }
      public override async Task<Order> PrintAdvertAndUpdateOrder(Order order)
      {
         var advert = new Advert();
         advert.CreatedOn = DateTime.Now;
         advert.Heading = "Cambridge Bakery";
         advert.Content = "Custom Birthday and Wedding Cakes";
         if (_dateResolver.IsItTuesday())
         {
            var result = await _chamberOfCommerceApi.GetImageAndThumbnailDataFor("Middleton");
            advert.ImageUrl = result.ThumbnailUrl;
         }
         order.Advert = advert;
         _printer.PrintCustom(advert);
         order.Status = "Complete";

         return order;
      }
   }

}
