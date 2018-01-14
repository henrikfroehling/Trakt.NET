namespace TraktApiSharp.Tests.Objects.Get.Episodes.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Extensions;
    using TraktApiSharp.Objects.Get.Episodes;
    using TraktApiSharp.Objects.Get.Episodes.Implementations;
    using TraktApiSharp.Objects.Get.Episodes.Json.Writer;
    using Xunit;

    [Category("Objects.Get.Episodes.JsonWriter")]
    public partial class EpisodeWatchedProgressObjectJsonWriter_Tests
    {
        [Fact]
        public void Test_EpisodeWatchedProgressObjectJsonWriter_WriteObject_StringWriter_Exceptions()
        {
            var traktJsonWriter = new EpisodeWatchedProgressObjectJsonWriter();
            ITraktEpisodeWatchedProgress traktEpisodeWatchedProgress = new TraktEpisodeWatchedProgress();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default(StringWriter), traktEpisodeWatchedProgress);
            action.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_EpisodeWatchedProgressObjectJsonWriter_WriteObject_StringWriter_Only_Number_Property()
        {
            ITraktEpisodeWatchedProgress traktEpisodeWatchedProgress = new TraktEpisodeWatchedProgress
            {
                Number = 1
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new EpisodeWatchedProgressObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktEpisodeWatchedProgress);
                json.Should().Be(@"{""number"":1}");
            }
        }

        [Fact]
        public async Task Test_EpisodeWatchedProgressObjectJsonWriter_WriteObject_StringWriter_Only_Completed_Property()
        {
            ITraktEpisodeWatchedProgress traktEpisodeWatchedProgress = new TraktEpisodeWatchedProgress
            {
                Completed = true
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new EpisodeWatchedProgressObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktEpisodeWatchedProgress);
                json.Should().Be(@"{""completed"":true}");
            }
        }

        [Fact]
        public async Task Test_EpisodeWatchedProgressObjectJsonWriter_WriteObject_StringWriter_Only_LastWatchedAt_Property()
        {
            ITraktEpisodeWatchedProgress traktEpisodeWatchedProgress = new TraktEpisodeWatchedProgress
            {
                LastWatchedAt = LAST_WATCHED_AT
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new EpisodeWatchedProgressObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktEpisodeWatchedProgress);
                json.Should().Be($"{{\"last_watched_at\":\"{LAST_WATCHED_AT.ToTraktLongDateTimeString()}\"}}");
            }
        }

        [Fact]
        public async Task Test_EpisodeWatchedProgressObjectJsonWriter_WriteObject_StringWriter_Complete()
        {
            ITraktEpisodeWatchedProgress traktEpisodeWatchedProgress = new TraktEpisodeWatchedProgress
            {
                Number = 1,
                Completed = true,
                LastWatchedAt = LAST_WATCHED_AT
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new EpisodeWatchedProgressObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktEpisodeWatchedProgress);
                json.Should().Be(@"{""number"":1,""completed"":true," +
                                 $"\"last_watched_at\":\"{LAST_WATCHED_AT.ToTraktLongDateTimeString()}\"}}");
            }
        }
    }
}
