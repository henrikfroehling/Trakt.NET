namespace TraktApiSharp.Tests.Objects
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using TraktApiSharp.Objects.Basic;
    using Utils;

    [TestClass]
    public class TraktSharingTests
    {
        [TestMethod]
        public void TestTraktSharingDefaultConstructor()
        {
            var sharing = new TraktSharing();

            sharing.Facebook.Should().NotHaveValue();
            sharing.Twitter.Should().NotHaveValue();
            sharing.Google.Should().NotHaveValue();
            sharing.Tumblr.Should().NotHaveValue();
            sharing.Medium.Should().NotHaveValue();
            sharing.Slack.Should().NotHaveValue();
        }

        [TestMethod]
        public void TestTraktSharingReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Basic\Sharing.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var sharing = JsonConvert.DeserializeObject<TraktSharing>(jsonFile);

            sharing.Should().NotBeNull();
            sharing.Facebook.Should().BeTrue();
            sharing.Twitter.Should().BeTrue();
            sharing.Google.Should().BeTrue();
            sharing.Tumblr.Should().BeFalse();
            sharing.Medium.Should().BeFalse();
            sharing.Slack.Should().BeFalse();
        }
    }
}
