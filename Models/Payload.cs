using SuperFormulaRestAPI.Models.ModelValidation;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SuperFormulaRestAPI.Models
{
    public class Payload
    {
        [Required]
        [EffectiveDateValidation(ErrorMessage = "Effective Date must be 30 days in the future from the creation date!")]
        public DateTime EffectiveDate { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string DriverLicenseNumber { get; set; }

        [Required]
        [ClassicCarValidation(ErrorMessage = "Does not meet classic car requirement!")]
        public int VehicleYear { get; set; }

        [Required]
        public string VehicleModel { get; set; }

        [Required]
        public string VehicleManufacturer { get; set; }

        [Required]
        public string VehicleName { get; set; }

        [Required]
        public string StreetAddress { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Zip { get; set; }

        [JsonIgnore]
        [AddressValidation(ErrorMessage = "Must be valid US address!")]
        public string FullAddress 
        {   get 
            {
                return $"{StreetAddress} , {City} , {State}, {Zip}";
            }
            set
            {

            }
        }
        
        [Required]
        public DateTime ExpirationDate { get; set; }
        
        [Required]
        public double Premium { get; set; }
        
        [JsonIgnore]
        public Guid PolicyNumber { get; set; }
        
        [JsonIgnore]
        public Guid MemberId { get; set; }
        
        [JsonIgnore]
        public bool PolicyExpired 
        {
            get
            {
                return ExpirationDate < DateTime.Now;
            }
        }
    }
}
