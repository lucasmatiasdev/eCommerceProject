using AutoMapper;
using eCommerceProject.Application.DTOs.Category;
using eCommerceProject.Application.DTOs.Responses;
using eCommerceProject.Application.Services.Interfaces;
using eCommerceProject.Domain.Entities;
using eCommerceProject.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceProject.Application.Services.Implementations
{
    public class CategoryService(ICRUD<Category> categoryInterface, IMapper mapper) : ICategoryService
    {
        public async Task<ServiceResponse> CreateAsync(CreateCategory category)
        {
            var mappedData = mapper.Map<Category>(category);
            int result = await categoryInterface.CreateAsync(mappedData);
            return result > 0
                ? new ServiceResponse(true, "Category added")
                : new ServiceResponse(false, "Category failed to be add");
        }

        public async Task<ServiceResponse> DeleteAsync(Guid id)
        {
            var result = await categoryInterface.DeleteAsync(id);
            return result > 0
                ? new ServiceResponse(true, "Category deleted")
                : new ServiceResponse(false, "Category failed to be deleted");
        }

        public async Task<IEnumerable<GetCategory>> GetAllAsync()
        {
            var rawData = await categoryInterface.GetAllAsync();
            if (rawData == null) return [];
            return mapper.Map<IEnumerable<GetCategory>>(rawData);
        }

        public async Task<GetCategory> GetByIdAsync(Guid id)
        {
            var rawData = await categoryInterface.GetByIdAsync(id);
            if (rawData == null) return new GetCategory();
            return mapper.Map<GetCategory>(rawData);
        }

        public async Task<ServiceResponse> UpdateAsync(UpdateCategory category)
        {
            var result = await categoryInterface.UpdateAsync(mapper.Map<Category>(category));
            return result > 0
                ? new ServiceResponse(true, "Category updated")
                : new ServiceResponse(false, "Category failed to be updated");
        }
    }
}
