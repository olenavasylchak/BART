using System;

using BART.Interfaces;
using BART.Models;
using BART.Models.Dto;
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
        public IActionResult Post([FromBody]IncidentDto incidentDto)
        {
            if (incidentDto == null)
            {
                return BadRequest("Incident is null.");
            }

            var result = _incidentService.Add(incidentDto);
            return Ok(result);
        }
    }
}

