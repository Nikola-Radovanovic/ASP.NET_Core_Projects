using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AutoDealerClassLibrary.Models
{
    public class ProductionYearModel
    {
        public int Id { get; set; }

        [DisplayName("Year of Production")]
        public string YearName { get; set; }
    }
}