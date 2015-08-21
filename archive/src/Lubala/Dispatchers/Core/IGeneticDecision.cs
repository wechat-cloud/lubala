using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lubala.Dispatchers.Core
{
    interface IGeneticDecision<TContext, TResult> : IDecision
    {
        TResult Deciding(TContext context);
        bool IsSatisfied(TContext context);
    }
}
