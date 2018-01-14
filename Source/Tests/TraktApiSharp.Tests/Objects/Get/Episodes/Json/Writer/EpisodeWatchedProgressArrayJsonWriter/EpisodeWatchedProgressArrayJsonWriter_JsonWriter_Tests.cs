namespace TraktApiSharp.Tests.Objects.Get.Episodes.Json.Writer
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Extensions;
    using TraktApiSharp.Objects.Get.Episodes;
    using TraktApiSharp.Objects.Get.Episodes.Implementations;
    using TraktApiSharp.Objects.Get.Episodes.Json.Writer;
    using Xunit;

    [Category("Objects.Get.Episodes.JsonWriter")]
    public partial class EpisodeWatchedProgressArrayJsonWriter_Tests
    {
        private static readonly DateTime LAST_WATCHED_AT = DateTime.UtcNow;

        [Fact]
        public void Test_EpisodeWatchedProgressArrayJsonWriter_WriteArray_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new EpisodeWatchedProgressArrayJsonWriter();
            IEnumerable<ITraktEpisodeWatchedProgress> traktEpisodeWatchedProgresss = new List<TraktEpisodeWatchedProgress>();
            Func<Task> action = () => traktJsonWriter.WriteArrayAsync(default(JsonTextWriter), traktEpisodeWatchedProgresss);
            action.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_EpisodeWatchedProgressArrayJsonWriter_WriteArray_JsonWriter_Empty()
        {
            IEnumerable<ITraktEpisodeWatchedProgress> traktEpisodeWatchedProgresss = new List<TraktEpisodeWatchedProgress>();

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new EpisodeWatchedProgressArrayJsonWriter();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktEpisodeWatchedProgresss);
                stringWriter.ToString().Should().Be("[]");
            }
        }

        [Fact]
        public async Task Test_EpisodeWatchedProgressArrayJsonWriter_WriteArray_JsonWriter_SingleObject()
        {
            IEnumerable<ITraktEpisodeWatchedProgress> traktEpisodeWatchedProgresss = new List<ITraktEpisodeWatchedProgress>
            {
                new TraktEpisodeWatchedProgress
                {
                    Number = 1,
                    Completed = true,
                    LastWatchedAt = LAST_WATCHED_AT
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new EpisodeWatchedProgressArrayJsonWriter();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktEpisodeWatchedProgresss);
                stringWriter.ToString().Should().Be($"[{{\"number\":1,\"completed\":true,\"last_watched_at\":\"{LAST_WATCHED_AT.ToTraktLongDateTimeString()}\"}}]");
            }
        }

        [Fact]
        public async Task Test_EpisodeWatchedProgressArrayJsonWriter_WriteArray_JsonWriter_Complete()
        {
            IEnumerable<ITraktEpisodeWatchedProgress> traktEpisodeWatchedProgresss = new List<ITraktEpisodeWatchedProgress>
            {
                new TraktEpisodeWatchedProgress
                {
                    Number = 1,
                    Completed = true,
                    LastWatchedAt = LAST_WATCHED_AT
                },
                new TraktEpisodeWatchedProgress
                {
                    Number = 2,
                    Completed = true,
                    LastWatchedAt = LAST_WATCHED_AT
                },
                new TraktEpisodeWatchedProgress
                {
                    Number = 3,
                    Completed = true,
                    LastWatchedAt = LAST_WATCHED_AT
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new EpisodeWatchedProgressArrayJsonWriter();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktEpisodeWatchedProgresss);
                stringWriter.ToString().Should().Be($"[{{\"number\":1,\"completed\":true,\"last_watched_at\":\"{LAST_WATCHED_AT.ToTraktLongDateTimeString()}\"}}," +
                                                    $"{{\"number\":2,\"completed\":true,\"last_watched_at\":\"{LAST_WATCHED_AT.ToTraktLongDateTimeString()}\"}}," +
                                                    $"{{\"number\":3,\"completed\":true,\"last_watched_at\":\"{LAST_WATCHED_AT.ToTraktLongDateTimeString()}\"}}]");
            }
        }
    }
}
