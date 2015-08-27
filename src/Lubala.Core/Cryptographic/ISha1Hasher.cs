using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lubala.Core.Cryptographic
{
    public interface ISha1Hasher
    {
        string HashString(string source, Encoding encoding = null);
    }
}
