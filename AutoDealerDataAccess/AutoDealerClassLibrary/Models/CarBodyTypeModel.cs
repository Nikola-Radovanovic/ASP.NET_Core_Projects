using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AutoDealerClassLibrary.Models
{
    public class CarBodyTypeModel
    {
        public int Id { get; set; }

        [DisplayName("Car Body Type")]
        public string BodyType { get; set; }
    }
}