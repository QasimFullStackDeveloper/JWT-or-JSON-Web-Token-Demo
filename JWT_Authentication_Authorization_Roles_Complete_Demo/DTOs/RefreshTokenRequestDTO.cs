namespace JWT_Authentication_Authorization_Roles_RefreshToken_Demo.DTOs
{
    public class RefreshTokenRequestDTO
    {
        public Guid UserId { get; set; }
        public required string RefreshToken { get; set; }
    }
}
