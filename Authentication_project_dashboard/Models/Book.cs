using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;

namespace Authentication_project_dashboard.Models
{
    public class Book
    {
        [Required]
        public int Id { get; set; }
		[Required]
		public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public string Type { get; set; } = string.Empty;
        [Required]
        [ForeignKey("User Id")]
        public string? UserId { get; set; }
        public ApplicationUser? user { get; set; }
    }
}
