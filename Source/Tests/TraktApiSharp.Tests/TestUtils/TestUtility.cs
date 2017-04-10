namespace TraktApiSharp.Tests.TestUtils
{
    using System.IO;

    public static class TestUtility
    {
        public static Stream ToStream(this string str)
        {
            var stream = new MemoryStream();
            var streamWriter = new StreamWriter(stream);

            streamWriter.Write(str);
            streamWriter.Flush();
            stream.Position = 0;

            return stream;
        }
    }
}
