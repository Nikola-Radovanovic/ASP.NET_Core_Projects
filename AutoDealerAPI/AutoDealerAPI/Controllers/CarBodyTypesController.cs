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
    public class CarBodyTypesController : ControllerBase
    {
        private readonly ICarBodyTypeDataAccess _carBodyTypeDataAccess;

        public CarBodyTypesController(ICarBodyTypeDataAccess carBodyTypeDataAccess)
        {
            _carBodyTypeDataAccess = carBodyTypeDataAccess;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            var bodyTypes = await _carBodyTypeDataAccess.GetBodyTypes();

            if (bodyTypes is null)
            {
                return NotFound();
            }

            return Ok(bodyTypes);
        }
    }
}