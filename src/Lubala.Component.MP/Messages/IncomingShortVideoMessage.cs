using Lubala.Core.Pushing;

namespace Lubala.Component.MP.Messages
{
    class IncomingShortVideoMessage : InteractableMessage, IDuplicateCheckable
    {
        public double MsgId { get; }
    }
}
