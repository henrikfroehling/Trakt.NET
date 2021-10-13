namespace TraktNet.Objects.Get.Tests.Seasons.Json.Writer
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Extensions;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Get.Seasons.Json.Writer;
    using Xunit;

    [Category("Objects.Get.Seasons.JsonWriter")]
    public partial class SeasonWatchedProgressObjectJsonWriter_Tests
    {
        private static readonly DateTime LAST_WATCHED_AT = DateTime.UtcNow;

        [Fact]
        public async Task Test_SeasonWatchedProgressObjectJsonWriter_WriteObject_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new SeasonWatchedProgressObjectJsonWriter();
            ITraktSeasonWatchedProgress traktSeasonWatchedProgress = new TraktSeasonWatchedProgress();
            Func<Task> action = () => traktJsonWriter.WriteObjectAsync(default(JsonTextWriter), traktSeasonWatchedProgress);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SeasonWatchedProgressObjectJsonWriter_WriteObject_JsonWriter_Only_Number_Property()
        {
            ITraktSeasonWatchedProgress traktSeasonWatchedProgress = new TraktSeasonWatchedProgress
            {
                Number = 1
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new SeasonWatchedProgressObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktSeasonWatchedProgress);
                stringWriter.ToString().Should().Be(@"{""number"":1}");
            }
        }

        [Fact]
        public async Task Test_SeasonWatchedProgressObjectJsonWriter_WriteObject_JsonWriter_Only_Aired_Property()
        {
            ITraktSeasonWatchedProgress traktSeasonWatchedProgress = new TraktSeasonWatchedProgress
            {
                Aired = 24
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new SeasonWatchedProgressObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktSeasonWatchedProgress);
                stringWriter.ToString().Should().Be(@"{""aired"":24}");
            }
        }

        [Fact]
        public async Task Test_SeasonWatchedProgressObjectJsonWriter_WriteObject_JsonWriter_Only_Completed_Property()
        {
            ITraktSeasonWatchedProgress traktSeasonWatchedProgress = new TraktSeasonWatchedProgress
            {
                Completed = 12
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new SeasonWatchedProgressObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktSeasonWatchedProgress);
                stringWriter.ToString().Should().Be(@"{""completed"":12}");
            }
        }

        [Fact]
        public async Task Test_SeasonWatchedProgressObjectJsonWriter_WriteObject_JsonWriter_Only_Episodes_Property()
        {
            ITraktSeasonWatchedProgress traktSeasonWatchedProgress = new TraktSeasonWatchedProgress
            {
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
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new SeasonWatchedProgressObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktSeasonWatchedProgress);
                stringWriter.ToString().Should().Be(@"{""episodes"":[" +
                                                    $"{{\"number\":1,\"completed\":true,\"last_watched_at\":\"{LAST_WATCHED_AT.ToTraktLongDateTimeString()}\"}}," +
                                                    $"{{\"number\":2,\"completed\":true,\"last_watched_at\":\"{LAST_WATCHED_AT.ToTraktLongDateTimeString()}\"}}" +
                                                    "]}");
            }
        }

        [Fact]
        public async Task Test_SeasonWatchedProgressObjectJsonWriter_WriteObject_JsonWriter_Complete()
        {
            ITraktSeasonWatchedProgress traktSeasonWatchedProgress = new TraktSeasonWatchedProgress
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
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new SeasonWatchedProgressObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktSeasonWatchedProgress);
                stringWriter.ToString().Should().Be(@"{""number"":1,""aired"":24,""completed"":12," +
                                                    @"""episodes"":[" +
                                                    $"{{\"number\":1,\"completed\":true,\"last_watched_at\":\"{LAST_WATCHED_AT.ToTraktLongDateTimeString()}\"}}," +
                                                    $"{{\"number\":2,\"completed\":true,\"last_watched_at\":\"{LAST_WATCHED_AT.ToTraktLongDateTimeString()}\"}}" +
                                                    "]}");
            }
        }
    }
}
