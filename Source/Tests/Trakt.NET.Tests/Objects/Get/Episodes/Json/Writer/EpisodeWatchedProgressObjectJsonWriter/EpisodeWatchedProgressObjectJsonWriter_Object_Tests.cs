namespace TraktNet.Tests.Objects.Get.Episodes.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Traits;
    using TraktNet.Extensions;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.Episodes.Json.Writer;
    using Xunit;

    [Category("Objects.Get.Episodes.JsonWriter")]
    public partial class EpisodeWatchedProgressObjectJsonWriter_Tests
    {
        [Fact]
        public void Test_EpisodeWatchedProgressObjectJsonWriter_WriteObject_Object_Exceptions()
        {
            var traktJsonWriter = new EpisodeWatchedProgressObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default(ITraktEpisodeWatchedProgress));
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_EpisodeWatchedProgressObjectJsonWriter_WriteObject_Object_Only_Number_Property()
        {
            ITraktEpisodeWatchedProgress traktEpisodeWatchedProgress = new TraktEpisodeWatchedProgress
            {
                Number = 1
            };

            var traktJsonWriter = new EpisodeWatchedProgressObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktEpisodeWatchedProgress);
            json.Should().Be(@"{""number"":1}");
        }

        [Fact]
        public async Task Test_EpisodeWatchedProgressObjectJsonWriter_WriteObject_Object_Only_Completed_Property()
        {
            ITraktEpisodeWatchedProgress traktEpisodeWatchedProgress = new TraktEpisodeWatchedProgress
            {
                Completed = true
            };

            var traktJsonWriter = new EpisodeWatchedProgressObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktEpisodeWatchedProgress);
            json.Should().Be(@"{""completed"":true}");
        }

        [Fact]
        public async Task Test_EpisodeWatchedProgressObjectJsonWriter_WriteObject_Object_Only_LastWatchedAt_Property()
        {
            ITraktEpisodeWatchedProgress traktEpisodeWatchedProgress = new TraktEpisodeWatchedProgress
            {
                LastWatchedAt = LAST_WATCHED_AT
            };

            var traktJsonWriter = new EpisodeWatchedProgressObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktEpisodeWatchedProgress);
            json.Should().Be($"{{\"last_watched_at\":\"{LAST_WATCHED_AT.ToTraktLongDateTimeString()}\"}}");
        }

        [Fact]
        public async Task Test_EpisodeWatchedProgressObjectJsonWriter_WriteObject_Object_Complete()
        {
            ITraktEpisodeWatchedProgress traktEpisodeWatchedProgress = new TraktEpisodeWatchedProgress
            {
                Number = 1,
                Completed = true,
                LastWatchedAt = LAST_WATCHED_AT
            };

            var traktJsonWriter = new EpisodeWatchedProgressObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktEpisodeWatchedProgress);
            json.Should().Be(@"{""number"":1,""completed"":true," +
                             $"\"last_watched_at\":\"{LAST_WATCHED_AT.ToTraktLongDateTimeString()}\"}}");
        }
    }
}
