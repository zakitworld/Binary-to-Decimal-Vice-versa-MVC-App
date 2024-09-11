using Binary_to_Decimal___Vice_versa_MVC_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Binary_to_Decimal___Vice_versa_MVC_App.Controllers
{
    public class ConverterController : Controller
    {
        public IActionResult Index()
        {
            return View(new ConverterModel());
        }

        [HttpPost]
        public IActionResult PerformConversion(ConverterModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Result = model.ConversionType == "BinaryToDecimal"
                        ? ConvertBinaryToDecimal(model.InputValue)
                        : ConvertDecimalToBinary(model.InputValue);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"An error occurred: {ex.Message}");
                }
            }

            return View("Index", model);
        }

        [HttpPost]
        public IActionResult Clear()
        {
            return RedirectToAction("Index");
        }

        private string ConvertBinaryToDecimal(string input)
        {
            if (IsValidBinary(input))
            {
                long binaryNum = System.Convert.ToInt64(input, 2);
                return $"{input} (binary) = {binaryNum} (decimal)";
            }
            else
            {
                ModelState.AddModelError("InputValue", "Invalid binary input. Please enter 0s and 1s only.");
                return null;
            }
        }

        private string ConvertDecimalToBinary(string input)
        {
            if (long.TryParse(input, out long decimalNum))
            {
                string binaryResult = System.Convert.ToString(decimalNum, 2);
                return $"{input} (decimal) = {binaryResult} (binary)";
            }
            else
            {
                ModelState.AddModelError("InputValue", "Invalid decimal input. Please enter a valid integer.");
                return null;
            }
        }

        private bool IsValidBinary(string input)
        {
            return !string.IsNullOrEmpty(input) && input.All(c => c == '0' || c == '1');
        }
    }
}
