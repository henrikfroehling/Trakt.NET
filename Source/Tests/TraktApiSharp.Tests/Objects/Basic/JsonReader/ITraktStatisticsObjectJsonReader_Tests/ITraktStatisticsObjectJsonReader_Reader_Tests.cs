namespace TraktApiSharp.Tests.Objects.Basic.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Basic.JsonReader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class ITraktStatisticsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ITraktStatisticsObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new ITraktStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().Be(129920);
                traktStatistics.Plays.Should().Be(3563853);
                traktStatistics.Collectors.Should().Be(49711);
                traktStatistics.CollectedEpisodes.Should().Be(1310350);
                traktStatistics.Comments.Should().Be(96);
                traktStatistics.Lists.Should().Be(49468);
                traktStatistics.Votes.Should().Be(9274);
            }
        }

        [Fact]
        public async Task Test_ITraktStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new ITraktStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().BeNull();
                traktStatistics.Plays.Should().Be(3563853);
                traktStatistics.Collectors.Should().Be(49711);
                traktStatistics.CollectedEpisodes.Should().Be(1310350);
                traktStatistics.Comments.Should().Be(96);
                traktStatistics.Lists.Should().Be(49468);
                traktStatistics.Votes.Should().Be(9274);
            }
        }

        [Fact]
        public async Task Test_ITraktStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new ITraktStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().Be(129920);
                traktStatistics.Plays.Should().BeNull();
                traktStatistics.Collectors.Should().Be(49711);
                traktStatistics.CollectedEpisodes.Should().Be(1310350);
                traktStatistics.Comments.Should().Be(96);
                traktStatistics.Lists.Should().Be(49468);
                traktStatistics.Votes.Should().Be(9274);
            }
        }

        [Fact]
        public async Task Test_ITraktStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new ITraktStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().Be(129920);
                traktStatistics.Plays.Should().Be(3563853);
                traktStatistics.Collectors.Should().BeNull();
                traktStatistics.CollectedEpisodes.Should().Be(1310350);
                traktStatistics.Comments.Should().Be(96);
                traktStatistics.Lists.Should().Be(49468);
                traktStatistics.Votes.Should().Be(9274);
            }
        }

        [Fact]
        public async Task Test_ITraktStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new ITraktStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().Be(129920);
                traktStatistics.Plays.Should().Be(3563853);
                traktStatistics.Collectors.Should().Be(49711);
                traktStatistics.CollectedEpisodes.Should().BeNull();
                traktStatistics.Comments.Should().Be(96);
                traktStatistics.Lists.Should().Be(49468);
                traktStatistics.Votes.Should().Be(9274);
            }
        }

        [Fact]
        public async Task Test_ITraktStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new ITraktStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().Be(129920);
                traktStatistics.Plays.Should().Be(3563853);
                traktStatistics.Collectors.Should().Be(49711);
                traktStatistics.CollectedEpisodes.Should().Be(1310350);
                traktStatistics.Comments.Should().BeNull();
                traktStatistics.Lists.Should().Be(49468);
                traktStatistics.Votes.Should().Be(9274);
            }
        }

        [Fact]
        public async Task Test_ITraktStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new ITraktStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().Be(129920);
                traktStatistics.Plays.Should().Be(3563853);
                traktStatistics.Collectors.Should().Be(49711);
                traktStatistics.CollectedEpisodes.Should().Be(1310350);
                traktStatistics.Comments.Should().Be(96);
                traktStatistics.Lists.Should().BeNull();
                traktStatistics.Votes.Should().Be(9274);
            }
        }

        [Fact]
        public async Task Test_ITraktStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_7()
        {
            var traktJsonReader = new ITraktStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().Be(129920);
                traktStatistics.Plays.Should().Be(3563853);
                traktStatistics.Collectors.Should().Be(49711);
                traktStatistics.CollectedEpisodes.Should().Be(1310350);
                traktStatistics.Comments.Should().Be(96);
                traktStatistics.Lists.Should().Be(49468);
                traktStatistics.Votes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_8()
        {
            var traktJsonReader = new ITraktStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().Be(129920);
                traktStatistics.Plays.Should().BeNull();
                traktStatistics.Collectors.Should().BeNull();
                traktStatistics.CollectedEpisodes.Should().BeNull();
                traktStatistics.Comments.Should().BeNull();
                traktStatistics.Lists.Should().BeNull();
                traktStatistics.Votes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_9()
        {
            var traktJsonReader = new ITraktStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_9))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().BeNull();
                traktStatistics.Plays.Should().Be(3563853);
                traktStatistics.Collectors.Should().BeNull();
                traktStatistics.CollectedEpisodes.Should().BeNull();
                traktStatistics.Comments.Should().BeNull();
                traktStatistics.Lists.Should().BeNull();
                traktStatistics.Votes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_10()
        {
            var traktJsonReader = new ITraktStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_10))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().BeNull();
                traktStatistics.Plays.Should().BeNull();
                traktStatistics.Collectors.Should().Be(49711);
                traktStatistics.CollectedEpisodes.Should().BeNull();
                traktStatistics.Comments.Should().BeNull();
                traktStatistics.Lists.Should().BeNull();
                traktStatistics.Votes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_11()
        {
            var traktJsonReader = new ITraktStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_11))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().BeNull();
                traktStatistics.Plays.Should().BeNull();
                traktStatistics.Collectors.Should().BeNull();
                traktStatistics.CollectedEpisodes.Should().Be(1310350);
                traktStatistics.Comments.Should().BeNull();
                traktStatistics.Lists.Should().BeNull();
                traktStatistics.Votes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_12()
        {
            var traktJsonReader = new ITraktStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_12))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().BeNull();
                traktStatistics.Plays.Should().BeNull();
                traktStatistics.Collectors.Should().BeNull();
                traktStatistics.CollectedEpisodes.Should().BeNull();
                traktStatistics.Comments.Should().Be(96);
                traktStatistics.Lists.Should().BeNull();
                traktStatistics.Votes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_13()
        {
            var traktJsonReader = new ITraktStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_13))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().BeNull();
                traktStatistics.Plays.Should().BeNull();
                traktStatistics.Collectors.Should().BeNull();
                traktStatistics.CollectedEpisodes.Should().BeNull();
                traktStatistics.Comments.Should().BeNull();
                traktStatistics.Lists.Should().Be(49468);
                traktStatistics.Votes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_14()
        {
            var traktJsonReader = new ITraktStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_14))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().BeNull();
                traktStatistics.Plays.Should().BeNull();
                traktStatistics.Collectors.Should().BeNull();
                traktStatistics.CollectedEpisodes.Should().BeNull();
                traktStatistics.Comments.Should().BeNull();
                traktStatistics.Lists.Should().BeNull();
                traktStatistics.Votes.Should().Be(9274);
            }
        }

        [Fact]
        public async Task Test_ITraktStatisticsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new ITraktStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().BeNull();
                traktStatistics.Plays.Should().Be(3563853);
                traktStatistics.Collectors.Should().Be(49711);
                traktStatistics.CollectedEpisodes.Should().Be(1310350);
                traktStatistics.Comments.Should().Be(96);
                traktStatistics.Lists.Should().Be(49468);
                traktStatistics.Votes.Should().Be(9274);
            }
        }

        [Fact]
        public async Task Test_ITraktStatisticsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new ITraktStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().Be(129920);
                traktStatistics.Plays.Should().BeNull();
                traktStatistics.Collectors.Should().Be(49711);
                traktStatistics.CollectedEpisodes.Should().Be(1310350);
                traktStatistics.Comments.Should().Be(96);
                traktStatistics.Lists.Should().Be(49468);
                traktStatistics.Votes.Should().Be(9274);
            }
        }

        [Fact]
        public async Task Test_ITraktStatisticsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new ITraktStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().Be(129920);
                traktStatistics.Plays.Should().Be(3563853);
                traktStatistics.Collectors.Should().BeNull();
                traktStatistics.CollectedEpisodes.Should().Be(1310350);
                traktStatistics.Comments.Should().Be(96);
                traktStatistics.Lists.Should().Be(49468);
                traktStatistics.Votes.Should().Be(9274);
            }
        }

        [Fact]
        public async Task Test_ITraktStatisticsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new ITraktStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().Be(129920);
                traktStatistics.Plays.Should().Be(3563853);
                traktStatistics.Collectors.Should().Be(49711);
                traktStatistics.CollectedEpisodes.Should().BeNull();
                traktStatistics.Comments.Should().Be(96);
                traktStatistics.Lists.Should().Be(49468);
                traktStatistics.Votes.Should().Be(9274);
            }
        }

        [Fact]
        public async Task Test_ITraktStatisticsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new ITraktStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().Be(129920);
                traktStatistics.Plays.Should().Be(3563853);
                traktStatistics.Collectors.Should().Be(49711);
                traktStatistics.CollectedEpisodes.Should().Be(1310350);
                traktStatistics.Comments.Should().BeNull();
                traktStatistics.Lists.Should().Be(49468);
                traktStatistics.Votes.Should().Be(9274);
            }
        }

        [Fact]
        public async Task Test_ITraktStatisticsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_6()
        {
            var traktJsonReader = new ITraktStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().Be(129920);
                traktStatistics.Plays.Should().Be(3563853);
                traktStatistics.Collectors.Should().Be(49711);
                traktStatistics.CollectedEpisodes.Should().Be(1310350);
                traktStatistics.Comments.Should().Be(96);
                traktStatistics.Lists.Should().BeNull();
                traktStatistics.Votes.Should().Be(9274);
            }
        }

        [Fact]
        public async Task Test_ITraktStatisticsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_7()
        {
            var traktJsonReader = new ITraktStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().Be(129920);
                traktStatistics.Plays.Should().Be(3563853);
                traktStatistics.Collectors.Should().Be(49711);
                traktStatistics.CollectedEpisodes.Should().Be(1310350);
                traktStatistics.Comments.Should().Be(96);
                traktStatistics.Lists.Should().Be(49468);
                traktStatistics.Votes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktStatisticsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_8()
        {
            var traktJsonReader = new ITraktStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().BeNull();
                traktStatistics.Plays.Should().BeNull();
                traktStatistics.Collectors.Should().BeNull();
                traktStatistics.CollectedEpisodes.Should().BeNull();
                traktStatistics.Comments.Should().BeNull();
                traktStatistics.Lists.Should().BeNull();
                traktStatistics.Votes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktStatisticsObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new ITraktStatisticsObjectJsonReader();

            var traktStatistics = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            traktStatistics.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktStatisticsObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new ITraktStatisticsObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktStatistics.Should().BeNull();
            }
        }
    }
}
