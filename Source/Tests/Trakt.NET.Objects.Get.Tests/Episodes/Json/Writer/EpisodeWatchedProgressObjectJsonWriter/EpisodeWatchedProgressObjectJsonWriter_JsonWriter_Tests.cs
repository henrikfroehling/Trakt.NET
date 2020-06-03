namespace TraktNet.Objects.Get.Tests.Episodes.Json.Writer
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Extensions;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.Episodes.Json.Writer;
    using Xunit;

    [Category("Objects.Get.Episodes.JsonWriter")]
    public partial class EpisodeWatchedProgressObjectJsonWriter_Tests
    {
        private static readonly DateTime LAST_WATCHED_AT = DateTime.UtcNow;

        [Fact]
        public void Test_EpisodeWatchedProgressObjectJsonWriter_WriteObject_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new EpisodeWatchedProgressObjectJsonWriter();
            ITraktEpisodeWatchedProgress traktEpisodeWatchedProgress = new TraktEpisodeWatchedProgress();
            Func<Task> action = () => traktJsonWriter.WriteObjectAsync(default(JsonTextWriter), traktEpisodeWatchedProgress);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_EpisodeWatchedProgressObjectJsonWriter_WriteObject_JsonWriter_Only_Number_Property()
        {
            ITraktEpisodeWatchedProgress traktEpisodeWatchedProgress = new TraktEpisodeWatchedProgress
            {
                Number = 1
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new EpisodeWatchedProgressObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktEpisodeWatchedProgress);
                stringWriter.ToString().Should().Be(@"{""number"":1}");
            }
        }

        [Fact]
        public async Task Test_EpisodeWatchedProgressObjectJsonWriter_WriteObject_JsonWriter_Only_Completed_Property()
        {
            ITraktEpisodeWatchedProgress traktEpisodeWatchedProgress = new TraktEpisodeWatchedProgress
            {
                Completed = true
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new EpisodeWatchedProgressObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktEpisodeWatchedProgress);
                stringWriter.ToString().Should().Be(@"{""completed"":true}");
            }
        }

        [Fact]
        public async Task Test_EpisodeWatchedProgressObjectJsonWriter_WriteObject_JsonWriter_Only_LastWatchedAt_Property()
        {
            ITraktEpisodeWatchedProgress traktEpisodeWatchedProgress = new TraktEpisodeWatchedProgress
            {
                LastWatchedAt = LAST_WATCHED_AT
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new EpisodeWatchedProgressObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktEpisodeWatchedProgress);
                stringWriter.ToString().Should().Be($"{{\"last_watched_at\":\"{LAST_WATCHED_AT.ToTraktLongDateTimeString()}\"}}");
            }
        }

        [Fact]
        public async Task Test_EpisodeWatchedProgressObjectJsonWriter_WriteObject_JsonWriter_Complete()
        {
            ITraktEpisodeWatchedProgress traktEpisodeWatchedProgress = new TraktEpisodeWatchedProgress
            {
                Number = 1,
                Completed = true,
                LastWatchedAt = LAST_WATCHED_AT
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new EpisodeWatchedProgressObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktEpisodeWatchedProgress);
                stringWriter.ToString().Should().Be(@"{""number"":1,""completed"":true," +
                                                    $"\"last_watched_at\":\"{LAST_WATCHED_AT.ToTraktLongDateTimeString()}\"}}");
            }
        }
    }
}
