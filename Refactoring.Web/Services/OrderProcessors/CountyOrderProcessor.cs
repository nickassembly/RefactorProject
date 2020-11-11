using Refactoring.Web.DomainModels;
using Refactoring.Web.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Refactoring.Web.Services.OrderProcessors
{
   public class CountyOrderProcessor : OrderProcessor
   {
      private readonly IAdvertPrinter _printer;
      public CountyOrderProcessor(IAdvertPrinter printer)
      {
         _printer = printer;
      }

      public override async Task<Order> PrintAdvertAndUpdateOrder(Order order)
      {
         var advert = new Advert
         {
            CreatedOn = DateTime.Now,
            Heading = "County Diner",
            Content = "Kids eat free every Thursday night"
         };

         order.Advert = advert;
         _printer.PrintCustom(advert);
         order.Status = "Complete";
         return order;
      }

   }
}
