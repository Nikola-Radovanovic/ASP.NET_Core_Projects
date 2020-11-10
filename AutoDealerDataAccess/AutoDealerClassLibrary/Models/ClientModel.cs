using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AutoDealerClassLibrary.Models
{
    public class ClientModel
    {
        public int Id { get; set; }

        [DisplayName("Date Registered")]
        public DateTime DateRegistered { get; set; } = DateTime.Now;

        [DisplayName("Client Full Name")]
        [MaxLength(50, ErrorMessage = "Name can contain max 50 letters")]
        [RegularExpression("^[a-z A-Z]+$", ErrorMessage = "You can enter only letters and spacings")]
        [Required(ErrorMessage = "Enter client name")]
        public string ClientName { get; set; }

        [MaxLength(100, ErrorMessage = "Address can be 100 characters long")]
        [RegularExpression(@"^[\w ,\-\(\)/]+$", ErrorMessage = "You can enter only letters, numbers and /-,() special characters")]
        [Required(ErrorMessage = "Enter client address")]
        public string Address { get; set; }

        [MaxLength(30, ErrorMessage = "City name can be only 30 letters long")]
        [RegularExpression("^[a-z A-Z]+$", ErrorMessage = "You can enter only letters and spacings")]
        [Required(ErrorMessage = "Enter client city")]
        public string City { get; set; }

        [MaxLength(10, ErrorMessage = "You can enter max 10 numbers")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "You can enter only numbers without spacings")]
        [Required(ErrorMessage = "Enter postal code")]
        public string ZIP { get; set; }

        [MaxLength(30, ErrorMessage = "You can enter max 30 letters")]
        [RegularExpression(@"^[a-zA-Z \(\),]+$", ErrorMessage = "You can enter only letters, spacings and ,() special characters")]
        [Required(ErrorMessage = "Enter client country")]
        public string Country { get; set; }

        [MaxLength(20, ErrorMessage = "You can enter max 20 numbers")]
        [RegularExpression(@"^[0-9 \/-]+$", ErrorMessage = "You can enter only numbers, spacings and /+- special characters")]
        [Required(ErrorMessage = "Enter client phone")]
        public string Phone { get; set; }
    }
}