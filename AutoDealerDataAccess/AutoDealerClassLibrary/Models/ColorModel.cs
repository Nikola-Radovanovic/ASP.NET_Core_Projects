using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AutoDealerClassLibrary.Models
{
    public class ColorModel
    {
        public int Id { get; set; }

        [DisplayName("Color")]
        public string ColorName { get; set; }
    }
}