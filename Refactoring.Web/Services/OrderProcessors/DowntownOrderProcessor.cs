using Refactoring.Web.DomainModels;
using Refactoring.Web.Services.Interfaces;
using System;

namespace Refactoring.Web.Services.OrderProcessors
{
   public class DowntownOrderProcessor
   {
      private readonly IAdvertPrinter _printer;
      public DowntownOrderProcessor(IAdvertPrinter printer)
      {
         _printer = printer;
      }

      public Order PrintAdvertAndUpdateOrder(Order order)
      {
         if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday || DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
         {
            _printer.Print(null, true);
         }

         var advert = new Advert
         {
            Heading = "Downtown Coffee Roasters",
            CreatedOn = DateTime.Now,
            Content = "Get a free coffee drink when you buy 1lb of coffee beans"
         };

         order.Advert = advert;
         _printer.Print(advert, false);
         order.Status = "Complete";

         return order;
      }
   }
}
