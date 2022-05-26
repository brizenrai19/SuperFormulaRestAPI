using System.ComponentModel.DataAnnotations;

namespace SuperFormulaRestAPI.Models
{
    public class Policy
    {
        public string PolicyId { get; set; }
        [Required]
        public int VehicleYear { get; set; }
        [Required]
        public string VehicleModel { get; set; }
        [Required]
        public string VehicleManufacturer { get; set; }
        [Required]
        public string VehicleName { get; set; }
        public string MemberId { get; set; }
    }
}
