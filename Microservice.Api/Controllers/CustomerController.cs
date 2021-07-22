using Microservice.Domain;
using Microservice.Domain.Contracts.DomainService;
using Microservice.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IDSCustomer _dsCustomer;

        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ILogger<CustomerController> logger, IDSCustomer dsCustomer)
        {
            _logger = logger;
            _dsCustomer = dsCustomer;
        }

        [HttpGet]
        public async Task<IEnumerable<Customer>> Get()
        {
            return await _dsCustomer.Get();
        }
    }
}
