using eCommerceProject.Application.DTOs.Category;
using eCommerceProject.Application.DTOs.Responses;

namespace eCommerceProject.Application.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CreateCategory>> GetAllAsync();
        Task<GetCategory> GetByIdAsync(Guid id);
        Task<ServiceResponse> CreateAsync(CreateCategory category);
        Task<ServiceResponse> UpdateAsync(UpdateCategory category);
        Task<ServiceResponse> DeleteAsync(Guid id);
    }
}
