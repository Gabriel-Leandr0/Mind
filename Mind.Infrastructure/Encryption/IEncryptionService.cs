using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mind.Infrastructure.Encryption
{
    public interface IEncryptionService
    {
        public byte[] GenerateHashedPassword(string password);
        public bool VerifyPassword(byte[] password, byte[] passwordToCompare);
        
    }
}