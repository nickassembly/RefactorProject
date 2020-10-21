using Refactoring.Web.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactoring.Web.Services.Interfaces
{
   public interface IOrderService
   {
      Task<Order> ProcessOrder(Order order);
   }
}
