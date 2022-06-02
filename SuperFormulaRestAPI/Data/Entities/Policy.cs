using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperFormulaRestAPI.Data.Entities
{
    public class Policy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PolicyId { get; set; }
        public int VehicleYear { get; set; }
        public string VehicleModel { get; set; }
        public string VehicleManufacturer { get; set; }
        public string VehicleName { get; set; }
        public double Premium { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public Guid MemberId { get; set; }
        public Member Member { get; set; }
    }
}
