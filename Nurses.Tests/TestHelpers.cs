using System.IO;
using System.Collections.Generic;

namespace Nurses.Tests
{
    public class TestHelpers
    {
        public static StreamReader CreateStreamReader(List<string> lines)
        {
            var stream = new MemoryStream();
			var writer = new StreamWriter(stream);
            foreach(string line in lines) {
                writer.WriteLine(line);
            }
            writer.Flush();
			stream.Position = 0;
            return new StreamReader(stream);
        }
    }
}