using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobHuntApi.Models
{
    public class Application : ITime
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required String Id { get; set; }
        [Required]
        public required String Company { get; set; }
        [Required]
        public required String JobTitle { get; set; }
        [Required]
        public required String JobDescription { get; set; }
        public String? Compensation { get; set; }
        public String? ReferralName { get; set; }
        public DateTime CreatedAt { get; set ; }
        public DateTime UpdatedAt { get ; set; }

        public DateOnly DateSubmitted { get; set; }
        public String? Notes { get; set; }
        public String? Status { get; set; }

        public virtual ICollection<Interview> Interviews { get; set; } = null!;
        

        // resume
        // coverletter
    }
}