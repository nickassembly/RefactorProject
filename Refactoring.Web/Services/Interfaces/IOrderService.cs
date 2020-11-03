using Refactoring.Web.DomainModels;
using System.Threading.Tasks;

namespace Refactoring.Web.Services.Interfaces
{
   public interface IOrderService
   {
      Task<Order> ProcessOrder(Order order);
   }
}
