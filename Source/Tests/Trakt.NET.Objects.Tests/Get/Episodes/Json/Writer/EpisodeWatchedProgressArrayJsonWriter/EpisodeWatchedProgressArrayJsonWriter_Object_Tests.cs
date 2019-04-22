namespace TraktNet.Objects.Tests.Get.Episodes.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Extensions;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Get.Episodes.JsonWriter")]
    public partial class EpisodeWatchedProgressArrayJsonWriter_Tests
    {
        [Fact]
        public void Test_EpisodeWatchedProgressArrayJsonWriter_WriteArray_Array_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktEpisodeWatchedProgress>();
            Func<Task<string>> action = () => traktJsonWriter.WriteArrayAsync(default(IEnumerable<ITraktEpisodeWatchedProgress>));
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_EpisodeWatchedProgressArrayJsonWriter_WriteArray_Array_Empty()
        {
            IEnumerable<ITraktEpisodeWatchedProgress> traktEpisodeWatchedProgresss = new List<TraktEpisodeWatchedProgress>();

            var traktJsonWriter = new ArrayJsonWriter<ITraktEpisodeWatchedProgress>();
            string json = await traktJsonWriter.WriteArrayAsync(traktEpisodeWatchedProgresss);
            json.Should().Be("[]");
        }

        [Fact]
        public async Task Test_EpisodeWatchedProgressArrayJsonWriter_WriteArray_Array_SingleObject()
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

            var traktJsonWriter = new ArrayJsonWriter<ITraktEpisodeWatchedProgress>();
            string json = await traktJsonWriter.WriteArrayAsync(traktEpisodeWatchedProgresss);
            json.Should().Be($"[{{\"number\":1,\"completed\":true,\"last_watched_at\":\"{LAST_WATCHED_AT.ToTraktLongDateTimeString()}\"}}]");
        }

        [Fact]
        public async Task Test_EpisodeWatchedProgressArrayJsonWriter_WriteArray_Array_Complete()
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

            var traktJsonWriter = new ArrayJsonWriter<ITraktEpisodeWatchedProgress>();
            string json = await traktJsonWriter.WriteArrayAsync(traktEpisodeWatchedProgresss);
            json.Should().Be($"[{{\"number\":1,\"completed\":true,\"last_watched_at\":\"{LAST_WATCHED_AT.ToTraktLongDateTimeString()}\"}}," +
                             $"{{\"number\":2,\"completed\":true,\"last_watched_at\":\"{LAST_WATCHED_AT.ToTraktLongDateTimeString()}\"}}," +
                             $"{{\"number\":3,\"completed\":true,\"last_watched_at\":\"{LAST_WATCHED_AT.ToTraktLongDateTimeString()}\"}}]");
        }
    }
}
