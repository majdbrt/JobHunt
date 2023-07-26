using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobHuntApi.DTO.User
{
    public class RegisterUserDto
    {
        [Required]
        public required String FirstName { get; set; }
        [Required]
        public required String LastName { get; set; }
        [Required]
        public required String Gender { get; set; }
        [Required]
        public required String Email { get; set; }
        [Required]
        public required String Password { get; set; }
    }
}