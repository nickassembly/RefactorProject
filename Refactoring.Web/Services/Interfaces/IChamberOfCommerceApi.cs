using System.Threading.Tasks;

namespace Refactoring.Web.Services.Interfaces
{
   public interface IChamberOfCommerceApi
   {
      Task<DataResult> GetFor(string district);
   }
}