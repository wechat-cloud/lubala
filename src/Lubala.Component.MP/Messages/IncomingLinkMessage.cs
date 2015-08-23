using Lubala.Core.Pushing;

namespace Lubala.Component.MP.Messages
{
    class IncomingLinkMessage : InteractableMessage, IDuplicateCheckable
    {
        public double MsgId { get; }
    }
}
