namespace TraktApiSharp.Tests.Objects.Basic.JsonReader
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Basic.JsonReader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class ITraktStatisticsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ITraktStatisticsObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new ITraktStatisticsObjectJsonReader();

            var traktStatistics = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktStatistics.Should().NotBeNull();
            traktStatistics.Watchers.Should().Be(129920);
            traktStatistics.Plays.Should().Be(3563853);
            traktStatistics.Collectors.Should().Be(49711);
            traktStatistics.CollectedEpisodes.Should().Be(1310350);
            traktStatistics.Comments.Should().Be(96);
            traktStatistics.Lists.Should().Be(49468);
            traktStatistics.Votes.Should().Be(9274);
        }

        [Fact]
        public async Task Test_ITraktStatisticsObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new ITraktStatisticsObjectJsonReader();

            var traktStatistics = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            traktStatistics.Should().NotBeNull();
            traktStatistics.Watchers.Should().BeNull();
            traktStatistics.Plays.Should().Be(3563853);
            traktStatistics.Collectors.Should().Be(49711);
            traktStatistics.CollectedEpisodes.Should().Be(1310350);
            traktStatistics.Comments.Should().Be(96);
            traktStatistics.Lists.Should().Be(49468);
            traktStatistics.Votes.Should().Be(9274);
        }

        [Fact]
        public async Task Test_ITraktStatisticsObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new ITraktStatisticsObjectJsonReader();

            var traktStatistics = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            traktStatistics.Should().NotBeNull();
            traktStatistics.Watchers.Should().Be(129920);
            traktStatistics.Plays.Should().BeNull();
            traktStatistics.Collectors.Should().Be(49711);
            traktStatistics.CollectedEpisodes.Should().Be(1310350);
            traktStatistics.Comments.Should().Be(96);
            traktStatistics.Lists.Should().Be(49468);
            traktStatistics.Votes.Should().Be(9274);
        }

        [Fact]
        public async Task Test_ITraktStatisticsObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new ITraktStatisticsObjectJsonReader();

            var traktStatistics = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_3);

            traktStatistics.Should().NotBeNull();
            traktStatistics.Watchers.Should().Be(129920);
            traktStatistics.Plays.Should().Be(3563853);
            traktStatistics.Collectors.Should().BeNull();
            traktStatistics.CollectedEpisodes.Should().Be(1310350);
            traktStatistics.Comments.Should().Be(96);
            traktStatistics.Lists.Should().Be(49468);
            traktStatistics.Votes.Should().Be(9274);
        }

        [Fact]
        public async Task Test_ITraktStatisticsObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new ITraktStatisticsObjectJsonReader();

            var traktStatistics = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_4);

            traktStatistics.Should().NotBeNull();
            traktStatistics.Watchers.Should().Be(129920);
            traktStatistics.Plays.Should().Be(3563853);
            traktStatistics.Collectors.Should().Be(49711);
            traktStatistics.CollectedEpisodes.Should().BeNull();
            traktStatistics.Comments.Should().Be(96);
            traktStatistics.Lists.Should().Be(49468);
            traktStatistics.Votes.Should().Be(9274);
        }

        [Fact]
        public async Task Test_ITraktStatisticsObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new ITraktStatisticsObjectJsonReader();

            var traktStatistics = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_5);

            traktStatistics.Should().NotBeNull();
            traktStatistics.Watchers.Should().Be(129920);
            traktStatistics.Plays.Should().Be(3563853);
            traktStatistics.Collectors.Should().Be(49711);
            traktStatistics.CollectedEpisodes.Should().Be(1310350);
            traktStatistics.Comments.Should().BeNull();
            traktStatistics.Lists.Should().Be(49468);
            traktStatistics.Votes.Should().Be(9274);
        }

        [Fact]
        public async Task Test_ITraktStatisticsObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new ITraktStatisticsObjectJsonReader();

            var traktStatistics = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_6);

            traktStatistics.Should().NotBeNull();
            traktStatistics.Watchers.Should().Be(129920);
            traktStatistics.Plays.Should().Be(3563853);
            traktStatistics.Collectors.Should().Be(49711);
            traktStatistics.CollectedEpisodes.Should().Be(1310350);
            traktStatistics.Comments.Should().Be(96);
            traktStatistics.Lists.Should().BeNull();
            traktStatistics.Votes.Should().Be(9274);
        }

        [Fact]
        public async Task Test_ITraktStatisticsObjectJsonReader_ReadObject_From_Json_String_Incomplete_7()
        {
            var jsonReader = new ITraktStatisticsObjectJsonReader();

            var traktStatistics = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_7);

            traktStatistics.Should().NotBeNull();
            traktStatistics.Watchers.Should().Be(129920);
            traktStatistics.Plays.Should().Be(3563853);
            traktStatistics.Collectors.Should().Be(49711);
            traktStatistics.CollectedEpisodes.Should().Be(1310350);
            traktStatistics.Comments.Should().Be(96);
            traktStatistics.Lists.Should().Be(49468);
            traktStatistics.Votes.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktStatisticsObjectJsonReader_ReadObject_From_Json_String_Incomplete_8()
        {
            var jsonReader = new ITraktStatisticsObjectJsonReader();

            var traktStatistics = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_8);

            traktStatistics.Should().NotBeNull();
            traktStatistics.Watchers.Should().Be(129920);
            traktStatistics.Plays.Should().BeNull();
            traktStatistics.Collectors.Should().BeNull();
            traktStatistics.CollectedEpisodes.Should().BeNull();
            traktStatistics.Comments.Should().BeNull();
            traktStatistics.Lists.Should().BeNull();
            traktStatistics.Votes.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktStatisticsObjectJsonReader_ReadObject_From_Json_String_Incomplete_9()
        {
            var jsonReader = new ITraktStatisticsObjectJsonReader();

            var traktStatistics = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_9);

            traktStatistics.Should().NotBeNull();
            traktStatistics.Watchers.Should().BeNull();
            traktStatistics.Plays.Should().Be(3563853);
            traktStatistics.Collectors.Should().BeNull();
            traktStatistics.CollectedEpisodes.Should().BeNull();
            traktStatistics.Comments.Should().BeNull();
            traktStatistics.Lists.Should().BeNull();
            traktStatistics.Votes.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktStatisticsObjectJsonReader_ReadObject_From_Json_String_Incomplete_10()
        {
            var jsonReader = new ITraktStatisticsObjectJsonReader();

            var traktStatistics = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_10);

            traktStatistics.Should().NotBeNull();
            traktStatistics.Watchers.Should().BeNull();
            traktStatistics.Plays.Should().BeNull();
            traktStatistics.Collectors.Should().Be(49711);
            traktStatistics.CollectedEpisodes.Should().BeNull();
            traktStatistics.Comments.Should().BeNull();
            traktStatistics.Lists.Should().BeNull();
            traktStatistics.Votes.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktStatisticsObjectJsonReader_ReadObject_From_Json_String_Incomplete_11()
        {
            var jsonReader = new ITraktStatisticsObjectJsonReader();

            var traktStatistics = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_11);

            traktStatistics.Should().NotBeNull();
            traktStatistics.Watchers.Should().BeNull();
            traktStatistics.Plays.Should().BeNull();
            traktStatistics.Collectors.Should().BeNull();
            traktStatistics.CollectedEpisodes.Should().Be(1310350);
            traktStatistics.Comments.Should().BeNull();
            traktStatistics.Lists.Should().BeNull();
            traktStatistics.Votes.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktStatisticsObjectJsonReader_ReadObject_From_Json_String_Incomplete_12()
        {
            var jsonReader = new ITraktStatisticsObjectJsonReader();

            var traktStatistics = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_12);

            traktStatistics.Should().NotBeNull();
            traktStatistics.Watchers.Should().BeNull();
            traktStatistics.Plays.Should().BeNull();
            traktStatistics.Collectors.Should().BeNull();
            traktStatistics.CollectedEpisodes.Should().BeNull();
            traktStatistics.Comments.Should().Be(96);
            traktStatistics.Lists.Should().BeNull();
            traktStatistics.Votes.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktStatisticsObjectJsonReader_ReadObject_From_Json_String_Incomplete_13()
        {
            var jsonReader = new ITraktStatisticsObjectJsonReader();

            var traktStatistics = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_13);

            traktStatistics.Should().NotBeNull();
            traktStatistics.Watchers.Should().BeNull();
            traktStatistics.Plays.Should().BeNull();
            traktStatistics.Collectors.Should().BeNull();
            traktStatistics.CollectedEpisodes.Should().BeNull();
            traktStatistics.Comments.Should().BeNull();
            traktStatistics.Lists.Should().Be(49468);
            traktStatistics.Votes.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktStatisticsObjectJsonReader_ReadObject_From_Json_String_Incomplete_14()
        {
            var jsonReader = new ITraktStatisticsObjectJsonReader();

            var traktStatistics = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_14);

            traktStatistics.Should().NotBeNull();
            traktStatistics.Watchers.Should().BeNull();
            traktStatistics.Plays.Should().BeNull();
            traktStatistics.Collectors.Should().BeNull();
            traktStatistics.CollectedEpisodes.Should().BeNull();
            traktStatistics.Comments.Should().BeNull();
            traktStatistics.Lists.Should().BeNull();
            traktStatistics.Votes.Should().Be(9274);
        }

        [Fact]
        public async Task Test_ITraktStatisticsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new ITraktStatisticsObjectJsonReader();

            var traktStatistics = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            traktStatistics.Should().NotBeNull();
            traktStatistics.Watchers.Should().BeNull();
            traktStatistics.Plays.Should().Be(3563853);
            traktStatistics.Collectors.Should().Be(49711);
            traktStatistics.CollectedEpisodes.Should().Be(1310350);
            traktStatistics.Comments.Should().Be(96);
            traktStatistics.Lists.Should().Be(49468);
            traktStatistics.Votes.Should().Be(9274);
        }

        [Fact]
        public async Task Test_ITraktStatisticsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new ITraktStatisticsObjectJsonReader();

            var traktStatistics = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            traktStatistics.Should().NotBeNull();
            traktStatistics.Watchers.Should().Be(129920);
            traktStatistics.Plays.Should().BeNull();
            traktStatistics.Collectors.Should().Be(49711);
            traktStatistics.CollectedEpisodes.Should().Be(1310350);
            traktStatistics.Comments.Should().Be(96);
            traktStatistics.Lists.Should().Be(49468);
            traktStatistics.Votes.Should().Be(9274);
        }

        [Fact]
        public async Task Test_ITraktStatisticsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new ITraktStatisticsObjectJsonReader();

            var traktStatistics = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            traktStatistics.Should().NotBeNull();
            traktStatistics.Watchers.Should().Be(129920);
            traktStatistics.Plays.Should().Be(3563853);
            traktStatistics.Collectors.Should().BeNull();
            traktStatistics.CollectedEpisodes.Should().Be(1310350);
            traktStatistics.Comments.Should().Be(96);
            traktStatistics.Lists.Should().Be(49468);
            traktStatistics.Votes.Should().Be(9274);
        }

        [Fact]
        public async Task Test_ITraktStatisticsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new ITraktStatisticsObjectJsonReader();

            var traktStatistics = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_4);

            traktStatistics.Should().NotBeNull();
            traktStatistics.Watchers.Should().Be(129920);
            traktStatistics.Plays.Should().Be(3563853);
            traktStatistics.Collectors.Should().Be(49711);
            traktStatistics.CollectedEpisodes.Should().BeNull();
            traktStatistics.Comments.Should().Be(96);
            traktStatistics.Lists.Should().Be(49468);
            traktStatistics.Votes.Should().Be(9274);
        }

        [Fact]
        public async Task Test_ITraktStatisticsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_5()
        {
            var jsonReader = new ITraktStatisticsObjectJsonReader();

            var traktStatistics = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_5);

            traktStatistics.Should().NotBeNull();
            traktStatistics.Watchers.Should().Be(129920);
            traktStatistics.Plays.Should().Be(3563853);
            traktStatistics.Collectors.Should().Be(49711);
            traktStatistics.CollectedEpisodes.Should().Be(1310350);
            traktStatistics.Comments.Should().BeNull();
            traktStatistics.Lists.Should().Be(49468);
            traktStatistics.Votes.Should().Be(9274);
        }

        [Fact]
        public async Task Test_ITraktStatisticsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_6()
        {
            var jsonReader = new ITraktStatisticsObjectJsonReader();

            var traktStatistics = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_6);

            traktStatistics.Should().NotBeNull();
            traktStatistics.Watchers.Should().Be(129920);
            traktStatistics.Plays.Should().Be(3563853);
            traktStatistics.Collectors.Should().Be(49711);
            traktStatistics.CollectedEpisodes.Should().Be(1310350);
            traktStatistics.Comments.Should().Be(96);
            traktStatistics.Lists.Should().BeNull();
            traktStatistics.Votes.Should().Be(9274);
        }

        [Fact]
        public async Task Test_ITraktStatisticsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_7()
        {
            var jsonReader = new ITraktStatisticsObjectJsonReader();

            var traktStatistics = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_7);

            traktStatistics.Should().NotBeNull();
            traktStatistics.Watchers.Should().Be(129920);
            traktStatistics.Plays.Should().Be(3563853);
            traktStatistics.Collectors.Should().Be(49711);
            traktStatistics.CollectedEpisodes.Should().Be(1310350);
            traktStatistics.Comments.Should().Be(96);
            traktStatistics.Lists.Should().Be(49468);
            traktStatistics.Votes.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktStatisticsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_8()
        {
            var jsonReader = new ITraktStatisticsObjectJsonReader();

            var traktStatistics = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_8);

            traktStatistics.Should().NotBeNull();
            traktStatistics.Watchers.Should().BeNull();
            traktStatistics.Plays.Should().BeNull();
            traktStatistics.Collectors.Should().BeNull();
            traktStatistics.CollectedEpisodes.Should().BeNull();
            traktStatistics.Comments.Should().BeNull();
            traktStatistics.Lists.Should().BeNull();
            traktStatistics.Votes.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktStatisticsObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new ITraktStatisticsObjectJsonReader();

            var traktStatistics = await jsonReader.ReadObjectAsync(default(string));
            traktStatistics.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktStatisticsObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new ITraktStatisticsObjectJsonReader();

            var traktStatistics = await jsonReader.ReadObjectAsync(string.Empty);
            traktStatistics.Should().BeNull();
        }
    }
}
