using Domain.Interface;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Intefaces;
using Service.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private IBaseService<Client> _baseClientService;
        private IClientService _clientsService;
        private readonly ILogger<UserController> _logger;
        

        public ClientController(IBaseService<Client> baseClientService
            , ILogger<UserController> logger, IClientService clientsService)
        {
            _baseClientService = baseClientService;
            _clientsService = clientsService;
            _logger = logger;
            
        }

        [HttpPost]
        [Route("CreateClient")]
        public IActionResult Create([FromBody] Client client)
        {
            if (client == null)
                return NotFound();

            return Execute(() => _baseClientService.Add<ClientValidator>(client).Id);
        }
        [HttpPut]
        public IActionResult Update([FromBody] Client client)
        {
            if (client == null)
                return NotFound();

            return Execute(() => _baseClientService.Update<ClientValidator>(client));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _baseClientService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpGet]

        public IActionResult Get()
        {
            return Execute(() => _clientsService.GetClientes());
        }

        [HttpGet("{id}")]

        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _baseClientService.GetById(id));
        }

        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
