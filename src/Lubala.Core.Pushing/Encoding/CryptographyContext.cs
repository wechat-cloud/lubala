﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lubala.Core.Pushing.Encoding
{
    public class CryptographyContext
    {
        public string Token { get; internal set; }
        public string AppId { get; internal set; }
        public string EncodingAesKey { get; internal set; }
        public string MsgSignature { get; internal set; }
        public string MsgTimestamp { get; internal set; }
        public string MsgNonce { get; internal set; }

		internal HubContext HubContext{ get; set; }
    }
}
