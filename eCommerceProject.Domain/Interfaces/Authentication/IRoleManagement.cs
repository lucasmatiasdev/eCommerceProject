using eCommerceProject.Domain.Entities.Identity;

namespace eCommerceProject.Domain.Interfaces.Authentication
{
    public interface IRoleManagement
    {
        Task<string?> GetUserRole(string userEmail);
        Task<bool?> AddUserToRole(AppUser user, string roleName); 
    }
}
