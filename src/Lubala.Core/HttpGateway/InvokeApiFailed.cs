using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lubala.Core.HttpGateway
{
    internal class InvokeApiFailed
    {
        public string errcode { get; set; }
        public string errmsg { get; set; }

        public bool IsFailed()
        {
            return errcode != null || errmsg != null;
        }
    }
}
