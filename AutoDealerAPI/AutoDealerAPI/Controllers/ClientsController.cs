using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoDealerAPI.Models;
using AutoDealerClassLibrary.DataAccess.Interfaces;
using AutoDealerClassLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoDealerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientDataAccess _clientDataAccess;

        public ClientsController(IClientDataAccess clientDataAccess)
        {
            _clientDataAccess = clientDataAccess;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            var clients = await _clientDataAccess.GetClients();

            if (clients is null)
            {
                return NotFound();
            }

            return Ok(clients);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var client = await _clientDataAccess.GetClientById(id);

            if (client != null)
            {
                var output = new
                {
                    Client = client
                };

                return Ok(output);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ValidateModel]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(ClientModel client)
        {
            int id = await _clientDataAccess.CreateClient(client);

            return Ok(new { Id = id });
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put([FromBody]UpdateClientModel updateClient)
        {
            await _clientDataAccess.UpdateClient(updateClient.Id, 
                                                 updateClient.ClientName, 
                                                 updateClient.Address, 
                                                 updateClient.City, 
                                                 updateClient.ZIP, 
                                                 updateClient.Country, 
                                                 updateClient.Phone);

            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            await _clientDataAccess.DeleteClient(id);

            return Ok();
        }
    }
}