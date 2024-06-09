using rrhh_api.Dto;

namespace rrhh_api.Services
{
    public interface IAuthService
    {
        Task<AuthResponse> AuthResponse(LoginDto login);
        Task<AuthResponse> RefreshTokenResponse(TokenDto refreshToken, string user);
    }
}
