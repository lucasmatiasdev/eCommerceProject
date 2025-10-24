using eCommerceProject.Application.DTOs.Category;
using System.ComponentModel.DataAnnotations;

namespace eCommerceProject.Application.DTOs.Product
{
    public class GetProduct : ProductBase
    {
        [Required]
        public Guid Id { get; set; }
        public GetCategory? Category { get; set; }
    }
}
