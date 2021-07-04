using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using S13_DPAMongoDB.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace S13_DPAMongoDB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;

        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [Route("GetCustomers")]
        public async Task<IActionResult> GetCustomers()
        {
            var result = await _customerService.GetCustomers();
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        [Route("GetCustomerById")]
        public async Task<IActionResult> GetCustomerById(string id)
        {
            var result = await _customerService.GetCustomerById(id);
            if (result == null)
                return NotFound();

            return Ok(new { Customer = result });
        }




    }
}
