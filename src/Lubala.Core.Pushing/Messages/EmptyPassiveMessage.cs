﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lubala.Core.Pushing.Messages
{
    public class EmptyPassiveMessage : IPassiveMessage
    {
        public string Serialize()
        {
            return "";
        }
    }
}
