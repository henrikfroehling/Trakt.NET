namespace TraktNet.Objects.Tests.Get.Seasons.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Extensions;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Get.Seasons.JsonWriter")]
    public partial class SeasonWatchedProgressArrayJsonWriter_Tests
    {
        [Fact]
        public void Test_SeasonWatchedProgressArrayJsonWriter_WriteArray_Array_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktSeasonWatchedProgress>();
            Func<Task<string>> action = () => traktJsonWriter.WriteArrayAsync(default(IEnumerable<ITraktSeasonWatchedProgress>));
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SeasonWatchedProgressArrayJsonWriter_WriteArray_Array_Empty()
        {
            IEnumerable<ITraktSeasonWatchedProgress> traktSeasonWatchedProgresses = new List<TraktSeasonWatchedProgress>();

            var traktJsonWriter = new ArrayJsonWriter<ITraktSeasonWatchedProgress>();
            string json = await traktJsonWriter.WriteArrayAsync(traktSeasonWatchedProgresses);
            json.Should().Be("[]");
        }

        [Fact]
        public async Task Test_SeasonWatchedProgressArrayJsonWriter_WriteArray_Array_SingleObject()
        {
            IEnumerable<ITraktSeasonWatchedProgress> traktSeasonWatchedProgresses = new List<ITraktSeasonWatchedProgress>
            {
                new TraktSeasonWatchedProgress
                {
                    Number = 1,
                    Aired = 24,
                    Completed = 12,
                    Episodes = new List<ITraktEpisodeWatchedProgress>
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
                        }
                    }
                }
            };

            var traktJsonWriter = new ArrayJsonWriter<ITraktSeasonWatchedProgress>();
            string json = await traktJsonWriter.WriteArrayAsync(traktSeasonWatchedProgresses);
            json.Should().Be(@"[{""number"":1,""aired"":24,""completed"":12," +
                             @"""episodes"":[" +
                             $"{{\"number\":1,\"completed\":true,\"last_watched_at\":\"{LAST_WATCHED_AT.ToTraktLongDateTimeString()}\"}}," +
                             $"{{\"number\":2,\"completed\":true,\"last_watched_at\":\"{LAST_WATCHED_AT.ToTraktLongDateTimeString()}\"}}" +
                             "]}]");
        }

        [Fact]
        public async Task Test_SeasonWatchedProgressArrayJsonWriter_WriteArray_Array_Complete()
        {
            IEnumerable<ITraktSeasonWatchedProgress> traktSeasonWatchedProgresses = new List<ITraktSeasonWatchedProgress>
            {
                new TraktSeasonWatchedProgress
                {
                    Number = 1,
                    Aired = 24,
                    Completed = 12,
                    Episodes = new List<ITraktEpisodeWatchedProgress>
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
                        }
                    }
                },
                new TraktSeasonWatchedProgress
                {
                    Number = 2,
                    Aired = 24,
                    Completed = 12,
                    Episodes = new List<ITraktEpisodeWatchedProgress>
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
                        }
                    }
                }
            };

            var traktJsonWriter = new ArrayJsonWriter<ITraktSeasonWatchedProgress>();
            string json = await traktJsonWriter.WriteArrayAsync(traktSeasonWatchedProgresses);
            json.Should().Be(@"[{""number"":1,""aired"":24,""completed"":12," +
                             @"""episodes"":[" +
                             $"{{\"number\":1,\"completed\":true,\"last_watched_at\":\"{LAST_WATCHED_AT.ToTraktLongDateTimeString()}\"}}," +
                             $"{{\"number\":2,\"completed\":true,\"last_watched_at\":\"{LAST_WATCHED_AT.ToTraktLongDateTimeString()}\"}}" +
                             "]}," +
                             @"{""number"":2,""aired"":24,""completed"":12," +
                             @"""episodes"":[" +
                             $"{{\"number\":1,\"completed\":true,\"last_watched_at\":\"{LAST_WATCHED_AT.ToTraktLongDateTimeString()}\"}}," +
                             $"{{\"number\":2,\"completed\":true,\"last_watched_at\":\"{LAST_WATCHED_AT.ToTraktLongDateTimeString()}\"}}" +
                             "]}]");
        }
    }
}
