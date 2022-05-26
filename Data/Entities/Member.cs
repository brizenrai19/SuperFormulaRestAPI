using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperFormulaRestAPI.Data.Entities
{
    public class Member
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]    
        public Guid MemberId { get; set; }      
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DriverLicenseNumber { get; set; }
        public List<Policy> Policies { get; set; }
        public string Address { get; set; }
    }
}
