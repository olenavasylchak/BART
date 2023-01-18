using System;
using System.Net;

using BART.Interfaces;
using BART.Models;
using BART.Models.Dto;
using BART.Services;

using Microsoft.AspNetCore.Mvc;

namespace BART.Controllers
{
    [ApiController]
    [Route("api/incidents")]
    public class IncidentsController : ControllerBase
    {
        private readonly IIncidentService _incidentService;

        public IncidentsController(IIncidentService incidentService)
        {
            _incidentService = incidentService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(IncidentDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IncidentDto>> Post([FromBody] CreateIncidentDto incidentDto)
        {
            var result = await _incidentService.CreateIncidentAsync(incidentDto);
            return Ok(result);
        }
    }
}

