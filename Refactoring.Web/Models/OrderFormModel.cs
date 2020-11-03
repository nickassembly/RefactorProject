using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Refactoring.Web.Models
{
   public class OrderFormModel
   {
      public IEnumerable<SelectListItem> Districts { get; set; }
      public string SelectedDistrict { get; set; }
      public decimal OrderAmount { get; set; }
   }
}