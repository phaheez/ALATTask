using ALAT.Core.DTOs;
using ALAT.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALAT.Api.Controllers
{
    [Route("api/bank")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly IBankRepository _bankRepository;
        private readonly IConfiguration _config;

        public BankController(IBankRepository bankRepository, IConfiguration config)
        {
            _bankRepository = bankRepository ?? throw new ArgumentNullException(nameof(bankRepository));
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<Bank>> GetCustomers()
        {
            try
            {
                var url = _config.GetSection("GetBankUrl").Value;
                var subscriptionKey = _config.GetSection("SubscriptionKey").Value;

                var bank = await _bankRepository.GetAllBanks(url, subscriptionKey);
                return Ok(bank);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
            }
        }
    }
}
