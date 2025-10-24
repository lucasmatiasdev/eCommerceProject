using AutoMapper;
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
    public class ProductService(ICRUD<Product> productInterface, IMapper mapper) : IProductService
    {
        public async Task<ServiceResponse> CreateAsync(CreateProduct product)
        {
            var mappedData = mapper.Map<Product>(product);
            int result = await productInterface.CreateAsync(mappedData);
            return result > 0
                ? new ServiceResponse(true, "Product added")
                : new ServiceResponse(false, "Product failed to be added");
        }

        public async Task<ServiceResponse> DeleteAsync(Guid id)
        {
            int result = await productInterface.DeleteAsync(id);
            return result > 0
                ? new ServiceResponse(true, "Product deleted")
                : new ServiceResponse(false, "Product failed to be deleted");
        }

        public async Task<IEnumerable<GetProduct>> GetAllAsync()
        {
            var rawData = await productInterface.GetAllAsync();
            if (rawData == null) return [];
            return mapper.Map<IEnumerable<GetProduct>>(rawData);
        }

        public async Task<GetProduct> GetByIdAsync(Guid id)
        {
            var rawData = await productInterface.GetByIdAsync(id);
            if (rawData == null) return new GetProduct();
            return mapper.Map<GetProduct>(rawData);
        }

        public async Task<ServiceResponse> UpdateAsync(UpdateProduct product)
        {
            var mappedData = mapper.Map<Product>(product);
            int result = await productInterface.UpdateAsync(mappedData);
            return result > 0
                ? new ServiceResponse(true, "Product updated")
                : new ServiceResponse(false, "Product failed to be updated");
        }
    }
}
