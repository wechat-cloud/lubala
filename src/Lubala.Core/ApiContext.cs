﻿using System.Collections.Generic;
using Lubala.Core.Tokens;

namespace Lubala.Core
{
    public class ApiContext
    {
        public ApiContext()
        {
            Params = new List<RequestParam>();
        }

        internal IList<RequestParam> Params { get; set; }
        internal bool AutoToken { get; set; } = true;

        public ApiContext AddParam(string key, string value)
        {
            Params.Add(RequestParam.Create(key, value));
            return this;
        }

        public ApiContext DisableAutoToken()
        {
            AutoToken = false;
            return this;
        }
    }
}