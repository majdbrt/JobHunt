using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobHuntApi.Models
{
    public interface ITime
    {
        DateTime CreatedAt { get; set; }
        DateTime UpdatedAt { get; set; }
        DateOnly DateSubmitted { get; set; }
    }
}