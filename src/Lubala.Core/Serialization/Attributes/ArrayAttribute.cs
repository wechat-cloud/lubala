using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lubala.Core.Serialization.Attributes
{
    public class ArrayAttribute:Attribute
    {
        public ArrayAttribute(string arrayName)
        {
            ArrayName = arrayName;
        }

        public string ArrayName { get; private set; }
    }
}
