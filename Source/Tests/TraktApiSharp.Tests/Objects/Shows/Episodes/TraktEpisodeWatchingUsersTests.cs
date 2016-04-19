namespace TraktApiSharp.Tests.Objects.Shows.Episodes
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Linq;
    using TraktApiSharp.Objects.Get.Shows.Episodes;
    using Utils;

    [TestClass]
    public class TraktEpisodeWatchingUsersTests
    {
        [TestMethod]
        public void TestTraktEpisodeWatchingUsersReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Shows\Episodes\EpisodeWatchingUsers.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var episodeWatchingUsers = JsonConvert.DeserializeObject<IEnumerable<TraktEpisodeWatchingUser>>(jsonFile);

            episodeWatchingUsers.Should().NotBeNull();
            episodeWatchingUsers.Should().HaveCount(2);

            var watchingUsers = episodeWatchingUsers.ToArray();

            watchingUsers[0].Username.Should().Be("Horaces");
            watchingUsers[0].Private.Should().BeFalse();
            watchingUsers[0].Name.Should().BeNull();
            watchingUsers[0].VIP.Should().BeFalse();
            watchingUsers[0].VIP_EP.Should().BeFalse();

            watchingUsers[1].Username.Should().Be("stannyowl");
            watchingUsers[1].Private.Should().BeTrue();
            watchingUsers[1].Name.Should().Be("stanny");
            watchingUsers[1].VIP.Should().BeFalse();
            watchingUsers[1].VIP_EP.Should().BeTrue();
        }
    }
}
