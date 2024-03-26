using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mind.Infrastructure.Encryption
{
    public class EncryptionService : IEncryptionService
    {
        private const int WorkFactor = 13;
        private readonly Encoding _encoder = Encoding.ASCII;

        public byte[] GenerateHashedPassword(string password)
        {
            return _encoder.GetBytes(BCrypt.Net.BCrypt.HashPassword(password, WorkFactor));
        }

        public bool VerifyPassword(byte[] password, byte[] passwordToCompare)
        {
            return BCrypt.Net.BCrypt.Verify(_encoder.GetString(password), _encoder.GetString(passwordToCompare));

        }
    }
}