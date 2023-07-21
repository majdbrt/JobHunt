using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobHuntApi.Models
{
    public class Interview : ITime
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required String Id { get; set; }
        public String? Notes { get; set; }
        public int MyProperty { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateOnly DateSubmitted { get; set; }

        [Required]
        public required String ApplicationId { get; set; }
        public virtual Application Application { get; set; } = null!;
    }
}