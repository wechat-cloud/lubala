using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lubala.Core.Pushing
{
    public interface ISourceStreamReader
    {
        XDocument ReadAsXml(Stream sourceStream);
    }
}
