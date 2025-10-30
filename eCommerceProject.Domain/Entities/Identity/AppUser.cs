using Microsoft.AspNetCore.Identity;

namespace eCommerceProject.Domain.Entities.Identity
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
    }
}
