using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lubala.Core.Serialization;

namespace Lubala.Core.Pushing
{
    public interface IPassiveMessage
    {
        string Serialize(IXmlSerializer xmlSerializer);
    }
}
