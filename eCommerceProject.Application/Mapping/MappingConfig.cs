using AutoMapper;
using eCommerceProject.Application.DTOs.Cart;
using eCommerceProject.Application.DTOs.Category;
using eCommerceProject.Application.DTOs.Identity;
using eCommerceProject.Application.DTOs.Product;
using eCommerceProject.Domain.Entities;
using eCommerceProject.Domain.Entities.Cart;
using eCommerceProject.Domain.Entities.Identity;
namespace eCommerceProject.Application.Mapping
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<CreateCategory, Category>();
            CreateMap<CreateProduct, Product>();
            CreateMap<UpdateCategory, Category>();
            CreateMap<UpdateProduct, Product>();
            CreateMap<Category, GetCategory>();
            CreateMap<Product, GetProduct>();
            CreateMap<CreateUser, AppUser>();
            CreateMap<LoginUser, AppUser>();
            CreateMap<PaymentMethod, GetPaymentMethod>();
            CreateMap<GetPaymentMethod, PaymentMethod>();
        }
    }
}
