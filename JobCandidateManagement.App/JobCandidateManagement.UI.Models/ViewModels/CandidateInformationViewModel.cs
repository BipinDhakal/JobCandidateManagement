using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobCandidateManagement.UI.Models
{
    public class CandidateInformationViewModel
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }


        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters.")]
        public string FirstName { get; set; }


        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters.")]
        public string LastName { get; set; }


        [Display(Name = "Phone Number")]
        [MaxLength(50, ErrorMessage = "Phone number cannot exceed 50 characters.")]
        public string PhoneNumber { get; set; } = string.Empty;


        [MaxLength(250, ErrorMessage = "Call Time Interval cannot exceed 250 characters.")]
        public string CallTimeInterval { get; set; } = string.Empty;


        [MaxLength(250, ErrorMessage = "LinkedIn Profile Url cannot exceed 250 characters.")]
        public string LinkedInProfileUrl { get; set; } = string.Empty;


        [MaxLength(250, ErrorMessage = "GitHub Profile Url cannot exceed 250 characters.")]
        public string GitHubProfileUrl { get; set; } = string.Empty;


        [Display(Name = "Comment")]
        [Required(ErrorMessage = "Comment is required.")]
        public string Comments { get; set; }
    }
}
