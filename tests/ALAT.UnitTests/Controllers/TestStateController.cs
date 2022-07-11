using ALAT.Api.Controllers;
using ALAT.Core.Interfaces;
using ALAT.Core.Utils;
using ALAT.UnitTests.MockData;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ALAT.UnitTests.Controllers
{
    public class TestStateController
    {
        [Fact]
        public async Task GetAllStateAsync_ShouldReturn200Status()
        {
            // Arrange
            var stateRepo = new Mock<IValuesRepository>();
            stateRepo.Setup(_ => _.GetStatesAsync()).ReturnsAsync(StateMockData.GetAllStates());
            var sut = new ValuesController(stateRepo.Object);

            // Act
            var result = (OkObjectResult)await sut.GetStates();

            // Assert
            result.StatusCode.Should().Be(200);
        }
    }
}
