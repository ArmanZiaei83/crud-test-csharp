using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Mc2.CrudTest.Application.DTOs.Customers;
using Mc2.CrudTest.Application.Interfaces.Services;
using Mc2.CrudTest.Shared;
using Mc2.CrudTest.Shared.Generators;

namespace Mc2.CrudTest.Presentation.Server.Controllers
{
    [ApiController]
    [Route("customers")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _service;

        public CustomerController(CustomerService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<int> Register(RegisterCustomerDto dto)
        {
            return await _service.Register(dto);
        }

        [HttpGet]
        public async Task<GetCustomerDto> Get(int id)
        {
            return await _service.Get(id);
        }
    }
}