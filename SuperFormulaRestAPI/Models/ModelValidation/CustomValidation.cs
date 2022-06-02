using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace SuperFormulaRestAPI.Models.ModelValidation
{
    public class EffectiveDateValidation : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            DateTime dateTime = Convert.ToDateTime(value);
            return dateTime >= DateTime.Now.AddDays(30);
        }
    }

    public class ClassicCarValidation : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            return Convert.ToInt32(value) < 1998 && Convert.ToInt32(value) > 0;
        }
    }

    public class AddressValidation : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            USAddress.AddressParser addressParser = new USAddress.AddressParser();
            return addressParser.AddressRegex.IsMatch(value.ToString());
        }
    }
}
