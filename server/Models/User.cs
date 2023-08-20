using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace JobHuntApi.Models
{
    public class User : IdentityUser
    {
        [Required]
        public required String FirstName { get; set; }
        [Required]
        public required String LastName { get; set; }
        [Required]
        public required String Gender { get; set; }
        public string? RefreshToken { get; set; }
        
    }
}