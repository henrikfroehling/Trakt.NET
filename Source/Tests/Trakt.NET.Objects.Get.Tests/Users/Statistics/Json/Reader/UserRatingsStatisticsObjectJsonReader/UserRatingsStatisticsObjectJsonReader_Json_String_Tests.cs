namespace TraktNet.Objects.Get.Tests.Users.Statistics.Json.Reader
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Users.Statistics.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Users.Statistics.JsonReader")]
    public partial class UserRatingsStatisticsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserRatingsStatisticsObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new UserRatingsStatisticsObjectJsonReader();

            var userRatingsStatistics = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

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

        [Fact]
        public async Task Test_UserRatingsStatisticsObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new UserRatingsStatisticsObjectJsonReader();

            var userRatingsStatistics = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

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

        [Fact]
        public async Task Test_UserRatingsStatisticsObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new UserRatingsStatisticsObjectJsonReader();

            var userRatingsStatistics = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            userRatingsStatistics.Should().NotBeNull();
            userRatingsStatistics.Total.Should().Be(9257);
            userRatingsStatistics.Distribution.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserRatingsStatisticsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new UserRatingsStatisticsObjectJsonReader();

            var userRatingsStatistics = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

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

        [Fact]
        public async Task Test_UserRatingsStatisticsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new UserRatingsStatisticsObjectJsonReader();

            var userRatingsStatistics = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            userRatingsStatistics.Should().NotBeNull();
            userRatingsStatistics.Total.Should().Be(9257);
            userRatingsStatistics.Distribution.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserRatingsStatisticsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new UserRatingsStatisticsObjectJsonReader();

            var userRatingsStatistics = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            userRatingsStatistics.Should().NotBeNull();
            userRatingsStatistics.Total.Should().BeNull();
            userRatingsStatistics.Distribution.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserRatingsStatisticsObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new UserRatingsStatisticsObjectJsonReader();

            var userRatingsStatistics = await jsonReader.ReadObjectAsync(default(string));
            userRatingsStatistics.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserRatingsStatisticsObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new UserRatingsStatisticsObjectJsonReader();

            var userRatingsStatistics = await jsonReader.ReadObjectAsync(string.Empty);
            userRatingsStatistics.Should().BeNull();
        }
    }
}
