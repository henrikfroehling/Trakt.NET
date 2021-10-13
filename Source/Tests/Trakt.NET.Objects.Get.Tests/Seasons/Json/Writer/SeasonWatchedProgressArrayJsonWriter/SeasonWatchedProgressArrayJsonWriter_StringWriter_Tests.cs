namespace TraktNet.Objects.Get.Tests.Seasons.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.IO;
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
        public async Task Test_SeasonWatchedProgressArrayJsonWriter_WriteArray_StringWriter_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktSeasonWatchedProgress>();
            IEnumerable<ITraktSeasonWatchedProgress> traktSeasonWatchedProgresses = new List<TraktSeasonWatchedProgress>();
            Func<Task<string>> action = () => traktJsonWriter.WriteArrayAsync(default(StringWriter), traktSeasonWatchedProgresses);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SeasonWatchedProgressArrayJsonWriter_WriteArray_StringWriter_Empty()
        {
            IEnumerable<ITraktSeasonWatchedProgress> traktSeasonWatchedProgresses = new List<TraktSeasonWatchedProgress>();

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktSeasonWatchedProgress>();
                string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktSeasonWatchedProgresses);
                json.Should().Be("[]");
            }
        }

        [Fact]
        public async Task Test_SeasonWatchedProgressArrayJsonWriter_WriteArray_StringWriter_SingleObject()
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

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktSeasonWatchedProgress>();
                string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktSeasonWatchedProgresses);
                json.Should().Be(@"[{""number"":1,""aired"":24,""completed"":12," +
                                 @"""episodes"":[" +
                                 $"{{\"number\":1,\"completed\":true,\"last_watched_at\":\"{LAST_WATCHED_AT.ToTraktLongDateTimeString()}\"}}," +
                                 $"{{\"number\":2,\"completed\":true,\"last_watched_at\":\"{LAST_WATCHED_AT.ToTraktLongDateTimeString()}\"}}" +
                                 "]}]");
            }
        }

        [Fact]
        public async Task Test_SeasonWatchedProgressArrayJsonWriter_WriteArray_StringWriter_Complete()
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

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktSeasonWatchedProgress>();
                string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktSeasonWatchedProgresses);
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
}
