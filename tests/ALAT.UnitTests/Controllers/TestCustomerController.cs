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
    public class TestCustomerController
    {
        private readonly CustomersController _controller;
        private readonly Mock<ICustomerRepository> _customerRepo;

        public TestCustomerController()
        {
            _customerRepo = new Mock<ICustomerRepository>();
            _controller = new CustomersController(_customerRepo.Object);
        }

        [Fact]
        public async Task GetCustomersAsync_ShouldReturn200Status()
        {
            // Arrange
            _customerRepo.Setup(_ => _.GetCustomersAsync())
                .ReturnsAsync(CustomerMockData.GetAllCustomers());

            // Act
            var result = (OkObjectResult)await _controller.GetCustomers();

            // Assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task OnboardCustomerAsync_ShouldCall_ICustomerRepo_Create_AtleastOnce()
        {
            // Arrange
            var newCustomer = CustomerMockData.NewCustomer();

            // Act
            var result = await _controller.Create(newCustomer);

            // Assert
            _customerRepo.Verify(_ => _.CreateCustomerAsync(newCustomer), Times.Exactly(1));
        }

        [Fact]
        public async Task VerifyPhoneAsync_ShouldCall_ICustomerRepo_Verify_AtleastOnce()
        {
            // Arrange
            var verifyCustomer = CustomerMockData.VerifyCustomerPhone();

            // Act
            var result = await _controller.Verify(verifyCustomer);

            // Assert
            _customerRepo.Verify(_ => _.VerifyCustomerPhoneAsync(verifyCustomer), Times.Exactly(1));
        }
    }
}
