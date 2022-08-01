using ALAT.Api.Controllers;
using ALAT.Core.DTOs;
using ALAT.Core.Interfaces;
using ALAT.Core.Utils;
using ALAT.UnitTests.MockData;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ALAT.UnitTests.Controllers
{
    public class TestBankController
    {
        private readonly BankController _controller;
        private readonly Mock<IBankRepository> _bankRepo;
        private readonly IConfiguration _config;
        private readonly Mock<IConfigurationSection> _configSection;

        public TestBankController()
        {
            _bankRepo = new Mock<IBankRepository>();

            var inMemorySettings = new Dictionary<string, string> {
                {"GetBankUrl", "https://wema-alatdev-apimgt.azure-api.net/alat-test/api/Shared/GetAllBanks"}
            };

            _config = new ConfigurationBuilder().AddInMemoryCollection(inMemorySettings).Build();

            _controller = new BankController(_bankRepo.Object, _config);
        }

        [Fact]
        public async Task GetAllBanksAsync_ShouldReturn200Status()
        {
            // Arrange
            var url = _config.GetSection("GetBankUrl").Value;
            _bankRepo.Setup(_ => _.GetAllBanks(url)).ReturnsAsync(BankMockData.AllBanks());

            // Act
            var result = (OkObjectResult)await _controller.GetAllBanks();

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var item = Assert.IsType<BankResponse>(result.Value);
            Assert.Equal(5, item.data.result.Count);
        }
    }
}
