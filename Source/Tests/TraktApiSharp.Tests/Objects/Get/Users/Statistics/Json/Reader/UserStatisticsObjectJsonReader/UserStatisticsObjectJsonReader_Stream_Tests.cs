namespace TraktApiSharp.Tests.Objects.Get.Users.Statistics.Json.Reader
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.Statistics.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Users.Statistics.JsonReader")]
    public partial class UserStatisticsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserStatisticsObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var jsonReader = new UserStatisticsObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var userStatistics = await jsonReader.ReadObjectAsync(stream);

                userStatistics.Should().NotBeNull();

                userStatistics.Movies.Should().NotBeNull();
                userStatistics.Movies.Plays.Should().Be(552);
                userStatistics.Movies.Watched.Should().Be(534);
                userStatistics.Movies.Minutes.Should().Be(17330);
                userStatistics.Movies.Collected.Should().Be(117);
                userStatistics.Movies.Ratings.Should().Be(64);
                userStatistics.Movies.Comments.Should().Be(14);

                userStatistics.Shows.Should().NotBeNull();
                userStatistics.Shows.Watched.Should().Be(534);
                userStatistics.Shows.Collected.Should().Be(117);
                userStatistics.Shows.Ratings.Should().Be(64);
                userStatistics.Shows.Comments.Should().Be(14);

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
                userStatistics.Ratings.Total.Should().Be(9257);
                userStatistics.Ratings.Distribution.Should().NotBeNull();
                userStatistics.Ratings.Distribution.Should().NotBeEmpty();
                userStatistics.Ratings.Distribution.Should().HaveCount(10);
                userStatistics.Ratings.Distribution.Should().Contain(new Dictionary<string, int>
                {
                    ["1"] = 78,
                    ["2"] = 45,
                    ["3"] = 55,
                    ["4"] = 96,
                    ["5"] = 183,
                    ["6"] = 545,
                    ["7"] = 1361,
                    ["8"] = 2259,
                    ["9"] = 1772,
                    ["10"] = 2863
                });
            }
        }

        [Fact]
        public async Task Test_UserStatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var jsonReader = new UserStatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var userStatistics = await jsonReader.ReadObjectAsync(stream);

                userStatistics.Should().NotBeNull();

                userStatistics.Movies.Should().BeNull();

                userStatistics.Shows.Should().NotBeNull();
                userStatistics.Shows.Watched.Should().Be(534);
                userStatistics.Shows.Collected.Should().Be(117);
                userStatistics.Shows.Ratings.Should().Be(64);
                userStatistics.Shows.Comments.Should().Be(14);

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
                userStatistics.Ratings.Total.Should().Be(9257);
                userStatistics.Ratings.Distribution.Should().NotBeNull();
                userStatistics.Ratings.Distribution.Should().NotBeEmpty();
                userStatistics.Ratings.Distribution.Should().HaveCount(10);
                userStatistics.Ratings.Distribution.Should().Contain(new Dictionary<string, int>
                {
                    ["1"] = 78,
                    ["2"] = 45,
                    ["3"] = 55,
                    ["4"] = 96,
                    ["5"] = 183,
                    ["6"] = 545,
                    ["7"] = 1361,
                    ["8"] = 2259,
                    ["9"] = 1772,
                    ["10"] = 2863
                });
            }
        }

        [Fact]
        public async Task Test_UserStatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var jsonReader = new UserStatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var userStatistics = await jsonReader.ReadObjectAsync(stream);

                userStatistics.Should().NotBeNull();

                userStatistics.Movies.Should().NotBeNull();
                userStatistics.Movies.Plays.Should().Be(552);
                userStatistics.Movies.Watched.Should().Be(534);
                userStatistics.Movies.Minutes.Should().Be(17330);
                userStatistics.Movies.Collected.Should().Be(117);
                userStatistics.Movies.Ratings.Should().Be(64);
                userStatistics.Movies.Comments.Should().Be(14);

                userStatistics.Shows.Should().BeNull();

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
                userStatistics.Ratings.Total.Should().Be(9257);
                userStatistics.Ratings.Distribution.Should().NotBeNull();
                userStatistics.Ratings.Distribution.Should().NotBeEmpty();
                userStatistics.Ratings.Distribution.Should().HaveCount(10);
                userStatistics.Ratings.Distribution.Should().Contain(new Dictionary<string, int>
                {
                    ["1"] = 78,
                    ["2"] = 45,
                    ["3"] = 55,
                    ["4"] = 96,
                    ["5"] = 183,
                    ["6"] = 545,
                    ["7"] = 1361,
                    ["8"] = 2259,
                    ["9"] = 1772,
                    ["10"] = 2863
                });
            }
        }

        [Fact]
        public async Task Test_UserStatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_3()
        {
            var jsonReader = new UserStatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_3.ToStream())
            {
                var userStatistics = await jsonReader.ReadObjectAsync(stream);

                userStatistics.Should().NotBeNull();

                userStatistics.Movies.Should().NotBeNull();
                userStatistics.Movies.Plays.Should().Be(552);
                userStatistics.Movies.Watched.Should().Be(534);
                userStatistics.Movies.Minutes.Should().Be(17330);
                userStatistics.Movies.Collected.Should().Be(117);
                userStatistics.Movies.Ratings.Should().Be(64);
                userStatistics.Movies.Comments.Should().Be(14);

                userStatistics.Shows.Should().NotBeNull();
                userStatistics.Shows.Watched.Should().Be(534);
                userStatistics.Shows.Collected.Should().Be(117);
                userStatistics.Shows.Ratings.Should().Be(64);
                userStatistics.Shows.Comments.Should().Be(14);

                userStatistics.Seasons.Should().BeNull();

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
                userStatistics.Ratings.Total.Should().Be(9257);
                userStatistics.Ratings.Distribution.Should().NotBeNull();
                userStatistics.Ratings.Distribution.Should().NotBeEmpty();
                userStatistics.Ratings.Distribution.Should().HaveCount(10);
                userStatistics.Ratings.Distribution.Should().Contain(new Dictionary<string, int>
                {
                    ["1"] = 78,
                    ["2"] = 45,
                    ["3"] = 55,
                    ["4"] = 96,
                    ["5"] = 183,
                    ["6"] = 545,
                    ["7"] = 1361,
                    ["8"] = 2259,
                    ["9"] = 1772,
                    ["10"] = 2863
                });
            }
        }

        [Fact]
        public async Task Test_UserStatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_4()
        {
            var jsonReader = new UserStatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_4.ToStream())
            {
                var userStatistics = await jsonReader.ReadObjectAsync(stream);

                userStatistics.Should().NotBeNull();

                userStatistics.Movies.Should().NotBeNull();
                userStatistics.Movies.Plays.Should().Be(552);
                userStatistics.Movies.Watched.Should().Be(534);
                userStatistics.Movies.Minutes.Should().Be(17330);
                userStatistics.Movies.Collected.Should().Be(117);
                userStatistics.Movies.Ratings.Should().Be(64);
                userStatistics.Movies.Comments.Should().Be(14);

                userStatistics.Shows.Should().NotBeNull();
                userStatistics.Shows.Watched.Should().Be(534);
                userStatistics.Shows.Collected.Should().Be(117);
                userStatistics.Shows.Ratings.Should().Be(64);
                userStatistics.Shows.Comments.Should().Be(14);

                userStatistics.Seasons.Should().NotBeNull();
                userStatistics.Seasons.Ratings.Should().Be(6);
                userStatistics.Seasons.Comments.Should().Be(1);

                userStatistics.Episodes.Should().BeNull();

                userStatistics.Network.Should().NotBeNull();
                userStatistics.Network.Friends.Should().Be(1);
                userStatistics.Network.Followers.Should().Be(4);
                userStatistics.Network.Following.Should().Be(11);

                userStatistics.Ratings.Should().NotBeNull();
                userStatistics.Ratings.Total.Should().Be(9257);
                userStatistics.Ratings.Distribution.Should().NotBeNull();
                userStatistics.Ratings.Distribution.Should().NotBeEmpty();
                userStatistics.Ratings.Distribution.Should().HaveCount(10);
                userStatistics.Ratings.Distribution.Should().Contain(new Dictionary<string, int>
                {
                    ["1"] = 78,
                    ["2"] = 45,
                    ["3"] = 55,
                    ["4"] = 96,
                    ["5"] = 183,
                    ["6"] = 545,
                    ["7"] = 1361,
                    ["8"] = 2259,
                    ["9"] = 1772,
                    ["10"] = 2863
                });
            }
        }

        [Fact]
        public async Task Test_UserStatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_5()
        {
            var jsonReader = new UserStatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_5.ToStream())
            {
                var userStatistics = await jsonReader.ReadObjectAsync(stream);

                userStatistics.Should().NotBeNull();

                userStatistics.Movies.Should().NotBeNull();
                userStatistics.Movies.Plays.Should().Be(552);
                userStatistics.Movies.Watched.Should().Be(534);
                userStatistics.Movies.Minutes.Should().Be(17330);
                userStatistics.Movies.Collected.Should().Be(117);
                userStatistics.Movies.Ratings.Should().Be(64);
                userStatistics.Movies.Comments.Should().Be(14);

                userStatistics.Shows.Should().NotBeNull();
                userStatistics.Shows.Watched.Should().Be(534);
                userStatistics.Shows.Collected.Should().Be(117);
                userStatistics.Shows.Ratings.Should().Be(64);
                userStatistics.Shows.Comments.Should().Be(14);

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

                userStatistics.Network.Should().BeNull();

                userStatistics.Ratings.Should().NotBeNull();
                userStatistics.Ratings.Total.Should().Be(9257);
                userStatistics.Ratings.Distribution.Should().NotBeNull();
                userStatistics.Ratings.Distribution.Should().NotBeEmpty();
                userStatistics.Ratings.Distribution.Should().HaveCount(10);
                userStatistics.Ratings.Distribution.Should().Contain(new Dictionary<string, int>
                {
                    ["1"] = 78,
                    ["2"] = 45,
                    ["3"] = 55,
                    ["4"] = 96,
                    ["5"] = 183,
                    ["6"] = 545,
                    ["7"] = 1361,
                    ["8"] = 2259,
                    ["9"] = 1772,
                    ["10"] = 2863
                });
            }
        }

        [Fact]
        public async Task Test_UserStatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_6()
        {
            var jsonReader = new UserStatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_6.ToStream())
            {
                var userStatistics = await jsonReader.ReadObjectAsync(stream);

                userStatistics.Should().NotBeNull();

                userStatistics.Movies.Should().NotBeNull();
                userStatistics.Movies.Plays.Should().Be(552);
                userStatistics.Movies.Watched.Should().Be(534);
                userStatistics.Movies.Minutes.Should().Be(17330);
                userStatistics.Movies.Collected.Should().Be(117);
                userStatistics.Movies.Ratings.Should().Be(64);
                userStatistics.Movies.Comments.Should().Be(14);

                userStatistics.Shows.Should().NotBeNull();
                userStatistics.Shows.Watched.Should().Be(534);
                userStatistics.Shows.Collected.Should().Be(117);
                userStatistics.Shows.Ratings.Should().Be(64);
                userStatistics.Shows.Comments.Should().Be(14);

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

                userStatistics.Ratings.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserStatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_7()
        {
            var jsonReader = new UserStatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_7.ToStream())
            {
                var userStatistics = await jsonReader.ReadObjectAsync(stream);

                userStatistics.Should().NotBeNull();

                userStatistics.Movies.Should().NotBeNull();
                userStatistics.Movies.Plays.Should().Be(552);
                userStatistics.Movies.Watched.Should().Be(534);
                userStatistics.Movies.Minutes.Should().Be(17330);
                userStatistics.Movies.Collected.Should().Be(117);
                userStatistics.Movies.Ratings.Should().Be(64);
                userStatistics.Movies.Comments.Should().Be(14);

                userStatistics.Shows.Should().BeNull();
                userStatistics.Seasons.Should().BeNull();
                userStatistics.Episodes.Should().BeNull();
                userStatistics.Network.Should().BeNull();
                userStatistics.Ratings.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserStatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_8()
        {
            var jsonReader = new UserStatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_8.ToStream())
            {
                var userStatistics = await jsonReader.ReadObjectAsync(stream);

                userStatistics.Should().NotBeNull();

                userStatistics.Movies.Should().BeNull();

                userStatistics.Shows.Should().NotBeNull();
                userStatistics.Shows.Watched.Should().Be(534);
                userStatistics.Shows.Collected.Should().Be(117);
                userStatistics.Shows.Ratings.Should().Be(64);
                userStatistics.Shows.Comments.Should().Be(14);

                userStatistics.Seasons.Should().BeNull();
                userStatistics.Episodes.Should().BeNull();
                userStatistics.Network.Should().BeNull();
                userStatistics.Ratings.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserStatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_9()
        {
            var jsonReader = new UserStatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_9.ToStream())
            {
                var userStatistics = await jsonReader.ReadObjectAsync(stream);

                userStatistics.Should().NotBeNull();

                userStatistics.Movies.Should().BeNull();
                userStatistics.Shows.Should().BeNull();

                userStatistics.Seasons.Should().NotBeNull();
                userStatistics.Seasons.Ratings.Should().Be(6);
                userStatistics.Seasons.Comments.Should().Be(1);

                userStatistics.Episodes.Should().BeNull();
                userStatistics.Network.Should().BeNull();
                userStatistics.Ratings.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserStatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_10()
        {
            var jsonReader = new UserStatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_10.ToStream())
            {
                var userStatistics = await jsonReader.ReadObjectAsync(stream);

                userStatistics.Should().NotBeNull();

                userStatistics.Movies.Should().BeNull();
                userStatistics.Shows.Should().BeNull();
                userStatistics.Seasons.Should().BeNull();

                userStatistics.Episodes.Should().NotBeNull();
                userStatistics.Episodes.Plays.Should().Be(552);
                userStatistics.Episodes.Watched.Should().Be(534);
                userStatistics.Episodes.Minutes.Should().Be(17330);
                userStatistics.Episodes.Collected.Should().Be(117);
                userStatistics.Episodes.Ratings.Should().Be(64);
                userStatistics.Episodes.Comments.Should().Be(14);

                userStatistics.Network.Should().BeNull();
                userStatistics.Ratings.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserStatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_11()
        {
            var jsonReader = new UserStatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_11.ToStream())
            {
                var userStatistics = await jsonReader.ReadObjectAsync(stream);

                userStatistics.Should().NotBeNull();

                userStatistics.Movies.Should().BeNull();
                userStatistics.Shows.Should().BeNull();
                userStatistics.Seasons.Should().BeNull();
                userStatistics.Episodes.Should().BeNull();

                userStatistics.Network.Should().NotBeNull();
                userStatistics.Network.Friends.Should().Be(1);
                userStatistics.Network.Followers.Should().Be(4);
                userStatistics.Network.Following.Should().Be(11);

                userStatistics.Ratings.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserStatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_12()
        {
            var jsonReader = new UserStatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_12.ToStream())
            {
                var userStatistics = await jsonReader.ReadObjectAsync(stream);

                userStatistics.Should().NotBeNull();

                userStatistics.Movies.Should().BeNull();
                userStatistics.Shows.Should().BeNull();
                userStatistics.Seasons.Should().BeNull();
                userStatistics.Episodes.Should().BeNull();
                userStatistics.Network.Should().BeNull();

                userStatistics.Ratings.Should().NotBeNull();
                userStatistics.Ratings.Total.Should().Be(9257);
                userStatistics.Ratings.Distribution.Should().NotBeNull();
                userStatistics.Ratings.Distribution.Should().NotBeEmpty();
                userStatistics.Ratings.Distribution.Should().HaveCount(10);
                userStatistics.Ratings.Distribution.Should().Contain(new Dictionary<string, int>
                {
                    ["1"] = 78,
                    ["2"] = 45,
                    ["3"] = 55,
                    ["4"] = 96,
                    ["5"] = 183,
                    ["6"] = 545,
                    ["7"] = 1361,
                    ["8"] = 2259,
                    ["9"] = 1772,
                    ["10"] = 2863
                });
            }
        }

        [Fact]
        public async Task Test_UserStatisticsObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var jsonReader = new UserStatisticsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var userStatistics = await jsonReader.ReadObjectAsync(stream);

                userStatistics.Should().NotBeNull();

                userStatistics.Movies.Should().BeNull();

                userStatistics.Shows.Should().NotBeNull();
                userStatistics.Shows.Watched.Should().Be(534);
                userStatistics.Shows.Collected.Should().Be(117);
                userStatistics.Shows.Ratings.Should().Be(64);
                userStatistics.Shows.Comments.Should().Be(14);

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
                userStatistics.Ratings.Total.Should().Be(9257);
                userStatistics.Ratings.Distribution.Should().NotBeNull();
                userStatistics.Ratings.Distribution.Should().NotBeEmpty();
                userStatistics.Ratings.Distribution.Should().HaveCount(10);
                userStatistics.Ratings.Distribution.Should().Contain(new Dictionary<string, int>
                {
                    ["1"] = 78,
                    ["2"] = 45,
                    ["3"] = 55,
                    ["4"] = 96,
                    ["5"] = 183,
                    ["6"] = 545,
                    ["7"] = 1361,
                    ["8"] = 2259,
                    ["9"] = 1772,
                    ["10"] = 2863
                });
            }
        }

        [Fact]
        public async Task Test_UserStatisticsObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var jsonReader = new UserStatisticsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var userStatistics = await jsonReader.ReadObjectAsync(stream);

                userStatistics.Should().NotBeNull();

                userStatistics.Movies.Should().NotBeNull();
                userStatistics.Movies.Plays.Should().Be(552);
                userStatistics.Movies.Watched.Should().Be(534);
                userStatistics.Movies.Minutes.Should().Be(17330);
                userStatistics.Movies.Collected.Should().Be(117);
                userStatistics.Movies.Ratings.Should().Be(64);
                userStatistics.Movies.Comments.Should().Be(14);

                userStatistics.Shows.Should().BeNull();

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
                userStatistics.Ratings.Total.Should().Be(9257);
                userStatistics.Ratings.Distribution.Should().NotBeNull();
                userStatistics.Ratings.Distribution.Should().NotBeEmpty();
                userStatistics.Ratings.Distribution.Should().HaveCount(10);
                userStatistics.Ratings.Distribution.Should().Contain(new Dictionary<string, int>
                {
                    ["1"] = 78,
                    ["2"] = 45,
                    ["3"] = 55,
                    ["4"] = 96,
                    ["5"] = 183,
                    ["6"] = 545,
                    ["7"] = 1361,
                    ["8"] = 2259,
                    ["9"] = 1772,
                    ["10"] = 2863
                });
            }
        }

        [Fact]
        public async Task Test_UserStatisticsObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var jsonReader = new UserStatisticsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var userStatistics = await jsonReader.ReadObjectAsync(stream);

                userStatistics.Should().NotBeNull();

                userStatistics.Movies.Should().NotBeNull();
                userStatistics.Movies.Plays.Should().Be(552);
                userStatistics.Movies.Watched.Should().Be(534);
                userStatistics.Movies.Minutes.Should().Be(17330);
                userStatistics.Movies.Collected.Should().Be(117);
                userStatistics.Movies.Ratings.Should().Be(64);
                userStatistics.Movies.Comments.Should().Be(14);

                userStatistics.Shows.Should().NotBeNull();
                userStatistics.Shows.Watched.Should().Be(534);
                userStatistics.Shows.Collected.Should().Be(117);
                userStatistics.Shows.Ratings.Should().Be(64);
                userStatistics.Shows.Comments.Should().Be(14);

                userStatistics.Seasons.Should().BeNull();

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
                userStatistics.Ratings.Total.Should().Be(9257);
                userStatistics.Ratings.Distribution.Should().NotBeNull();
                userStatistics.Ratings.Distribution.Should().NotBeEmpty();
                userStatistics.Ratings.Distribution.Should().HaveCount(10);
                userStatistics.Ratings.Distribution.Should().Contain(new Dictionary<string, int>
                {
                    ["1"] = 78,
                    ["2"] = 45,
                    ["3"] = 55,
                    ["4"] = 96,
                    ["5"] = 183,
                    ["6"] = 545,
                    ["7"] = 1361,
                    ["8"] = 2259,
                    ["9"] = 1772,
                    ["10"] = 2863
                });
            }
        }

        [Fact]
        public async Task Test_UserStatisticsObjectJsonReader_ReadObject_From_Stream_Not_Valid_4()
        {
            var jsonReader = new UserStatisticsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_4.ToStream())
            {
                var userStatistics = await jsonReader.ReadObjectAsync(stream);

                userStatistics.Should().NotBeNull();

                userStatistics.Movies.Should().NotBeNull();
                userStatistics.Movies.Plays.Should().Be(552);
                userStatistics.Movies.Watched.Should().Be(534);
                userStatistics.Movies.Minutes.Should().Be(17330);
                userStatistics.Movies.Collected.Should().Be(117);
                userStatistics.Movies.Ratings.Should().Be(64);
                userStatistics.Movies.Comments.Should().Be(14);

                userStatistics.Shows.Should().NotBeNull();
                userStatistics.Shows.Watched.Should().Be(534);
                userStatistics.Shows.Collected.Should().Be(117);
                userStatistics.Shows.Ratings.Should().Be(64);
                userStatistics.Shows.Comments.Should().Be(14);

                userStatistics.Seasons.Should().NotBeNull();
                userStatistics.Seasons.Ratings.Should().Be(6);
                userStatistics.Seasons.Comments.Should().Be(1);

                userStatistics.Episodes.Should().BeNull();

                userStatistics.Network.Should().NotBeNull();
                userStatistics.Network.Friends.Should().Be(1);
                userStatistics.Network.Followers.Should().Be(4);
                userStatistics.Network.Following.Should().Be(11);

                userStatistics.Ratings.Should().NotBeNull();
                userStatistics.Ratings.Total.Should().Be(9257);
                userStatistics.Ratings.Distribution.Should().NotBeNull();
                userStatistics.Ratings.Distribution.Should().NotBeEmpty();
                userStatistics.Ratings.Distribution.Should().HaveCount(10);
                userStatistics.Ratings.Distribution.Should().Contain(new Dictionary<string, int>
                {
                    ["1"] = 78,
                    ["2"] = 45,
                    ["3"] = 55,
                    ["4"] = 96,
                    ["5"] = 183,
                    ["6"] = 545,
                    ["7"] = 1361,
                    ["8"] = 2259,
                    ["9"] = 1772,
                    ["10"] = 2863
                });
            }
        }

        [Fact]
        public async Task Test_UserStatisticsObjectJsonReader_ReadObject_From_Stream_Not_Valid_5()
        {
            var jsonReader = new UserStatisticsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_5.ToStream())
            {
                var userStatistics = await jsonReader.ReadObjectAsync(stream);

                userStatistics.Should().NotBeNull();

                userStatistics.Movies.Should().NotBeNull();
                userStatistics.Movies.Plays.Should().Be(552);
                userStatistics.Movies.Watched.Should().Be(534);
                userStatistics.Movies.Minutes.Should().Be(17330);
                userStatistics.Movies.Collected.Should().Be(117);
                userStatistics.Movies.Ratings.Should().Be(64);
                userStatistics.Movies.Comments.Should().Be(14);

                userStatistics.Shows.Should().NotBeNull();
                userStatistics.Shows.Watched.Should().Be(534);
                userStatistics.Shows.Collected.Should().Be(117);
                userStatistics.Shows.Ratings.Should().Be(64);
                userStatistics.Shows.Comments.Should().Be(14);

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

                userStatistics.Network.Should().BeNull();

                userStatistics.Ratings.Should().NotBeNull();
                userStatistics.Ratings.Total.Should().Be(9257);
                userStatistics.Ratings.Distribution.Should().NotBeNull();
                userStatistics.Ratings.Distribution.Should().NotBeEmpty();
                userStatistics.Ratings.Distribution.Should().HaveCount(10);
                userStatistics.Ratings.Distribution.Should().Contain(new Dictionary<string, int>
                {
                    ["1"] = 78,
                    ["2"] = 45,
                    ["3"] = 55,
                    ["4"] = 96,
                    ["5"] = 183,
                    ["6"] = 545,
                    ["7"] = 1361,
                    ["8"] = 2259,
                    ["9"] = 1772,
                    ["10"] = 2863
                });
            }
        }

        [Fact]
        public async Task Test_UserStatisticsObjectJsonReader_ReadObject_From_Stream_Not_Valid_6()
        {
            var jsonReader = new UserStatisticsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_6.ToStream())
            {
                var userStatistics = await jsonReader.ReadObjectAsync(stream);

                userStatistics.Should().NotBeNull();

                userStatistics.Movies.Should().NotBeNull();
                userStatistics.Movies.Plays.Should().Be(552);
                userStatistics.Movies.Watched.Should().Be(534);
                userStatistics.Movies.Minutes.Should().Be(17330);
                userStatistics.Movies.Collected.Should().Be(117);
                userStatistics.Movies.Ratings.Should().Be(64);
                userStatistics.Movies.Comments.Should().Be(14);

                userStatistics.Shows.Should().NotBeNull();
                userStatistics.Shows.Watched.Should().Be(534);
                userStatistics.Shows.Collected.Should().Be(117);
                userStatistics.Shows.Ratings.Should().Be(64);
                userStatistics.Shows.Comments.Should().Be(14);

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

                userStatistics.Ratings.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserStatisticsObjectJsonReader_ReadObject_From_Stream_Not_Valid_7()
        {
            var jsonReader = new UserStatisticsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_7.ToStream())
            {
                var userStatistics = await jsonReader.ReadObjectAsync(stream);

                userStatistics.Should().NotBeNull();

                userStatistics.Movies.Should().BeNull();
                userStatistics.Shows.Should().BeNull();
                userStatistics.Seasons.Should().BeNull();
                userStatistics.Episodes.Should().BeNull();
                userStatistics.Network.Should().BeNull();
                userStatistics.Ratings.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserStatisticsObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new UserStatisticsObjectJsonReader();

            var userStatistics = await jsonReader.ReadObjectAsync(default(Stream));
            userStatistics.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserStatisticsObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new UserStatisticsObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var userStatistics = await jsonReader.ReadObjectAsync(stream);
                userStatistics.Should().BeNull();
            }
        }
    }
}
