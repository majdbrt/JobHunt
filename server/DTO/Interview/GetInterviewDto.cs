using System.ComponentModel.DataAnnotations;

namespace JobHuntApi.DTO.Interview
{
    public class GetInterviewDto
    {
        public required String Id { get; set; }
        public String? Notes { get; set; }
        public int MyProperty { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateOnly DateSubmitted { get; set; }

        [Required]
        public required String ApplicationId { get; set; }
    }
}