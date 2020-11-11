﻿using FluentAssertions;
using Refactoring.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Refactoring.Test.Tests.Services
{
   public class TestDealService
   {
      [Fact]
      public void Given_MorningDateTime_GenerateDeal_Returns_AmRate() 
      {
         // Arrange
         var sut = new DealService();
         var morningTime = new DateTime(2020, 10, 10, 10, 10, 10);
         var amRate = DealService.AmRate;

         // Act
         var generatedDealRate = sut.GenerateDeal(morningTime);

         // Assert
         generatedDealRate.Should().Be(amRate);
           
      }

      [Fact]
      public void Given_MorningDateTime_GenerateDeal_Returns_PmRate()
      {
         // Arrange
         var sut = new DealService();
         var afternoonTime = new DateTime(2020, 10, 10, 20, 10, 10);
         var pmRate = DealService.PmRate;

         // Act
         var generatedDealRate = sut.GenerateDeal(afternoonTime);

         // Assert
         generatedDealRate.Should().Be(pmRate);

      }
   }
}
