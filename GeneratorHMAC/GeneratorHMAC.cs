using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RockScissorsPaper
{
    internal class GeneratorHMAC
    {
        private String _hmac;
        private byte[] _randomKey;
        private byte[] _b;
        public GeneratorHMAC(byte[] randomKey)
        {
            this._randomKey = randomKey;
        }

        public String GetHMAC(String move)
        {
            HMACSHA256 _hmacKey = new HMACSHA256(_randomKey);// Initializes a new instance of the HMACSHA256 class with our randomKey.
            _b = _hmacKey.ComputeHash(Encoding.UTF8.GetBytes(move));//Computes the hash value for the computer move.
            _hmac = string.Empty;
            _b.ToList().ForEach(b => _hmac += b.ToString("X2"));
            return _hmac;
        }

    }
}
