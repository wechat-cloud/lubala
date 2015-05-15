using System;

namespace Lubala.Dispatchers.Core
{
    internal abstract class ProducingDecision<TContext, TResult> : DecisionBase<TContext, TResult>
    {
        public override TResult Deciding(TContext context)
        {
            var result = Produce(context);
            return result;
        }

        public abstract override bool IsSatisfied(TContext context);
        protected abstract TResult Produce(TContext context);
    }
}