using eCommerceProject.Application.DTOs.Product;
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
    public class ProductService(ICRUD<Product> productInterface) : IProductService
    {
        public async Task<ServiceResponse> CreateAsync(CreateProduct product)
        {
            int result = await productInterface.CreateAsync()
        }

        public Task<ServiceResponse> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CreateProduct>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GetProduct> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse> UpdateAsync(UpdateProduct product)
        {
            throw new NotImplementedException();
        }
    }
}
