using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lubala.Dispatchers.Contexts;
using Lubala.Dispatchers.Core;

namespace Lubala.Dispatchers.Transforms
{
    internal class JsonParsingDecision : TransformDecision<KernelContext, XmlMessageContext>
    {
        public JsonParsingDecision(IDecision nextDecision) : base(nextDecision) { }
        
        public override bool IsSatisfied(KernelContext context)
        {
            throw new NotImplementedException();
        }

        protected override XmlMessageContext Transform(KernelContext context)
        {
            throw new NotImplementedException();
        }
    }
}
