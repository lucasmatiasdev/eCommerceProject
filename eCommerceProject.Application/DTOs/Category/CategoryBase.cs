using System.ComponentModel.DataAnnotations;

namespace eCommerceProject.Application.DTOs.Category
{
    public class CategoryBase
    {
        [Required]
        public string? Name { get; set; }
    }
}
