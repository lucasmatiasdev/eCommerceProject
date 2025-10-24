using System.ComponentModel.DataAnnotations;

namespace eCommerceProject.Application.DTOs.Category
{
    public class UpdateCategory : CategoryBase
    {
        [Required]
        public Guid Id { get; set; }
    }
}
