using System.ComponentModel.DataAnnotations;

namespace SuperFormulaRestAPI.Models
{
    public class Member
    {
        public string MemberId { get; set; }
        [Required]
        public DateTime EffectiveDate 
        {
            get
            {
                return CreateDate.AddDays(30);
            }
        }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string DriverLicenseNumber { get; set; }
        public List<Policy> Policies { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public DateTime ExpirationDate 
        {
            get
            {
                return CreateDate.AddMonths(6);
            }
        }
        [Required]
        public double Premium { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
