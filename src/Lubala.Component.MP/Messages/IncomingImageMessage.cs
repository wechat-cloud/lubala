using Lubala.Core.Pushing;

namespace Lubala.Component.MP.Messages
{
    class IncomingImageMessage : InteractableMessage, IDuplicateCheckable
    {
        public double MsgId { get; }
    }
}
