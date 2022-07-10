using ALAT.Core.DTOs;
using ALAT.Core.Exceptions;
using ALAT.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALAT.Api.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<List<CustomerResponse>>> GetCustomers()
        {
            try
            {
                var customers = await _customerRepository.GetCustomersAsync();
                return Ok(customers);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
            }
        }

        [HttpPost("onboard")]
        public async Task<ActionResult> Create(CreateCustomerRequest request)
        {
            try
            {
                var customer = await _customerRepository.CreateCustomerAsync(request);
                if (customer != null)
                {
                    return Ok(new { success = true, message = "Onboarding was successful. Kindly enter '112233' to verify your phone number. " });
                }
                return BadRequest("Something went wrong");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
            }
        }

        [HttpPost("verify-phone")]
        public async Task<ActionResult> Verify(int customerId, OtpRequest request)
        {
            try
            {
                var res = await _customerRepository.VerifyCustomerPhoneAsync(customerId, request);
                var success = res;
                var message = res ? "Verification Successful" : "Verification Failed";

                return Ok(new { success, message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
            }
        }
    }
}
