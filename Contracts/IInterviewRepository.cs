using JobHuntApi.DTO.Interview;
using JobHuntApi.Models;

namespace JobHuntApi.Contracts
{
    public interface IInterviewRepository : IRepositoryBase<Interview>
    {
        Task<IEnumerable<GetInterviewDto>> GetAllAsync();
        Task<GetInterviewDto?> GetByIdAsync(string id);
        Task<string> CreateAsync(CreateInterviewDto createInterviewDto);
        Task<bool> UpdateAsync(string id, UpdateInterviewDto updateInterviewDto);
    }
}