﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lubala.Core
{
    internal class Token : ApiEntityBase
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
    }
}
