using JWT_Authentication_Authorization_Roles_RefreshToken_Demo.DTOs;
using JWT_Authentication_Authorization_Roles_RefreshToken_Demo.Entities;

namespace JWT_Authentication_Authorization_Roles_RefreshToken_Demo.Services
{
    public interface IAuthService
    {
        Task<User?> RegisterAsync(UserRegisterDTO request);
        Task<TokenResponseDTO?> LoginAsync(UserLoginDTO request);
        Task<TokenResponseDTO?> RefreshTokensAsync(RefreshTokenRequestDTO request);
    }
}
