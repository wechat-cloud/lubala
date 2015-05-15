using System;
using System.Collections.Generic;
using System.Linq;

namespace Lubala.Dispatchers.Core
{
    public sealed class SequenceDecision : IDecision
    {
        private IDecision[] _decisions;
        public SequenceDecision(params IDecision[] decisions)
        {
            _decisions = decisions;
        }

        public SequenceDecision(IList<IDecision> decisions) : this(decisions.ToArray()) { }

        public object Decide(object context)
        {
            for (int i = 0; i < _decisions.Length; i++)
            {
                var decision = _decisions[i];
                if (decision.IsSatisfied(context))
                {
                    return decision.Decide(context);
                }
            }

            throw new InvalidOperationException("decision tree cannot handle.");
        }

        public bool IsSatisfied(object context)
        {
            return _decisions.Any(d => d.IsSatisfied(context));
        }
    }
}
