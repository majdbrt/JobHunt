using System.ComponentModel.DataAnnotations;

namespace JobHuntApi.DTO.Application
{
    public class CreateApplicationDto
    {
        [Required]
        public required string Company { get; set; }
        [Required]
        public required string JobTitle { get; set; }
        public string? JobDescription { get; set; }
        public string? Compensation { get; set; }
        public string? ReferralName { get; set; }
        public DateOnly DateSubmitted { get; set; }
        public string? Notes { get; set; }
        public string? Status { get; set; }
    }
}