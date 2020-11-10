using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoDealerClassLibrary.DataAccess.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoDealerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarConditionsController : ControllerBase
    {
        private readonly ICarConditionDataAccess _carConditionDataAccess;

        public CarConditionsController(ICarConditionDataAccess carConditionDataAccess)
        {
            _carConditionDataAccess = carConditionDataAccess;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            var carConditions = await _carConditionDataAccess.GetCarConditions();

            if (carConditions is null)
            {
                return NotFound();
            }

            return Ok(carConditions);
        }
    }
}