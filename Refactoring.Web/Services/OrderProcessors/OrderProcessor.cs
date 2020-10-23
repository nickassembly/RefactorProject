using Refactoring.Web.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactoring.Web.Services.OrderProcessors
{
   public abstract class OrderProcessor
   {
      public abstract Task<Order> PrintAdvertAndUpdateOrder(Order order);
   }
}
