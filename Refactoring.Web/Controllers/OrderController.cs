using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Refactoring.Web.DomainModels;
using Refactoring.Web.Services;
using Refactoring.Web.Services.Interfaces;

namespace Refactoring.Web.Controllers
{

   public class OrderController : Controller
   {
      private readonly IOrderService _orderService;
      public OrderController(IOrderService orderService)
      {
         _orderService = orderService;
      }

      public IActionResult Index()
      {
         return View();
      }

      [HttpPost]
      public async Task<IActionResult> SubmitOrder(string selectedDistrict, decimal orderAmount)
      {
         var order = new Order();
         order.District = selectedDistrict;
         order.Total = orderAmount;
         var orderService = new OrderService(order);
         await orderService.ProcessOrder();
         var completedOrder = orderService.GetOrder();
         return View(completedOrder);
      }
   }
}