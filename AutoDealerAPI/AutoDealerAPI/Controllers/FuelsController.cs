using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;
using AutoDealerClassLibrary.DataAccess.Interfaces;
using AutoDealerClassLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoDealerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelsController : ControllerBase
    {
        private readonly IFuelDataAccess _fuelDataAccess;

        public FuelsController(IFuelDataAccess fuelDataAccess)
        {
            _fuelDataAccess = fuelDataAccess;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            var fuels = await _fuelDataAccess.GetFuels();

            if (fuels is null)
            {
                return NotFound();
            }

            return Ok(fuels);
        }
    }
}