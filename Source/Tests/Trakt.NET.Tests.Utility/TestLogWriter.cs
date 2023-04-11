namespace Trakt.NET.Tests.Utility
{
    using TraktNet;
    using Xunit.Abstractions;

    internal class TestLogWriter : ILogWriter
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public TestLogWriter(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        public void WriteLine(string text)
        {
            _testOutputHelper.WriteLine(text);
        }
    }
}
