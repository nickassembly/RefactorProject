using Refactoring.Web.DomainModels;
using Refactoring.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactoring.Web.Services.Printers
{
   public class AdvertPrinter : IAdvertPrinter
   {
      public void Print(Advert advert, bool IsDefaultAdvert)
      {
         if (IsDefaultAdvert)
         {
            Console.WriteLine("Printing Default Advert");
         }
         else
         {
            Console.WriteLine("Printing Custom Advert: " + advert.Heading);
         }
         System.Threading.Thread.Sleep(3000);
      }

   }
}
