using Refactoring.Web.DomainModels;
using Refactoring.Web.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Refactoring.Web.Services.OrderProcessors
{
   public class MiddletonOrderProcessor : OrderProcessor
   {
      private readonly IDealService _dealService;
      private readonly IChamberOfCommerceApi _chamberOfCommerceApi;
      private readonly IAdvertPrinter _printer;
      public MiddletonOrderProcessor(IDealService dealService, IChamberOfCommerceApi chamberOfCommerceApi, IAdvertPrinter printer)
      {
         _dealService = dealService;
         _chamberOfCommerceApi = chamberOfCommerceApi;
         _printer = printer;
      }
      public override async Task<Order> PrintAdvertAndUpdateOrder(Order order)
      {
         var deal = _dealService.GenerateDeal(DateTime.Now);
         var biz = _dealService.GetRandomLocalBusiness();
         var result = await _chamberOfCommerceApi.GetImageAndThumbnailDataFor("Middleton");
         var advert = new Advert
         {
            CreatedOn = DateTime.Now,
            Heading = "Middleton " + biz,
            Content = "Get " + deal * 100 + "Percent off your next purchase!",
            ImageUrl = result.ThumbnailUrl
         };

         order.Advert = advert;
         _printer.Print(advert, false);
         order.Status = "Complete";

         return order;
      }
   }
}
