using System.ComponentModel.DataAnnotations;

namespace JobHuntApi.DTO.Interview
{
    public class CreateInterviewDto
    {
        public String? Notes { get; set; }
        public DateOnly DateSubmitted { get; set; }
        [Required]
        public required String ApplicationId { get; set; }
    }
}