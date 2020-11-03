using FluentAssertions;
using Moq;
using Refactoring.Web.DomainModels;
using Refactoring.Web.Services;
using Refactoring.Web.Services.Interfaces;
using Refactoring.Web.Services.OrderProcessors;
using System.Threading.Tasks;
using Xunit;

namespace Refactoring.Test.Tests.Services.OrderProcessorTests
{
   public class TestCambridgeOrderProcessor
   {
      [Fact]
      public async void GivenDateIsTuesday_ImageUrl_Set_OnOrderAdvert()
      {
         var testOrder = new Order
         {
            Id = "foo"
         };

         var fakeDateTimeResolver = new Mock<IDateTimeResolver>();
         fakeDateTimeResolver.Setup(m => m.IsItTuesday()).Returns(true);

         var fakeChamberOfCommerceApi = new Mock<IChamberOfCommerceApi>();

         var fakeDataResult = new DataResult
         {
            ThumbnailUrl = "http://example.com/some_thumbnail.png",
            Title = "My Title..."
         };

         var fakeAdvertPrinter = new Mock<IAdvertPrinter>();
         //var fakeAdvert = new Advert
         //{
         //   CreatedOn = DateTime.UtcNow,
         //   ImageUrl = fakeDataResult.ThumbnailUrl,
         //   Heading = "Some Title..."
         //};

         //fakeAdvertPrinter.Setup(m => m.Print(fakeAdvert, false));

         fakeChamberOfCommerceApi.Setup(m => m.GetImageAndThumbnailDataFor(It.IsAny<string>()))
            .Returns(Task.FromResult(fakeDataResult));

         var sut = new CambridgeOrderProcessor(fakeChamberOfCommerceApi.Object, fakeAdvertPrinter.Object, fakeDateTimeResolver.Object);

         // Act
         var result = await sut.PrintAdvertAndUpdateOrder(testOrder);

         // Assert
         result.Advert.ImageUrl.Should().Be(fakeDataResult.ThumbnailUrl);
      }

      [Fact]
      public async void GivenDateIsNotTuesday_ImageUrl_NotSet_OnOrderAdvert()
      {
         var testOrder = new Order
         {
            Id = "foo"
         };

         var fakeDateTimeResolver = new Mock<IDateTimeResolver>();
         fakeDateTimeResolver.Setup(m => m.IsItTuesday()).Returns(false);

         var fakeChamberOfCommerceApi = new Mock<IChamberOfCommerceApi>();

         var fakeDataResult = new DataResult
         {
            ThumbnailUrl = "http://example.com/some_thumbnail.png",
            Title = "My Title..."
         };

         var fakeAdvertPrinter = new Mock<IAdvertPrinter>();

         fakeChamberOfCommerceApi.Setup(m => m.GetImageAndThumbnailDataFor(It.IsAny<string>()))
            .Returns(Task.FromResult(fakeDataResult));

         var sut = new CambridgeOrderProcessor(fakeChamberOfCommerceApi.Object, fakeAdvertPrinter.Object, fakeDateTimeResolver.Object);

         // Act
         var result = await sut.PrintAdvertAndUpdateOrder(testOrder);

         // Assert
         result.Advert.ImageUrl.Should().BeNull();
      }
   }
}
