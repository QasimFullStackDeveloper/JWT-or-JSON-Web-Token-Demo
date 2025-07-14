using System.ComponentModel.DataAnnotations;

namespace JWT_Authentication_Authorization_Roles_RefreshToken_Demo.DTOs
{
    public class UserLoginDTO
    {
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }

    public class UserRegisterDTO : UserLoginDTO
    {
        public string Role { get; set; } = string.Empty;
    }
}
