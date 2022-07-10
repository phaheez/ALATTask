using ALAT.Core.DTOs;
using ALAT.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALAT.Api.Controllers
{
    [Route("api/values")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IValuesRepository _valuesRepository;

        public ValuesController(IValuesRepository valuesRepository)
        {
            _valuesRepository = valuesRepository ?? throw new ArgumentNullException(nameof(valuesRepository));
        }

        [HttpGet("state/getAll")]
        public async Task<ActionResult<List<CustomerResponse>>> GetStates()
        {
            try
            {
                var states = await _valuesRepository.GetStatesAsync();
                return Ok(states);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
            }
        }

        [HttpGet("lga/getAll")]
        public async Task<ActionResult<List<CustomerResponse>>> GetLgas()
        {
            try
            {
                var lgas = await _valuesRepository.GetLgasAsync();
                return Ok(lgas);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
            }
        }

        [HttpGet("lga/getByStateId/{id}")]
        public async Task<ActionResult<List<CustomerResponse>>> GetLgaByStateId(int id)
        {
            try
            {
                var lga = await _valuesRepository.GetLgasByStateIdAsync(id);
                return Ok(lga);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
            }
        }
    }
}
