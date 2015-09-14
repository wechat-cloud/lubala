using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lubala.Core.Pushing.Messages
{
    public interface IDuplicateCheckable
    {
        long MsgId { get; }
    }
}
