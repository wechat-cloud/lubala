using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lubala.Core
{
    public class Token
    {
        public string AccessToken { get; internal set; }
        public int ExpiresIn { get; internal set; }
    }
}
