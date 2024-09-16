using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Authentication_project_dashboard.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "First Name")]
        [MaxLength(128)]
        public string FirstName { get; set; } = string.Empty;

        [Display(Name = "Last Name")]
        [MaxLength(128)]
        public string LastName { get; set; } = string.Empty;

        [Display(Name = "Profile Picture")]
        public byte[]? ProfilePicture { get; set; }

        public bool Gender { get; set; }

        public virtual List<Book>? books { get; set; }
    }
}
