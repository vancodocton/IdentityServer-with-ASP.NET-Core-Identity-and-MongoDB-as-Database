﻿using ISClient.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ISClient.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BankController : ControllerBase
    {
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public string TranferAmount()
        {
            return "amount transferred";
        }

        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<Customer> ReadCustomerInfo(Guid userId)
        {
            if (userId == Guid.Empty)
                return BadRequest();

            var currentUserId = User.FindFirstValue("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");

            if (Guid.Parse(currentUserId) != userId)
            {
                if (!User.IsInRole("Admin"))
                    return Unauthorized();
            }

            Customer customer = new Customer();
            // read customer from database and add it to "customer" object

            return customer;
        }

        [Authorize(Policy = "Deactivate")]
        [HttpPost("{id}")]
        public string UpdateCustomerInfo()
        {
            var currentUserId = User.FindFirstValue("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
            var currentUserEmail = User.FindFirstValue("email");

            // decativate "currentUserId" and inform this on email "currentUserEmail"                
            return "Success";
        }
    }
}
