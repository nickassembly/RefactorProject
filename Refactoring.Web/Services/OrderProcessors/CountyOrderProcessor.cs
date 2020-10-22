using Refactoring.Web.DomainModels;
using Refactoring.Web.Services.Interfaces;
using System;

namespace Refactoring.Web.Services.OrderProcessors
{
   public class CountyOrderProcessor
   {
      private readonly IAdvertPrinter _printer;
      public CountyOrderProcessor(IAdvertPrinter printer)
      {
         _printer = printer;
      }

      public Order PrintAdvertAndUpdateOrder(Order order)
      {
         var advert = new Advert
         {
            CreatedOn = DateTime.Now,
            Heading = "County Diner",
            Content = "Kids eat free every Thursday night"
         };

         order.Advert = advert;
         _printer.Print(advert, false);
         order.Status = "Complete";
         return order;
      }

   }
}
