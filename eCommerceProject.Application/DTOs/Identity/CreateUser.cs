namespace eCommerceProject.Application.DTOs.Identity
{
    public class CreateUser : UserBase
    {
        public required string FullName { get; set; }
        public required string ConfirmPassword { get; set; }
    }
}
