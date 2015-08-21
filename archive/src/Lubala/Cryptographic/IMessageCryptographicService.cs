using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lubala.Cryptographic
{
    internal interface IMessageCryptographicService
    {
        string DecryptMessage(KernelSetting setting, string rawMessage);
        string EncryptMessage(KernelSetting setting, string rawMessage);
    }
}
