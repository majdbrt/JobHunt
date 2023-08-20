using System.ComponentModel.DataAnnotations;

namespace JobHuntApi.DTO.Application
{
    public class GetApplicationDto 
    {
        public required string Id { get; set; }
        [Required]
        public required string Company { get; set; }
        [Required]
        public required string JobTitle { get; set; }
        public string? JobDescription { get; set; }
        public string? Compensation { get; set; }
        public string? ReferralName { get; set; }
        public DateTime CreatedAt { get; set ; }
        public DateTime UpdatedAt { get ; set; }

        public DateOnly DateSubmitted { get; set; }
        public string? Notes { get; set; }
        public string? Status { get; set; }
    }
}