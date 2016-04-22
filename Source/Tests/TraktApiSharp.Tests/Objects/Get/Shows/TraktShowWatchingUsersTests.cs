namespace TraktApiSharp.Tests.Objects.Shows
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Linq;
    using TraktApiSharp.Objects.Get.Shows;
    using Utils;

    [TestClass]
    public class TraktShowWatchingUsersTests
    {
        [TestMethod]
        public void TestTraktShowWatchingUsersReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowWatchingUsers.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var showWatchingUsers = JsonConvert.DeserializeObject<IEnumerable<TraktShowWatchingUser>>(jsonFile);

            showWatchingUsers.Should().NotBeNull();
            showWatchingUsers.Should().HaveCount(3);

            var watchingUsers = showWatchingUsers.ToArray();

            watchingUsers[0].Username.Should().Be("peoplearemusic");
            watchingUsers[0].Private.Should().BeFalse();
            watchingUsers[0].Name.Should().Be("peoplearemusic");
            watchingUsers[0].VIP.Should().BeFalse();
            watchingUsers[0].VIP_EP.Should().BeFalse();

            watchingUsers[1].Username.Should().Be("alvarogb19");
            watchingUsers[1].Private.Should().BeTrue();
            watchingUsers[1].Name.Should().BeNull();
            watchingUsers[1].VIP.Should().BeFalse();
            watchingUsers[1].VIP_EP.Should().BeTrue();

            watchingUsers[2].Username.Should().Be("Crunchi");
            watchingUsers[2].Private.Should().BeFalse();
            watchingUsers[2].Name.Should().Be("Crunch");
            watchingUsers[2].VIP.Should().BeFalse();
            watchingUsers[2].VIP_EP.Should().BeFalse();
        }
    }
}
