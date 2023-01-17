using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BART.Interfaces;
using BART.Models;
using BART.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BART.Controllers
{
    [ApiController]
    [Route("api/contacts")]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpPost]
        public IActionResult Post([FromBody]ContactDto contactDto)
        {
            if (contactDto == null)
            {
                return BadRequest("Contact is null.");
            }

            var result = _contactService.Add(contactDto);
            return Ok(result);
        }
    }
}

