using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AutoDealerClassLibrary.Models
{
    public class AdModel
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "Title can be max 50 characters long")]
        [RegularExpression(@"^[\w\t \[\]\\ `!@#$%\^&?*()={}:;,<>~+'\./|-]+$")] // Alfanumerics with underscore and special characters
        public string Title { get; set; }
        
        [DisplayName("Date Posted")]
        public DateTime DatePosted { get; set; } = DateTime.Now;

        [MaxLength(1000, ErrorMessage = "Description can be 1000 characters long")]
        [RegularExpression(@"^[\w\t \[\]\\ `!@#$%\^&?*()={}:;,<>~+'\./|-]+$")] // Alfanumerics with underscore and special characters
        public string Description { get; set; }

        [MaxLength(8, ErrorMessage = "Price can be 8 digits long")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "You can enter only numbers(0-9) without spacings")]
        [Required(ErrorMessage = "Please enter the venchile price")]
        public decimal Price { get; set; }


        // Basic Car Information

        [MaxLength(30, ErrorMessage = "Model name can be max 50 characters long")]
        [RegularExpression(@"^[\w\t \[\]\\ `!@#$%\^&?*()={}:;,<>~+'\./|-]+$")]
        [DisplayName("Model")]
        [Required(ErrorMessage = "Enter name of the model")]
        public string ModelName { get; set; }

        [MaxLength(7, ErrorMessage = "You can enter max 7 digits")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "You can enter only numbers(0-9) without spacings")]
        [DisplayName("Kilometers")]
        [Required(ErrorMessage = "Enter number of kilometers")]
        public string Kilometers { get; set; }

        [MaxLength(5, ErrorMessage = "You can enter max 5 digits")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "You can enter only numbers(0-9) without spacings")]
        [DisplayName("Capacity(cm3)")]
        [Required(ErrorMessage = "Enter number of cubic capacity")]
        public string CubicCapacity { get; set; }

        [MaxLength(5, ErrorMessage = "You can enter max 5 digits")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "You can enter only numbers(0-9) without spacings")]
        [DisplayName("Power(HP)")]
        [Required(ErrorMessage = "Enter number of horse power")]
        public string HorsePower { get; set; }

        [DisplayName("Power(KW)")]
        public string Kilowatts { get; set; }


        // Contact

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


        // "Registered" client, identity improvisation
        // Registered client can create an Ad in anybody else name, who is not registered user

        public int ClientId { get; set; }


        // Select lists

        public int BrandId { get; set; }

        public int CarBodyTypeId { get; set; }

        public int CarConditionId { get; set; }

        public int ColorId { get; set; }

        public int FuelId { get; set; }

        public int ProductionYearId { get; set; }
    }
}