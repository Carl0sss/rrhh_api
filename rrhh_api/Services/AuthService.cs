using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using rrhh_api.Models;
using rrhh_api.Dto;
using System.Security.Cryptography;
using BCrypt.Net;

namespace rrhh_api.Services
{
    public class AuthService : IAuthService
    {
        private readonly RrhhAdminContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(RrhhAdminContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        private string GenerateToken(string idUser)
        {
            var key = _configuration.GetValue<string>("JWTSetting:securitykey");
            var keyBytes = Encoding.ASCII.GetBytes(key);

            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, idUser));

            var credentialsToken = new SigningCredentials(
                new SymmetricSecurityKey(keyBytes),
                SecurityAlgorithms.HmacSha256Signature
                );

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = credentialsToken

            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenConfiguration = tokenHandler.CreateToken(tokenDescriptor);

            string token = tokenHandler.WriteToken(tokenConfiguration);

            return token;

        }

        public async Task<AuthResponse> AuthResponse(LoginDto login)
        {
            var userFound = _context.Usuarios.FirstOrDefault(x =>
                x.CodUsuario == login.User //&&
                //x.Password == login.Password
            );

            if (userFound == null || !BCrypt.Net.BCrypt.Verify(login.Password, userFound.Password))
            {
                return await Task.FromResult<AuthResponse>(null);
            }


            string token = GenerateToken(userFound.CodUsuario.ToString());
            string refreshToken = GenerateRefreshToken();

            return await SaveTokens(userFound.CodUsuario, token, refreshToken);

        }


        private string GenerateRefreshToken()
        {

            var byteArray = new byte[64];
            var refreshToken = "";

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(byteArray);
                refreshToken = Convert.ToBase64String(byteArray);
            }
            return refreshToken;
        }

        private async Task<AuthResponse> SaveTokens(string idUsuario, string token, string refreshToken)
        {

            var rfToken = new RefreshToken
            {
                CodUsuario = idUsuario,
                TokenId = token,
                RefreshToken1 = refreshToken
            };


            await _context.RefreshTokens.AddAsync(rfToken);
            await _context.SaveChangesAsync();

            return new AuthResponse { token = token, refreshToken = refreshToken, result = true, message = "Ok" };

        }

        public async Task<AuthResponse> RefreshTokenResponse(TokenDto refreshToken, string user)
        {
            var refreshTokenEncontrado = _context.RefreshTokens.FirstOrDefault(x =>
                x.TokenId == refreshToken.Token &&
                x.RefreshToken1 == refreshToken.RefreshToken &&
                x.CodUsuario == refreshToken.User);

            if (refreshTokenEncontrado == null)
                return new AuthResponse { result = false, message = "No existe refresh Token" };

            var refreshTokenCreado = GenerateRefreshToken();
            var tokenCreado = GenerateToken(user);

            return await SaveTokens(user, tokenCreado, refreshTokenCreado);
        }

        public async Task<AuthResponse> RegisterUser(RegisterDto register)
        {
            var existingUser = _context.Usuarios.FirstOrDefault(x => x.CodUsuario == register.User);

            if (existingUser != null)
            {
                return new AuthResponse { result = false, message = "Usuario ya registrado" };
            }

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(register.Password);

            var newUser = new Usuario
            {
                CodUsuario = register.User,
                Password = hashedPassword,
                FechaCreacion = DateTime.Now,
            };

            await _context.Usuarios.AddAsync(newUser);
            await _context.SaveChangesAsync();

            string token = GenerateToken(newUser.CodUsuario.ToString());
            string refreshToken = GenerateRefreshToken();

            return await SaveTokens(newUser.CodUsuario, token, refreshToken);
        }
    }
}
