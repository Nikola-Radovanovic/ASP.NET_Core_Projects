using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoDealerAPI.Models;
using AutoDealerClassLibrary.DataAccess.Interfaces;
using AutoDealerClassLibrary.Models;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoDealerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdsController : ControllerBase
    {
        private readonly IAdDataAccess _adDataAccess;
        private readonly IBrandDataAccess _brandDataAccess;
        private readonly IClientDataAccess _clientDataAccess;
        private readonly ICarBodyTypeDataAccess _carBodyTypeDataAccess;
        private readonly ICarConditionDataAccess _carConditionDataAccess;
        private readonly IColorDataAccess _colorDataAccess;
        private readonly IFuelDataAccess _fuelDataAccess;
        private readonly IProductionYearDataAccess _productionYearDataAccess;


        public AdsController(IAdDataAccess adDataAccess, IBrandDataAccess brandDataAccess, 
                             ICarBodyTypeDataAccess carBodyTypeDataAccess, ICarConditionDataAccess carConditionDataAccess, 
                             IClientDataAccess clientDataAccess, IColorDataAccess colorDataAccess, 
                             IFuelDataAccess fuelDataAccess, IProductionYearDataAccess productionYearDataAccess)
        {
            _adDataAccess = adDataAccess;
            _brandDataAccess = brandDataAccess;
            _carBodyTypeDataAccess = carBodyTypeDataAccess;
            _carConditionDataAccess = carConditionDataAccess;
            _clientDataAccess = clientDataAccess;
            _colorDataAccess = colorDataAccess;
            _fuelDataAccess = fuelDataAccess;
            _productionYearDataAccess = productionYearDataAccess;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            var ads = await _adDataAccess.GetAds();

            if (ads is null)
            {
                return NotFound();
            }

            return Ok(ads);
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

            var ad = await _adDataAccess.GetAdById(id);

            if (ad != null)
            {
                var clients = await _clientDataAccess.GetClients();
                var brands = await _brandDataAccess.GetBrands();
                var bodies = await _carBodyTypeDataAccess.GetBodyTypes();
                var colors = await _colorDataAccess.GetColors();
                var fuels = await _fuelDataAccess.GetFuels();
                var years = await _productionYearDataAccess.GetYears();
                var conditions = await _carConditionDataAccess.GetCarConditions();

                var output = new
                {
                    Ad = ad,

                    ClientNamee = clients.Where(c => c.Id == ad.ClientId).FirstOrDefault()?.ClientName,
                    Addresss = clients.Where(c => c.Id == ad.ClientId).FirstOrDefault()?.Address,
                    Cityy = clients.Where(c => c.Id == ad.ClientId).FirstOrDefault()?.City,
                    ZIPP = clients.Where(c => c.Id == ad.ClientId).FirstOrDefault()?.ZIP,
                    Countryy = clients.Where(c => c.Id == ad.ClientId).FirstOrDefault()?.Country,
                    Phonee = clients.Where(c => c.Id == ad.ClientId).FirstOrDefault()?.Phone,

                    Brand = brands.Where(b => b.Id == ad.BrandId).FirstOrDefault()?.BrandName,
                    
                    Body = bodies.Where(b => b.Id == ad.CarBodyTypeId).FirstOrDefault()?.BodyType,
                    
                    Color = colors.Where(c => c.Id == ad.ColorId).FirstOrDefault()?.ColorName,
                    
                    Fuel = fuels.Where(f => f.Id == ad.FuelId).FirstOrDefault()?.FuelType,
                    
                    Year = years.Where(y => y.Id == ad.ProductionYearId).FirstOrDefault()?.YearName,
                    
                    FirstOwnerr = conditions.Where(c => c.Id == ad.CarConditionId).FirstOrDefault()?.FirstOwner,
                    Warrantyy = conditions.Where(c => c.Id == ad.CarConditionId).FirstOrDefault()?.Warranty,
                    Garagedd = conditions.Where(c => c.Id == ad.CarConditionId).FirstOrDefault()?.Garaged,
                    ServiceBookk = conditions.Where(c => c.Id == ad.CarConditionId).FirstOrDefault()?.ServiceBook,
                    SpareKeyy = conditions.Where(c => c.Id == ad.CarConditionId).FirstOrDefault()?.SpareKey,
                    Restauratedd = conditions.Where(c => c.Id == ad.CarConditionId).FirstOrDefault()?.Restaurated,
                    Oldtimerr = conditions.Where(c => c.Id == ad.CarConditionId).FirstOrDefault()?.Oldtimer,
                    AdaptedForTheDisabledd = conditions.Where(c => c.Id == ad.CarConditionId).FirstOrDefault()?.AdaptedForTheDisabled,
                    TaxiCarr = conditions.Where(c => c.Id == ad.CarConditionId).FirstOrDefault()?.TaxiCar,
                    TestCarr = conditions.Where(c => c.Id == ad.CarConditionId).FirstOrDefault()?.TestCar,
                    Tuningg = conditions.Where(c => c.Id == ad.CarConditionId).FirstOrDefault()?.Tuning
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
        public async Task<IActionResult> Post(AdModel ad)
        {
            var KW = Convert.ToInt32(ad.HorsePower) * 0.75;
            ad.Kilowatts = KW.ToString();

            int id = await _adDataAccess.CreateAd(ad);

            return Ok(new { Id = id });
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put([FromBody]UpdateAdModel updateAd)
        {
            await _adDataAccess.UpdateAd(updateAd.Id,
                                         updateAd.Title,
                                         updateAd.Description,
                                         updateAd.Price,
                                         updateAd.ModelName,
                                         updateAd.Kilometers,
                                         updateAd.CubicCapacity,
                                         updateAd.HorsePower,
                                         updateAd.Kilowatts,
                                         updateAd.ClientName,
                                         updateAd.Address,
                                         updateAd.City,
                                         updateAd.ZIP,
                                         updateAd.Country,
                                         updateAd.Phone,
                                         updateAd.ClientId,
                                         updateAd.BrandId,
                                         updateAd.CarBodyTypeId,
                                         updateAd.CarConditionId,
                                         updateAd.ColorId,
                                         updateAd.FuelId,
                                         updateAd.ProductionYearId);

            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            await _adDataAccess.DeleteAd(id);

            return Ok();
        }
    }
}