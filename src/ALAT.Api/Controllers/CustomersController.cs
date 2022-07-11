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
        public async Task<IActionResult> GetCustomers()
        {
            try
            {
                var customers = await _customerRepository.GetCustomersAsync();
                return Ok(new { success = true, data = customers });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
            }
        }

        [HttpPost("onboard")]
        public async Task<IActionResult> Create(CreateCustomerRequest request)
        {
            try
            {
                var res = await _customerRepository.CreateCustomerAsync(request);
                if (res.Success)
                {
                    return Ok(new { success = true, message = res.Message });
                }
                
                return StatusCode(StatusCodes.Status400BadRequest, new { error = res.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
            }
        }

        [HttpPost("verify-phone")]
        public async Task<IActionResult> Verify(OtpRequest request)
        {
            try
            {
                var res = await _customerRepository.VerifyCustomerPhoneAsync(request);

                if (res.Success)
                {
                    return Ok(new { success = true, message = res.Message });
                }

                return StatusCode(StatusCodes.Status400BadRequest, new { error = res.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
            }
        }
    }
}
