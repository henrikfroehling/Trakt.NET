namespace TraktNet.Tests.Objects.Get.Episodes.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktNet.Extensions;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Get.Episodes.JsonWriter")]
    public partial class EpisodeWatchedProgressArrayJsonWriter_Tests
    {
        [Fact]
        public void Test_EpisodeWatchedProgressArrayJsonWriter_WriteArray_StringWriter_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktEpisodeWatchedProgress>();
            IEnumerable<ITraktEpisodeWatchedProgress> traktEpisodeWatchedProgresss = new List<TraktEpisodeWatchedProgress>();
            Func<Task<string>> action = () => traktJsonWriter.WriteArrayAsync(default(StringWriter), traktEpisodeWatchedProgresss);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_EpisodeWatchedProgressArrayJsonWriter_WriteArray_StringWriter_Empty()
        {
            IEnumerable<ITraktEpisodeWatchedProgress> traktEpisodeWatchedProgresss = new List<TraktEpisodeWatchedProgress>();

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktEpisodeWatchedProgress>();
                string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktEpisodeWatchedProgresss);
                json.Should().Be("[]");
            }
        }

        [Fact]
        public async Task Test_EpisodeWatchedProgressArrayJsonWriter_WriteArray_StringWriter_SingleObject()
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
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktEpisodeWatchedProgress>();
                string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktEpisodeWatchedProgresss);
                json.Should().Be($"[{{\"number\":1,\"completed\":true,\"last_watched_at\":\"{LAST_WATCHED_AT.ToTraktLongDateTimeString()}\"}}]");
            }
        }

        [Fact]
        public async Task Test_EpisodeWatchedProgressArrayJsonWriter_WriteArray_StringWriter_Complete()
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
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktEpisodeWatchedProgress>();
                string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktEpisodeWatchedProgresss);
                json.Should().Be($"[{{\"number\":1,\"completed\":true,\"last_watched_at\":\"{LAST_WATCHED_AT.ToTraktLongDateTimeString()}\"}}," +
                                 $"{{\"number\":2,\"completed\":true,\"last_watched_at\":\"{LAST_WATCHED_AT.ToTraktLongDateTimeString()}\"}}," +
                                 $"{{\"number\":3,\"completed\":true,\"last_watched_at\":\"{LAST_WATCHED_AT.ToTraktLongDateTimeString()}\"}}]");
            }
        }
    }
}
