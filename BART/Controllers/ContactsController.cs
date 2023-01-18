﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        [ProducesResponseType(typeof(ContactDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ContactDto>> Post([FromBody]CreateContactDto contactDto)
        {
            var result = await _contactService.CreateContactAsync(contactDto);
            return Ok(result);
        }
    }
}

