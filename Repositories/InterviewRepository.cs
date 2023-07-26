using AutoMapper;
using JobHuntApi.Contracts;
using JobHuntApi.DTO.Interview;
using JobHuntApi.Models;
using Microsoft.EntityFrameworkCore;

namespace JobHuntApi.Repositories
{
    public class InterviewRepository : RepositoryBase<Interview>, IInterviewRepository
    {
        private readonly JobHuntApiDbContext _jobHuntApiDbContext;
        private readonly IMapper _mapper;
        public InterviewRepository(JobHuntApiDbContext jobHuntApiDbContext, IMapper mapper) : base(jobHuntApiDbContext)
        {
            this._mapper = mapper;
            this._jobHuntApiDbContext = jobHuntApiDbContext;
        }

        public async Task<string> CreateAsync(CreateInterviewDto createInterviewDto)
        {
            var interview = _mapper.Map<Interview>(createInterviewDto);
            interview.CreatedAt = DateTime.UtcNow;
            interview.UpdatedAt = DateTime.UtcNow;
            await _jobHuntApiDbContext.AddAsync(interview);
            await SaveAsync();
            return interview.Id;

        }

        public async Task<IEnumerable<GetInterviewDto>> GetAllAsync()
        {
            var interviews = await _jobHuntApiDbContext.Set<Interview>().ToListAsync();
            return _mapper.Map<IEnumerable<GetInterviewDto>>(interviews);

        }

        public async Task<GetInterviewDto?> GetByIdAsync(string id)
        {
            var interview = await _jobHuntApiDbContext.Set<Interview>().FindAsync(id);
            return _mapper.Map<GetInterviewDto>(interview);
        }

        public async Task<bool> UpdateAsync(string id, UpdateInterviewDto updateInterviewDto)
        {
            var interview = await _jobHuntApiDbContext.Set<Interview>().FindAsync(id);
            if (interview == null)
                return false;
            _mapper.Map(updateInterviewDto, interview);
            interview.UpdatedAt = DateTime.UtcNow;
            _jobHuntApiDbContext.Update(interview);
            await SaveAsync();
            return true;
        }
    }
}