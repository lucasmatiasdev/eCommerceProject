using eCommerceProject.Application.DTOs.Category;

namespace eCommerceProject.Application.DTOs.Product
{
    public class GetProduct : ProductBase
    {
        public Guid Id { get; set; }
        public GetCategory? Category { get; set; }
    }
}
