using System;
using System.Collections.Generic;

namespace Lubala.Core.Pushing.Services
{
    internal class TypePicker
    {
        private IReadOnlyDictionary<TypeIdentity, Type> _messageTypes;

        public TypePicker(IReadOnlyDictionary<TypeIdentity, Type> messageTypes)
        {
            _messageTypes = messageTypes;
        }

        public Type Picking(TypeIdentity typeIdentity)
        {
            if (_messageTypes.ContainsKey(typeIdentity))
            {
                return _messageTypes[typeIdentity];
            }

            return null;
        }
    }
}
