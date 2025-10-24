using System.ComponentModel.DataAnnotations;

namespace eCommerceProject.Application.DTOs.Product
{
    public class UpdateProduct : ProductBase
    {
        [Required]
        public Guid Id { get; set; }       
    }
}
