using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobHuntApi.DTO.User
{
    public class GetUserDto
    {
        public required string  Id { get; set; }
        [Required]
        public required string FirstName { get; set; }
        [Required]
        public required string LastName { get; set; }
        [Required]
        public required string Gender { get; set; }
        [Required]
        public required string Email { get; set; }
        public string? AccessToken { get; set; }
    }
}