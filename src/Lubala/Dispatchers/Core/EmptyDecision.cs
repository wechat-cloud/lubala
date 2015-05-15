using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lubala.Dispatchers.Core
{
    internal class EmptyDecision : IDecision
    {
        public object Decide(object context)
        {
            throw new InvalidOperationException("decision tree cannot handle.");
        }

        public bool IsSatisfied(object context)
        {
            return false;
        }
    }
}
