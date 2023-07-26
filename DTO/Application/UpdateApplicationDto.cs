namespace JobHuntApi.DTO.Application
{
    public class UpdateApplicationDto
    {
        public string? Company { get; set; }
        public string? JobTitle { get; set; }
        public string? JobDescription { get; set; }
        public string? Compensation { get; set; }
        public string? ReferralName { get; set; }
        public DateOnly DateSubmitted { get; set; }
        public string? Notes { get; set; }
        public string? Status { get; set; }
    }
}