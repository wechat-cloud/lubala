using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lubala.Core.Pushing
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
