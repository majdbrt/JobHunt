using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobHuntApi.Contracts;
using JobHuntApi.Models;

namespace JobHuntApi.Repositories
{
    public class InterviewRepository : RepositoryBase<Interview>, IInterviewRepository
    {
        public InterviewRepository(JobHuntApiDbContext jobHuntApiDbContext) : base(jobHuntApiDbContext)
        {
        }
    }
}