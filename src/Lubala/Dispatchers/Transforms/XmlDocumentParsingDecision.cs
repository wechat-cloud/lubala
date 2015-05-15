using System;
using System.Xml.Linq;
using Lubala.Dispatchers.Contexts;
using Lubala.Dispatchers.Core;

namespace Lubala.Dispatchers.Transforms
{
    internal class XmlDocumentParsingDecision  : TransformDecision<KernelContext, XmlMessageContext>
    {
        public XmlDocumentParsingDecision(IDecision nextDecision) : base(nextDecision) { }

        protected override XmlMessageContext Transform(KernelContext context)
        {
            var bodyStream = context.BodyStream;
            using (bodyStream)
            {
                var document = XDocument.Load(bodyStream);
                return new XmlMessageContext(context, document);
            }
        }

        public override bool IsSatisfied(object context)
        {
            throw new NotImplementedException();
        }
    }
}
