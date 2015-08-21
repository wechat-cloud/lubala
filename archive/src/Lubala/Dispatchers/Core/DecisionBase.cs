using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lubala.Dispatchers.Core
{
    internal abstract class DecisionBase<TContext, TResult> : IGeneticDecision<TContext, TResult>
    {
        public object Deciding(object context)
        {
            return Deciding((TContext)context);
        }

        public bool IsSatisfied(object context)
        {
            return IsSatisfied((TContext)context);
        }
        
        public abstract TResult Deciding(TContext context);
        public abstract bool IsSatisfied(TContext context);
    }
}
