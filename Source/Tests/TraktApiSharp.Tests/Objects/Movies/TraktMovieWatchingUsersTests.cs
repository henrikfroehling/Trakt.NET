namespace TraktApiSharp.Tests.Objects.Movies
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Linq;
    using TraktApiSharp.Objects.Movies;
    using Utils;

    [TestClass]
    public class TraktMovieWatchingUsersTests
    {
        [TestMethod]
        public void TestTraktMovieWatchingUsersReadFromJson()
        {
            var jsonFile = TestUtility.ReadJsonData(@"Movies\MovieWatchingUsers.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var movieWatchingUsers = JsonConvert.DeserializeObject<IEnumerable<TraktMovieWatchingUser>>(jsonFile);

            movieWatchingUsers.Should().NotBeNull();
            movieWatchingUsers.Should().HaveCount(3);

            var watchingUsers = movieWatchingUsers.ToArray();

            watchingUsers[0].Username.Should().Be("Levimenten");
            watchingUsers[0].Private.Should().BeTrue();
            watchingUsers[0].Name.Should().Be("Levi Menten");
            watchingUsers[0].VIP.Should().BeFalse();
            watchingUsers[0].VIP_EP.Should().BeFalse();

            watchingUsers[1].Username.Should().Be("WIllGamer");
            watchingUsers[1].Private.Should().BeFalse();
            watchingUsers[1].Name.Should().Be("Wilson Neves");
            watchingUsers[1].VIP.Should().BeFalse();
            watchingUsers[1].VIP_EP.Should().BeTrue();

            watchingUsers[2].Username.Should().Be("Linkz");
            watchingUsers[2].Private.Should().BeFalse();
            watchingUsers[2].Name.Should().BeNull();
            watchingUsers[2].VIP.Should().BeFalse();
            watchingUsers[2].VIP_EP.Should().BeFalse();
        }
    }
}
