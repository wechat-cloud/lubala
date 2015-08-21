using System;
using System.Xml.Linq;
using Lubala.Dispatchers.Contexts;
using Lubala.Dispatchers.Core;

namespace Lubala.Dispatchers.Transforms
{
    internal class XmlDocumentParsingDecision  : TransformDecision<KernelContext, XmlMessageContext>
    {
        public XmlDocumentParsingDecision(IDecision nextDecision) : base(nextDecision) { }
        
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
