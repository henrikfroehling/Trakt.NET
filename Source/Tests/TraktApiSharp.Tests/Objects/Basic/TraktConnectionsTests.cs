namespace TraktApiSharp.Tests.Objects
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using TraktApiSharp.Objects.Basic;
    using Utils;

    [TestClass]
    public class TraktConnectionsTests
    {
        [TestMethod]
        public void TestTraktConnectionsDefaultConstructor()
        {
            var connections = new TraktConnections();

            connections.Facebook.Should().NotHaveValue();
            connections.Twitter.Should().NotHaveValue();
            connections.Google.Should().NotHaveValue();
            connections.Tumblr.Should().NotHaveValue();
            connections.Medium.Should().NotHaveValue();
            connections.Slack.Should().NotHaveValue();
        }

        [TestMethod]
        public void TestTraktConnectionsReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Basic\Connections.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var connections = JsonConvert.DeserializeObject<TraktConnections>(jsonFile);

            connections.Should().NotBeNull();
            connections.Facebook.Should().BeTrue();
            connections.Twitter.Should().BeTrue();
            connections.Google.Should().BeTrue();
            connections.Tumblr.Should().BeFalse();
            connections.Medium.Should().BeFalse();
            connections.Slack.Should().BeFalse();
        }
    }
}
