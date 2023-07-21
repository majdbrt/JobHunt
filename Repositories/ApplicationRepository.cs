using System.Net.Mime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobHuntApi.Contracts;
using JobHuntApi.Models;
using AutoMapper;
using JobHuntApi.DTO.Application;
using Microsoft.EntityFrameworkCore;

namespace JobHuntApi.Repositories
{
    public class ApplicationRepository : RepositoryBase<Application>, IApplicationRepository
    {
        private readonly JobHuntApiDbContext _jobHuntApiDbContext;
        private readonly IMapper _mapper;
        public ApplicationRepository(JobHuntApiDbContext jobHuntApiDbContext, IMapper mapper) : base(jobHuntApiDbContext)
        {
            this._mapper = mapper;
            this._jobHuntApiDbContext = jobHuntApiDbContext;
        }

        public async Task<String> CreateAsync(CreateApplicationDto createApplicationDto)
        {
            var application = _mapper.Map<Application>(createApplicationDto);
            await _jobHuntApiDbContext.AddAsync(application);
            await SaveAsync();
            return application.Id;

        }

        public async Task<IEnumerable<GetApplicationDto>> GetAllAsync()
        {
            var applications = await _jobHuntApiDbContext.Set<Application>().ToListAsync();
            return _mapper.Map<IEnumerable<GetApplicationDto>>(applications);

        }

        public async Task<GetApplicationDto?> GetByIdAsync(string id)
        {
            var application = await _jobHuntApiDbContext.Set<Application>().FindAsync(id);
            return _mapper.Map<GetApplicationDto>(application);
        }

        public async Task<bool> UpdateAsync(string id, UpdateApplicationDto updateApplicationDto)
        {
            var application = await _jobHuntApiDbContext.Set<Application>().FindAsync(id);
            if (application == null)
                return false;
            _mapper.Map(updateApplicationDto, application);
            _jobHuntApiDbContext.Update(application);
            await SaveAsync();
            return true;
        }
    }
}