namespace JobHuntApi.DTO.Application
{
    public class UpdateApplicationDto
    {
        public String? Company { get; set; }
        public String? JobTitle { get; set; }
        public String? JobDescription { get; set; }
        public String? Compensation { get; set; }
        public String? ReferralName { get; set; }
        public DateOnly DateSubmitted { get; set; }
        public String? Notes { get; set; }
        public String? Status { get; set; }
    }
}