namespace JWT_Authentication_Authorization_Roles_RefreshToken_Demo.DTOs
{
    public class TokenResponseDTO
    {
        public required string AccessToken { get; set; }
        public required string RefreshToken { get; set; }
    }
}
