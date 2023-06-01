namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Basic.JsonReader")]
    public partial class CommentUserStatsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_CommentUserStatsObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new CommentUserStatsObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCommentUserStats = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCommentUserStats.Should().NotBeNull();
                traktCommentUserStats.Rating.Should().Be(8);
                traktCommentUserStats.PlayCount.Should().Be(1);
                traktCommentUserStats.CompletedCount.Should().Be(1);
            }
        }

        [Fact]
        public async Task Test_CommentUserStatsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new CommentUserStatsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCommentUserStats = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCommentUserStats.Should().NotBeNull();
                traktCommentUserStats.Rating.Should().BeNull();
                traktCommentUserStats.PlayCount.Should().Be(1);
                traktCommentUserStats.CompletedCount.Should().Be(1);
            }
        }

        [Fact]
        public async Task Test_CommentUserStatsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new CommentUserStatsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCommentUserStats = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCommentUserStats.Should().NotBeNull();
                traktCommentUserStats.Rating.Should().Be(8);
                traktCommentUserStats.PlayCount.Should().BeNull();
                traktCommentUserStats.CompletedCount.Should().Be(1);
            }
        }

        [Fact]
        public async Task Test_CommentUserStatsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new CommentUserStatsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCommentUserStats = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCommentUserStats.Should().NotBeNull();
                traktCommentUserStats.Rating.Should().Be(8);
                traktCommentUserStats.PlayCount.Should().Be(1);
                traktCommentUserStats.CompletedCount.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CommentUserStatsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new CommentUserStatsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCommentUserStats = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCommentUserStats.Should().NotBeNull();
                traktCommentUserStats.Rating.Should().BeNull();
                traktCommentUserStats.PlayCount.Should().Be(1);
                traktCommentUserStats.CompletedCount.Should().Be(1);
            }
        }

        [Fact]
        public async Task Test_CommentUserStatsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new CommentUserStatsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCommentUserStats = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCommentUserStats.Should().NotBeNull();
                traktCommentUserStats.Rating.Should().Be(8);
                traktCommentUserStats.PlayCount.Should().BeNull();
                traktCommentUserStats.CompletedCount.Should().Be(1);
            }
        }

        [Fact]
        public async Task Test_CommentUserStatsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new CommentUserStatsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCommentUserStats = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCommentUserStats.Should().NotBeNull();
                traktCommentUserStats.Rating.Should().Be(8);
                traktCommentUserStats.PlayCount.Should().Be(1);
                traktCommentUserStats.CompletedCount.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CommentUserStatsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new CommentUserStatsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCommentUserStats = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCommentUserStats.Should().NotBeNull();
                traktCommentUserStats.Rating.Should().BeNull();
                traktCommentUserStats.PlayCount.Should().BeNull();
                traktCommentUserStats.CompletedCount.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CommentUserStatsObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new CommentUserStatsObjectJsonReader();
            Func<Task<ITraktCommentUserStats>> traktCommentUserStats = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await traktCommentUserStats.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CommentUserStatsObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new CommentUserStatsObjectJsonReader();
            using var reader = new StringReader(string.Empty);
            using var jsonReader = new JsonTextReader(reader);
            var traktCommentUserStats = await traktJsonReader.ReadObjectAsync(jsonReader);
            traktCommentUserStats.Should().BeNull();
        }
    }
}
