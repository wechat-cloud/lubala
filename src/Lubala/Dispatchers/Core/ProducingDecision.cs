using System;

namespace Lubala.Dispatchers.Core
{
    public abstract class ProducingDecision<TInContext, TResult> : IDecision
    {
        public object Decide(object context)
        {
            var convertedContext = (TInContext) context;
            if (IsSatisfied(convertedContext))
            {
                var result = Produce(convertedContext);
                return result;
            }

            throw new InvalidOperationException("decision tree cannot handle.");
        }

        public abstract bool IsSatisfied(object context);
        protected abstract TResult Produce(TInContext context);
    }
}
