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
    public class ColorsController : ControllerBase
    {
        private readonly IColorDataAccess _colorDataAccess;

        public ColorsController(IColorDataAccess colorDataAccess)
        {
            _colorDataAccess = colorDataAccess;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            var colors = await _colorDataAccess.GetColors();

            if (colors is null)
            {
                return NotFound();
            }

            return Ok(colors);
        }
    }
}