using Refactoring.Web.DomainModels;
using Refactoring.Web.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Refactoring.Web.Services.OrderProcessors
{
   public class DowntownOrderProcessor : OrderProcessor
   {
      private readonly IAdvertPrinter _printer;
      private readonly IDateTimeResolver _dateTimeResolver;
      public DowntownOrderProcessor(IAdvertPrinter printer, IDateTimeResolver dateTimeResolver)
      {
         _printer = printer;
         _dateTimeResolver = dateTimeResolver;
      }

      public override async Task<Order> PrintAdvertAndUpdateOrder(Order order)
      {
         if (_dateTimeResolver.IsItTheWeekend())
         {
            _printer.PrintDefault(null);
         }

         var advert = new Advert
         {
            Heading = "Downtown Coffee Roasters",
            CreatedOn = DateTime.Now,
            Content = "Get a free coffee drink when you buy 1lb of coffee beans"
         };

         order.Advert = advert;
         _printer.PrintDefault(advert);
         order.Status = "Complete";

         return order;
      }
   }
}
