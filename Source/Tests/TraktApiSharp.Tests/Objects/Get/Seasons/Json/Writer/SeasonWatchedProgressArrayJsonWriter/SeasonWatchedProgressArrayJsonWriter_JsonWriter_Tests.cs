namespace TraktApiSharp.Tests.Objects.Get.Seasons.Json.Writer
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
    using TraktApiSharp.Objects.Get.Seasons;
    using TraktApiSharp.Objects.Get.Seasons.Implementations;
    using TraktApiSharp.Objects.Get.Seasons.Json.Writer;
    using Xunit;

    [Category("Objects.Get.Seasons.JsonWriter")]
    public partial class SeasonWatchedProgressArrayJsonWriter_Tests
    {
        private static readonly DateTime LAST_WATCHED_AT = DateTime.UtcNow;

        [Fact]
        public void Test_SeasonWatchedProgressArrayJsonWriter_WriteArray_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new SeasonWatchedProgressArrayJsonWriter();
            IEnumerable<ITraktSeasonWatchedProgress> traktSeasonWatchedProgresses = new List<TraktSeasonWatchedProgress>();
            Func<Task> action = () => traktJsonWriter.WriteArrayAsync(default(JsonTextWriter), traktSeasonWatchedProgresses);
            action.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SeasonWatchedProgressArrayJsonWriter_WriteArray_JsonWriter_Empty()
        {
            IEnumerable<ITraktSeasonWatchedProgress> traktSeasonWatchedProgresses = new List<TraktSeasonWatchedProgress>();

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new SeasonWatchedProgressArrayJsonWriter();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktSeasonWatchedProgresses);
                stringWriter.ToString().Should().Be("[]");
            }
        }

        [Fact]
        public async Task Test_SeasonWatchedProgressArrayJsonWriter_WriteArray_JsonWriter_SingleObject()
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
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new SeasonWatchedProgressArrayJsonWriter();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktSeasonWatchedProgresses);
                stringWriter.ToString().Should().Be(@"[{""number"":1,""aired"":24,""completed"":12," +
                                                    @"""episodes"":[" +
                                                    $"{{\"number\":1,\"completed\":true,\"last_watched_at\":\"{LAST_WATCHED_AT.ToTraktLongDateTimeString()}\"}}," +
                                                    $"{{\"number\":2,\"completed\":true,\"last_watched_at\":\"{LAST_WATCHED_AT.ToTraktLongDateTimeString()}\"}}" +
                                                    "]}]");
            }
        }

        [Fact]
        public async Task Test_SeasonWatchedProgressArrayJsonWriter_WriteArray_JsonWriter_Complete()
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
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new SeasonWatchedProgressArrayJsonWriter();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktSeasonWatchedProgresses);
                stringWriter.ToString().Should().Be(@"[{""number"":1,""aired"":24,""completed"":12," +
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
