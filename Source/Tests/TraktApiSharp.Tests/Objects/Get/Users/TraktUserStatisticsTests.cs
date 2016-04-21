namespace TraktApiSharp.Tests.Objects.Get.Users
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using TraktApiSharp.Objects.Get.Users;
    using Utils;
    [TestClass]
    public class TraktUserStatisticsTests
    {
        [TestMethod]
        public void TestTraktUserStatisticsDefaultConstructor()
        {
            var userStatistics = new TraktUserStatistics();

            userStatistics.Movies.Should().BeNull();
            userStatistics.Shows.Should().BeNull();
            userStatistics.Seasons.Should().BeNull();
            userStatistics.Episodes.Should().BeNull();
            userStatistics.Network.Should().BeNull();
            userStatistics.Ratings.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktUserStatisticsReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Users\UserStatistics.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var userStatistics = JsonConvert.DeserializeObject<TraktUserStatistics>(jsonFile);

            userStatistics.Should().NotBeNull();

            userStatistics.Movies.Should().NotBeNull();
            userStatistics.Movies.Plays.Should().Be(155);
            userStatistics.Movies.Watched.Should().Be(114);
            userStatistics.Movies.Minutes.Should().Be(15650);
            userStatistics.Movies.Collected.Should().Be(933);
            userStatistics.Movies.Ratings.Should().Be(256);
            userStatistics.Movies.Comments.Should().Be(28);

            userStatistics.Shows.Should().NotBeNull();
            userStatistics.Shows.Watched.Should().Be(16);
            userStatistics.Shows.Collected.Should().Be(7);
            userStatistics.Shows.Ratings.Should().Be(63);
            userStatistics.Shows.Comments.Should().Be(20);

            userStatistics.Seasons.Should().NotBeNull();
            userStatistics.Seasons.Ratings.Should().Be(6);
            userStatistics.Seasons.Comments.Should().Be(1);

            userStatistics.Episodes.Should().NotBeNull();
            userStatistics.Episodes.Plays.Should().Be(552);
            userStatistics.Episodes.Watched.Should().Be(534);
            userStatistics.Episodes.Minutes.Should().Be(17330);
            userStatistics.Episodes.Collected.Should().Be(117);
            userStatistics.Episodes.Ratings.Should().Be(64);
            userStatistics.Episodes.Comments.Should().Be(14);

            userStatistics.Network.Should().NotBeNull();
            userStatistics.Network.Friends.Should().Be(1);
            userStatistics.Network.Followers.Should().Be(4);
            userStatistics.Network.Following.Should().Be(11);

            userStatistics.Ratings.Should().NotBeNull();
            userStatistics.Ratings.Total.Should().Be(389);

            var distribution = new Dictionary<string, int>()
            {
                { "1",  18 }, { "2", 1 }, { "3", 4 }, { "4", 1 }, { "5", 10 },
                { "6",  9 }, { "7", 37 }, { "8", 37 }, { "9", 57 }, { "10", 215 }
            };

            userStatistics.Ratings.Distribution.Should().NotBeNull().And.HaveCount(10).And.Contain(distribution);
        }
    }
}
