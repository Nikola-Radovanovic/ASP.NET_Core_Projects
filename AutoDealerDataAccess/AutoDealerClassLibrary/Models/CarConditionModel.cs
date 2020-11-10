using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AutoDealerClassLibrary.Models
{
    public class CarConditionModel
    {
        public int Id { get; set; }

        [DisplayName("First Owner")]
        public bool FirstOwner { get; set; }

        public bool Warranty { get; set; }
        
        public bool Garaged { get; set; }

        [DisplayName("Service Book")]
        public bool ServiceBook { get; set; }

        [DisplayName("Spare Key")]
        public bool SpareKey { get; set; }

        public bool Restaurated { get; set; }
        
        public bool Oldtimer { get; set; }

        [DisplayName("Adapted For The Disabled")]
        public bool AdaptedForTheDisabled { get; set; }

        [DisplayName("Taxi Car")]
        public bool TaxiCar { get; set; }

        [DisplayName("Test Car")]
        public bool TestCar { get; set; }

        public bool Tuning { get; set; }
    }
}