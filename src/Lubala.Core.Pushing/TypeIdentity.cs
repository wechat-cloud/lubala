namespace Lubala.Core.Pushing
{
    public class TypeIdentity
    {
        private const string NULLTYPE = "$$NULL$$";
        public string MsgType { get; set; }
        public string EventType { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is TypeIdentity))
            {
                return false;
            }

            var target = (TypeIdentity) obj;

            return MsgType == target.MsgType && EventType == target.EventType;
        }

        public override int GetHashCode()
        {
            var seg1 = MsgType ?? NULLTYPE;
            var seg2 = EventType ?? NULLTYPE;
            return $"{seg1}-{seg2}".GetHashCode();
        }

        public override string ToString()
        {
            return $"MsgType: {MsgType}, EventType: {EventType}";
        }
    }
}