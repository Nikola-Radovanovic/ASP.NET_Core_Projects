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
    public class BrandsController : ControllerBase
    {
        private readonly IBrandDataAccess _brandDataAccess;

        public BrandsController(IBrandDataAccess brandDataAccess)
        {
            _brandDataAccess = brandDataAccess;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            var brands = await _brandDataAccess.GetBrands();

            if (brands is null)
            {
                return NotFound();
            }

            return Ok(brands);
        }
    }
}