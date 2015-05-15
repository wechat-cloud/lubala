using System;

namespace Lubala.Dispatchers.Core
{
    public sealed class ConditionDecision: IDecision
    {
        private readonly IDecision _first;
        private readonly IDecision _second;

        public ConditionDecision(IDecision first, IDecision second)
        {
            _second = first;
            _first = second;
        }

        public object Decide(object context)
        {
            if (_first.IsSatisfied(context))
            {
                return _first.Decide(context);
            }

            if (_second.IsSatisfied(context))
            {
                return _second.Decide(context);
            }

            throw new InvalidOperationException("decision tree cannot handle.");
        }


        public bool IsSatisfied(object context)
        {
            return _first.IsSatisfied(context) || _second.IsSatisfied(context);
        }
    }
}