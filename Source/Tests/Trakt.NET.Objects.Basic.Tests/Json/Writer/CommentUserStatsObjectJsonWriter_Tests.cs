namespace TraktNet.Objects.Basic.Tests.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Writer;
    using Xunit;

    [TestCategory("Objects.Basic.JsonWriter")]
    public partial class CommentUserStatsObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_CommentUserStatsObjectJsonWriter_WriteObject_Object_Exceptions()
        {
            var traktJsonWriter = new CommentUserStatsObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CommentUserStatsObjectJsonWriter_WriteObject_Object_Empty()
        {
            ITraktCommentUserStats traktCommentUserStats = new TraktCommentUserStats();

            var traktJsonWriter = new CommentUserStatsObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktCommentUserStats);
            json.Should().Be(@"{}");
        }

        [Fact]
        public async Task Test_CommentUserStatsObjectJsonWriter_WriteObject_Object_Only_Rating_Property()
        {
            ITraktCommentUserStats traktCommentUserStats = new TraktCommentUserStats
            {
                Rating = 8
            };

            var traktJsonWriter = new CommentUserStatsObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktCommentUserStats);
            json.Should().Be(@"{""rating"":8}");
        }

        [Fact]
        public async Task Test_CommentUserStatsObjectJsonWriter_WriteObject_Object_Only_PlayCount_Property()
        {
            ITraktCommentUserStats traktCommentUserStats = new TraktCommentUserStats
            {
                PlayCount = 1
            };

            var traktJsonWriter = new CommentUserStatsObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktCommentUserStats);
            json.Should().Be(@"{""play_count"":1}");
        }

        [Fact]
        public async Task Test_CommentUserStatsObjectJsonWriter_WriteObject_Object_Only_CompletedCount_Property()
        {
            ITraktCommentUserStats traktCommentUserStats = new TraktCommentUserStats
            {
                CompletedCount = 1
            };

            var traktJsonWriter = new CommentUserStatsObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktCommentUserStats);
            json.Should().Be(@"{""completed_count"":1}");
        }

        [Fact]
        public async Task Test_CommentUserStatsObjectJsonWriter_WriteObject_Object_Complete()
        {
            ITraktCommentUserStats traktCommentUserStats = new TraktCommentUserStats
            {
                Rating = 8,
                PlayCount = 1,
                CompletedCount = 1
            };

            var traktJsonWriter = new CommentUserStatsObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktCommentUserStats);
            json.Should().Be(@"{""rating"":8,""play_count"":1,""completed_count"":1}");
        }
    }
}
