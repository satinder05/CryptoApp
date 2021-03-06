﻿using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using WebApp.Controllers;
using WebApp.Service;
using WebApp.Tests.Common;
using Xunit;

namespace WebApp.UnitTests.Service
{
    public class UserPreferenceServiceTests : TestBase
    {
        private readonly ILogger _logger = Mock.Of<ILogger<PreferredCoinController>>();

        [Fact]
        public async Task SavePreferredCoin_GivenValidCoinId_ShouldSavePreferredCoin()
        {
            //Arrange
            int coinId = 2;

            //Act
            var result = await new UserPreferenceService(_context, _logger).SavePreferredCoin(coinId);

            //Assert
            Assert.IsType<int>(result);
            Assert.NotEqual(0, result);
        }

        [Fact]
        public async Task SavePreferredCoin_GivenInValidCoinId_ShouldThrowException()
        {
            int coinId = 10;
            var service = new UserPreferenceService(_context, _logger);

            await Assert.ThrowsAsync<ArgumentException>(() => service.SavePreferredCoin(coinId));
        }
    }
}
