using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UchPpp.Models
{

    public class Project
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Contractor Name")]
        [Required]
       
        public string ContractorName { get; set; }
        [DisplayName("Contractor Address")]

        [Required]
        public string ContractorAddress { get; set; }
        [DisplayName("Phone Number")]

        [Required]
        public string PhoneNo { get; set; }
        [DisplayName("Email Address")]
        [EmailAddress(ErrorMessage = "Enter correct email")]

        [Required]
        public string EmailAddress { get; set; }
       [DisplayName("Project Name")]

        [Required]
        public string ProjectName { get; set; }
        [DisplayName("Project Location")]

        [Required]
        public string ProjectLocation { get; set; }
        [DisplayName("Expiration Date")]

        [Required]
        public DateTime ExpirationDate { get; set; }
        

    }
}
    

