using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Lubala.Core.Cryptographic;
using Lubala.Core.Pushing.Crypography;
using Lubala.Core.Pushing.Services;
using Lubala.Core.Resolvers;

namespace Lubala.Core.Pushing
{
    internal class PushingHub : IPushingHub
    {
        private readonly HubContext _hubContext;

        static PushingHub()
        {
            TypeResolver.Resolver.Register<ISourceStreamReader, DefaultSourceStreamReader>();
            TypeResolver.Resolver.Register<IPushingEngine, PushingEngine>();
            TypeResolver.Resolver.Register<ITypeDetector, TypeDetector>();
            TypeResolver.Resolver.Register<IEncodingProvider, AesEncodingProvider>();
            TypeResolver.Resolver.Register<IAesCrypography, AesCrypography>();
        }

        internal PushingHub(HubContext hubContext)
        {
            if (hubContext == null)
            {
                throw new ArgumentNullException(nameof(hubContext));
            }

            _hubContext = hubContext;

            MessageTypes = _hubContext.GetMessageTypes();
            MessageHandlers = _hubContext.GetMessageHandlers();
            Resolver = _hubContext.Resolver;
            Channel = _hubContext.Channel;
        }

        internal IReadOnlyDictionary<TypeIdentity, Type> MessageTypes { get; }
        internal ITypeResolver Resolver { get; }

        public ILubalaChannel Channel { get; }
        public EncodingMode EncodingMode { get; set; } = EncodingMode.Plain;
        public IReadOnlyDictionary<Type, IMessageHandler> MessageHandlers { get; }

        public bool Verify(string timestamp, string nonce, string signature, string verifyToken)
        {
            var tokenValue = verifyToken;
            var tempArray = new SortedSet<string> {timestamp, nonce, tokenValue};
            var toHash = string.Join("", tempArray);

            var hasher = Resolver.Resolve<ISha1Hasher>();
            var result = hasher.HashString(toHash, Encoding.ASCII);

            return result == signature;
        }

        public async Task InterpretingAsync(Stream sourceStream, Stream targetStream,
            IDictionary<string, string> payloads)
        {
            var engine = Resolver.Resolve<IPushingEngine>();
            var result = await engine.ProducePassiveMessage(sourceStream, _hubContext, payloads);

            await result.SerializeTo(targetStream, _hubContext);
        }
    }
}