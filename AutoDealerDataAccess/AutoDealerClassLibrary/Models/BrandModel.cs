using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AutoDealerClassLibrary.Models
{
    public class BrandModel
    {
        public int Id { get; set; }

        [DisplayName("Brand")]
        public string BrandName { get; set; }
    }
}