using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lubala
{
    public interface IWechatMiddleware
    {
        Task OnExecuting(object state);
        Task OnReleasing(object state);

        IWechatMiddleware Next();
    }
}
