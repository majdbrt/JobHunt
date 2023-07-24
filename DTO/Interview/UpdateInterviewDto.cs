namespace JobHuntApi.DTO.Interview
{
    public class UpdateInterviewDto 
    {
        public String? Notes { get; set; }
        public DateOnly DateSubmitted { get; set; }
    }
}