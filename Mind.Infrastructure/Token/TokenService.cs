
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Mind.Domain.ViewModels;
using Microsoft.Extensions.Configuration;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;


namespace Mind.Infrastructure.Token
{
    public class TokenService : ITokenService<UserViewModel>
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TokenService(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public GeneratedTokenViewModel GenerateToken(UserViewModel user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("Auth:JwtHashKey"));
            var dtValidade = DateTime.UtcNow.AddHours(2);

            // Na criação do token o `SecurityTokenDescriptor` serve como objeto de configuração para a criação do Token.
            // O Subject são as claims/afirmações que a aplicação faz sobre si, utilizando-se do sistema de `Claims-Based Security`
            // Expires é o tempo de expiração e SigningCredentials é a config do tipo de criptografia utilizada.
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(user.Claims),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            });

            return new GeneratedTokenViewModel
            {
                Token = tokenHandler.WriteToken(token),
                DtValidade = dtValidade
            };
        }


        // Diferente do `GenerateToken()`, esse metodo é usado para gerar o token exclusivamente para a recuperação de senha
        // baseado no payload recebido por parametro e usando uma chave de encryptação diferente do token da sessão.
        public string GenerateTokenFromByteArray(byte[] content, int minutes)
        {
            byte[] encodedContent =
                Encoding.ASCII.GetBytes(_configuration.GetValue<string>("Auth:EncryptionKey") + content);
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddMinutes(minutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(encodedContent),
                    SecurityAlgorithms.HmacSha256Signature)
            });

            return tokenHandler.WriteToken(token);
        }

        // Valida se o token é valido ou ainda é valido, passando por paramtero o token que
        // vai ser analisado e o conteudo que foi passado no processo de assinatura do token.
        // aparetemente ele faz uma comparação direta de igualdade, sendo necessario repassar todos os dados
        // que foram assinados junto ao processo de geração do JWT.
        // O metodo `ValidateToken()` vai gerar uma excessão caso o conteudo do token seja invalido. 
        public bool VerifyStringToken(string tokenContent, byte[] metadataContent)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                byte[] encodedContent =
                    Encoding.ASCII.GetBytes(_configuration.GetValue<string>("Auth:EncryptionKey") + metadataContent);
                tokenHandler.ValidateToken(tokenContent, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    RequireExpirationTime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(encodedContent),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out _);

                return true;
            }
            catch
            {
                return false;
            }
        }


        // Generate random bytes as Refresh Token string
        public string GenerateRefreshToken()
        {
            byte[] size = new byte[64];
            new Random().NextBytes(size);
            return Convert.ToBase64String(size);
        }

        public IEnumerable<Claim> GetClaimsFromToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            return jwtSecurityToken.Claims;
        }

        public string GetEmailToken()
        {
            return _httpContextAccessor.HttpContext.User.FindFirst(x => x.Type == ClaimTypes.Email)?.Value.ToString();
        }
        public int GetIdUsuarioToken()
        {
            return Convert.ToInt32(_httpContextAccessor.HttpContext.User.FindFirst(x => x.Type == "Id")?.Value);
        
        }


    }
}