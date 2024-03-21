
using System.Security.Claims;
using Mind.Domain.ViewModels;

namespace Mind.Infrastructure.Token
{
    public interface ITokenService<in T>
    {
        public GeneratedTokenViewModel GenerateToken(T user);
        public string GenerateTokenFromByteArray(byte[] content, int minutes);
        public bool VerifyStringToken(string tokenContent, byte[] metadataContent);
        public string GenerateRefreshToken();
        public IEnumerable<Claim> GetClaimsFromToken(string token);
        public string GetEmailToken();
        public int GetIdUsuarioToken();
    }
}