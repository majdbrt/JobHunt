using JobHuntApi.DTO.Interview;
using JobHuntApi.Models;

namespace JobHuntApi.Contracts
{
    public interface IInterviewRepository : IRepositoryBase<Interview>
    {
        Task<IEnumerable<GetInterviewDto>> GetAllAsync();
        Task<GetInterviewDto?> GetByIdAsync(String id);
        Task<String> CreateAsync(CreateInterviewDto createInterviewDto);
        Task<bool> UpdateAsync(String id, UpdateInterviewDto updateInterviewDto);
    }
}