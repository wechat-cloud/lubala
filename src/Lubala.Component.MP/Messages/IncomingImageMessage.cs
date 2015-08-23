using Lubala.Core.Pushing;

namespace Lubala.Component.MP.Messages
{
    public class IncomingImageMessage : InteractableMessage, IDuplicateCheckable
    {
        public double MsgId { get; }
    }
}
