using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoDealerAPI.Models
{
    public class UpdateAdModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ModelName { get; set; }
        public string Kilometers { get; set; }
        public string CubicCapacity { get; set; }
        public string HorsePower { get; set; }
        public string Kilowatts { get; set; }
        public string ClientName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ZIP { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public int ClientId { get; set; }
        public int BrandId { get; set; }
        public int CarBodyTypeId { get; set; }
        public int CarConditionId { get; set; }
        public int ColorId { get; set; }
        public int FuelId { get; set; }
        public int ProductionYearId { get; set; }
    }
}