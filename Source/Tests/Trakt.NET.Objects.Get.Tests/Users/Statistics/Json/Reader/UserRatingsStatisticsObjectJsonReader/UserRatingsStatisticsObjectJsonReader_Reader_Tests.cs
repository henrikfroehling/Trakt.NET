﻿namespace TraktNet.Objects.Get.Tests.Users.Statistics.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Users.Statistics;
    using TraktNet.Objects.Get.Users.Statistics.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Users.Statistics.JsonReader")]
    public partial class UserRatingsStatisticsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserRatingsStatisticsObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new UserRatingsStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userRatingsStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userRatingsStatistics.Should().NotBeNull();
                userRatingsStatistics.Total.Should().Be(9257);
                userRatingsStatistics.Distribution.Should().NotBeNull();
                userRatingsStatistics.Distribution.Should().NotBeEmpty();
                userRatingsStatistics.Distribution.Should().HaveCount(10);
                userRatingsStatistics.Distribution.Should().Contain(new Dictionary<string, int>
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
        public async Task Test_UserRatingsStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new UserRatingsStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userRatingsStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userRatingsStatistics.Should().NotBeNull();
                userRatingsStatistics.Total.Should().BeNull();
                userRatingsStatistics.Distribution.Should().NotBeNull();
                userRatingsStatistics.Distribution.Should().NotBeEmpty();
                userRatingsStatistics.Distribution.Should().HaveCount(10);
                userRatingsStatistics.Distribution.Should().Contain(new Dictionary<string, int>
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
        public async Task Test_UserRatingsStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new UserRatingsStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userRatingsStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userRatingsStatistics.Should().NotBeNull();
                userRatingsStatistics.Total.Should().Be(9257);
                userRatingsStatistics.Distribution.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserRatingsStatisticsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new UserRatingsStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userRatingsStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userRatingsStatistics.Should().NotBeNull();
                userRatingsStatistics.Total.Should().BeNull();
                userRatingsStatistics.Distribution.Should().NotBeNull();
                userRatingsStatistics.Distribution.Should().NotBeEmpty();
                userRatingsStatistics.Distribution.Should().HaveCount(10);
                userRatingsStatistics.Distribution.Should().Contain(new Dictionary<string, int>
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
        public async Task Test_UserRatingsStatisticsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new UserRatingsStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userRatingsStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userRatingsStatistics.Should().NotBeNull();
                userRatingsStatistics.Total.Should().Be(9257);
                userRatingsStatistics.Distribution.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserRatingsStatisticsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new UserRatingsStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userRatingsStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userRatingsStatistics.Should().NotBeNull();
                userRatingsStatistics.Total.Should().BeNull();
                userRatingsStatistics.Distribution.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserRatingsStatisticsObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new UserRatingsStatisticsObjectJsonReader();
            Func<Task<ITraktUserRatingsStatistics>> userRatingsStatistics = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await userRatingsStatistics.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_UserRatingsStatisticsObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new UserRatingsStatisticsObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userRatingsStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);
                userRatingsStatistics.Should().BeNull();
            }
        }
    }
}
