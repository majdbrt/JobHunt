using JobHuntApi.DTO.Application;
using JobHuntApi.Models;

namespace JobHuntApi.Contracts
{
    public interface IApplicationRepository : IRepositoryBase<Application>
    {
        Task<IEnumerable<GetApplicationDto>> GetAllAsync();
        Task<GetApplicationDto?> GetByIdAsync(String id);
        Task<String> CreateAsync(CreateApplicationDto createApplicationDto);
        Task<bool> UpdateAsync(String id, UpdateApplicationDto updateApplicationDto);
    }
}