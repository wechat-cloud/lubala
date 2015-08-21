using System;
using System.Collections.Generic;
using Lubala.Dispatchers.Core;
using Lubala.Dispatchers.Producing;
using Lubala.Dispatchers.Transforms;
using Lubala.Messages;
using Lubala.Processors;

namespace Lubala.Dispatchers
{
    internal class DefaultDispatcher : IDispatcher
    {
        private IDecision _dicisionTree;
        public DefaultDispatcher()
        {
            _dicisionTree = BuildDefaultDecisionTree();
        }

        public IMessageProcessor Dispatching(KernelContext wechatContext)
        {
            var decisionResult = _dicisionTree.Deciding(wechatContext);
            return (IMessageProcessor) decisionResult;
        }

        private IDecision BuildDefaultDecisionTree()
        {
            var emptyDecision = new EmptyDecision();
            var decisions = new List<IDecision>
            {
                new TextMessageDecision(),
                new ImageMessageDecision(),
                new VoiceMessageDecision(),
                new VideoMessageDecision(),
                new ShortVideoMessageDecision(),
                new LocationMessageDecision(),
                new LinkMessageDecision(),
                new EventMessageDecision()
            };
            var sequence = new SequenceDecision(decisions);

            var xmlDocumentParsingDecision = new XmlDocumentParsingDecision(sequence);
            var jsonParsingDecision = new JsonParsingDecision(emptyDecision);

            var decision = new ConditionDecision(xmlDocumentParsingDecision, jsonParsingDecision);

            return decision;
        }
    }
}