using eCommerceProject.Application.DTOs.Product;
using System.ComponentModel.DataAnnotations;

namespace eCommerceProject.Application.DTOs.Category
{
    public class GetCategory : CategoryBase
    {
        public Guid Id { get; set; }
        public ICollection<GetProduct>? Products { get; set; }
    }
}
