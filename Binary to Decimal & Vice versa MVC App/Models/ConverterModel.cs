using System.ComponentModel.DataAnnotations;

namespace Binary_to_Decimal___Vice_versa_MVC_App.Models
{
    public class ConverterModel
    {
        [Required(ErrorMessage = "Please enter a value")]
        public string InputValue { get; set; }

        public string? Result { get; set; }

        [Required(ErrorMessage = "Please select a conversion type")]
        public string ConversionType { get; set; }

        public ConverterModel()
        {
            ConversionType = "BinaryToDecimal"; // Set a default value
        }
    }
}
