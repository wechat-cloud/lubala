using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lubala.Dispatchers.Contexts;
using Lubala.Dispatchers.Core;

namespace Lubala.Dispatchers.Transforms
{
    internal class MessageTypeParsingDecision : TransformDecision<XmlMessageContext, MessageTypeContext>
    {
        public MessageTypeParsingDecision(IDecision nextDecision) : base(nextDecision) { }
        
        public override bool IsSatisfied(XmlMessageContext context)
        {
            throw new NotImplementedException();
        }

        protected override MessageTypeContext Transform(XmlMessageContext context)
        {
            throw new NotImplementedException();
        }
    }
}
