using Lubala.Core.Pushing;

namespace Lubala.Component.MP.Messages
{
    class IncomingVoiceMessage : InteractableMessage, IDuplicateCheckable
    {
        public double MsgId { get; }
    }
}
