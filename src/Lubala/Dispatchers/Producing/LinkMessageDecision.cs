using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lubala.Dispatchers.Contexts;
using Lubala.Dispatchers.Core;
using Lubala.Processors;

namespace Lubala.Dispatchers.Producing
{
    internal class LinkMessageDecision : ProducingDecision<XmlMessageContext, MessageProcessor>
    {
        public override bool IsSatisfied(XmlMessageContext context)
        {
            throw new NotImplementedException();
        }

        protected override MessageProcessor Produce(XmlMessageContext context)
        {
            throw new NotImplementedException();
        }
    }
}
