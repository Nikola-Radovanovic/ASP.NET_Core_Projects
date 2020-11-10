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
    public class ProductionYearsController : ControllerBase
    {
        private readonly IProductionYearDataAccess _productionYearDataAccess;

        public ProductionYearsController(IProductionYearDataAccess productionYearDataAccess)
        {
            _productionYearDataAccess = productionYearDataAccess;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            var years = await _productionYearDataAccess.GetYears();

            if (years is null)
            {
                return NotFound();
            }

            return Ok(years);
        }
    }
}