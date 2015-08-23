using Lubala.Core.Pushing;

namespace Lubala.Component.MP.Messages
{
    class IncomingVideoMessage : InteractableMessage, IDuplicateCheckable
    {
        public double MsgId { get; }
    }
}
