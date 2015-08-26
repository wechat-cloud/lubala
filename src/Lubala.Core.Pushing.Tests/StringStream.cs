using System;
using System.IO;

namespace Lubala.Core.Pushing.Tests
{
    internal class StringStream : IDisposable
    {
        private readonly MemoryStream _memoryStream;
        private readonly StreamWriter _writer;

        private StringStream(string str)
        {
            _memoryStream = new MemoryStream();
            _writer = new StreamWriter(_memoryStream);

            _writer.Write(str);
            _writer.Flush();
            _memoryStream.Position = 0;
        }

        public Stream Stream => _memoryStream;

        public void Dispose()
        {
            _writer.Close();
            _memoryStream.Close();
        }

        public static StringStream Create(string str)
        {
            return new StringStream(str);
        }
    }
}