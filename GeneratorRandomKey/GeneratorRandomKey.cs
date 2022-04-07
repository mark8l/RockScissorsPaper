using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RockScissorsPaper
{
    internal class GeneratorRandomKey
    {
        private RandomNumberGenerator _rng;
        private byte[] _randomKey = new byte [32];

        public GeneratorRandomKey()
        {
            _rng = RandomNumberGenerator.Create();
        }
        public byte[] GetKey()
        {
            _rng.GetBytes(_randomKey);
            return _randomKey;
        }
    }
}
