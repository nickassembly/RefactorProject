using System;
using System.Threading.Tasks;
using Refactoring.Web.DomainModels;
using Refactoring.Web.Services.Interfaces;
using Refactoring.Web.Services.OrderProcessors;

namespace Refactoring.Web.Services
{
   public class OrderService : IOrderService
   {
      private readonly IDealService _dealService;
      private readonly IChamberOfCommerceApi _chamberOfCommerceApi;
      private readonly IAdvertPrinter _printer;

      public OrderService(IDealService dealService, IChamberOfCommerceApi chamberOfCommerceApi, IAdvertPrinter printer)
      {
         _dealService = dealService;
         _chamberOfCommerceApi = chamberOfCommerceApi;
         _printer = printer;
      }

      public async Task<Order> ProcessOrder(Order order)
      {
         order.Id = Guid.NewGuid().ToString();
         order.CreatedOn = DateTime.Now;
         order.UpdatedOn = DateTime.Now;

         if (order.District.ToLower() == "cambridge")
         {
            var orderProcessor = new CambridgeOrderProcessor(_chamberOfCommerceApi, _printer);
           order = await orderProcessor.PrintAdvertAndUpdateOrder(order);
         }
         else if (order.District.ToLower() == "middleton")
         {
            var orderProcessor = new MiddletonOrderProcessor(_dealService, _chamberOfCommerceApi, _printer);
            order = await orderProcessor.PrintAdvertAndUpdateOrder(order);
         }
         else if (order.District.ToLower() == "county")
         {
            var orderProcessor = new CountyOrderProcessor(_printer);
            order =  orderProcessor.PrintAdvertAndUpdateOrder(order);
         }
         else if (order.District.ToLower() == "downtown")
         {
            var orderProcessor = new DowntownOrderProcessor(_printer);
            order = orderProcessor.PrintAdvertAndUpdateOrder(order);
         }
         return order;
      }



   }
}