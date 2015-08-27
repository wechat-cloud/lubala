using System;
using System.IO;

namespace Lubala.Core.Tests
{
    internal class SecretInformationReader
    {
        public SecretInformationReader()
        {
            try
            {
                using (var stream = new StreamReader("info.txt"))
                {
                    var appId = stream.ReadLine();
                    var appSecret = stream.ReadLine();
                    AppId = appId;
                    AppSecret = appSecret;
                }
            }
            catch
            {

            }
        }

        public string AppSecret { get; set; }

        public string AppId { get; set; }
    }
}