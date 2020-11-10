using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AutoDealerClassLibrary.Models
{
    public class FuelModel
    {
        public int Id { get; set; }

        [DisplayName("Fuel")]
        public string FuelType { get; set; }
    }
}