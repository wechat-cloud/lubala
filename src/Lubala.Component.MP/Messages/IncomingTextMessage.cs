using Lubala.Core.Pushing;

namespace Lubala.Component.MP.Messages
{
    class IncomingTextMessage : InteractableMessage, IDuplicateCheckable
    {
        public double MsgId { get; }
    }
}
