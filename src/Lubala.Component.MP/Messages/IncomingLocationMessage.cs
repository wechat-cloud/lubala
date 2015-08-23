using Lubala.Core.Pushing;

namespace Lubala.Component.MP.Messages
{
    class IncomingLocationMessage : InteractableMessage, IDuplicateCheckable
    {
        public double MsgId { get; }
    }
}
