using JobHuntApi.DTO.Application;
using JobHuntApi.Models;

namespace JobHuntApi.Contracts
{
    public interface IApplicationRepository : IRepositoryBase<Application>
    {
        Task<IEnumerable<GetApplicationDto>> GetAllAsync();
        Task<GetApplicationDto?> GetByIdAsync(string id);
        Task<string> CreateAsync(CreateApplicationDto createApplicationDto);
        Task<bool> UpdateAsync(string id, UpdateApplicationDto updateApplicationDto);
    }
}