using AutoMapper;
using eCommerceProject.Application.DTOs.Category;
using eCommerceProject.Application.DTOs.Product;
using eCommerceProject.Domain.Entities;
namespace eCommerceProject.Application.Mapping
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<CreateCategory, Category>();
            CreateMap<CreateProduct, Product>();

            CreateMap<Category, GetCategory>();
            CreateMap<Product, GetProduct>();
        }
    }
}
