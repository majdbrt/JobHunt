using System.Net.Mime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobHuntApi.Contracts;
using JobHuntApi.Models;

namespace JobHuntApi.Repositories
{
    public class ApplicationRepository : RepositoryBase<Application>, IApplicationRepository
    {
        public ApplicationRepository(JobHuntApiDbContext jobHuntApiDbContext) : base(jobHuntApiDbContext)
        {
        }
    }
}