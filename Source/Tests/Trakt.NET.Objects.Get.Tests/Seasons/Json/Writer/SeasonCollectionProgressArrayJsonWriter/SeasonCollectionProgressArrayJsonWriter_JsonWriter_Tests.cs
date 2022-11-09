﻿namespace TraktNet.Objects.Get.Tests.Seasons.Json.Writer
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
    using TraktNet.Objects.Json;
    using Xunit;

    [TestCategory("Objects.Get.Seasons.JsonWriter")]
    public partial class SeasonCollectionProgressArrayJsonWriter_Tests
    {
        private static readonly DateTime COLLECTED_AT = DateTime.UtcNow;

        [Fact]
        public async Task Test_SeasonCollectionProgressArrayJsonWriter_WriteArray_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktSeasonCollectionProgress>();
            IEnumerable<ITraktSeasonCollectionProgress> traktSeasonCollectionProgresses = new List<TraktSeasonCollectionProgress>();
            Func<Task> action = () => traktJsonWriter.WriteArrayAsync(default(JsonTextWriter), traktSeasonCollectionProgresses);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SeasonCollectionProgressArrayJsonWriter_WriteArray_JsonWriter_Empty()
        {
            IEnumerable<ITraktSeasonCollectionProgress> traktSeasonCollectionProgresses = new List<TraktSeasonCollectionProgress>();

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktSeasonCollectionProgress>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktSeasonCollectionProgresses);
                stringWriter.ToString().Should().Be("[]");
            }
        }

        [Fact]
        public async Task Test_SeasonCollectionProgressArrayJsonWriter_WriteArray_JsonWriter_SingleObject()
        {
            IEnumerable<ITraktSeasonCollectionProgress> traktSeasonCollectionProgresses = new List<ITraktSeasonCollectionProgress>
            {
                new TraktSeasonCollectionProgress
                {
                    Number = 1,
                    Aired = 24,
                    Completed = 12,
                    Episodes = new List<ITraktEpisodeCollectionProgress>
                    {
                        new TraktEpisodeCollectionProgress
                        {
                            Number = 1,
                            Completed = true,
                            CollectedAt = COLLECTED_AT
                        },
                        new TraktEpisodeCollectionProgress
                        {
                            Number = 2,
                            Completed = true,
                            CollectedAt = COLLECTED_AT
                        }
                    }
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktSeasonCollectionProgress>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktSeasonCollectionProgresses);
                stringWriter.ToString().Should().Be(@"[{""number"":1,""aired"":24,""completed"":12," +
                                                    @"""episodes"":[" +
                                                    $"{{\"number\":1,\"completed\":true,\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"}}," +
                                                    $"{{\"number\":2,\"completed\":true,\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"}}" +
                                                    "]}]");
            }
        }

        [Fact]
        public async Task Test_SeasonCollectionProgressArrayJsonWriter_WriteArray_JsonWriter_Complete()
        {
            IEnumerable<ITraktSeasonCollectionProgress> traktSeasonCollectionProgresses = new List<ITraktSeasonCollectionProgress>
            {
                new TraktSeasonCollectionProgress
                {
                    Number = 1,
                    Aired = 24,
                    Completed = 12,
                    Episodes = new List<ITraktEpisodeCollectionProgress>
                    {
                        new TraktEpisodeCollectionProgress
                        {
                            Number = 1,
                            Completed = true,
                            CollectedAt = COLLECTED_AT
                        },
                        new TraktEpisodeCollectionProgress
                        {
                            Number = 2,
                            Completed = true,
                            CollectedAt = COLLECTED_AT
                        }
                    }
                },
                new TraktSeasonCollectionProgress
                {
                    Number = 2,
                    Aired = 24,
                    Completed = 12,
                    Episodes = new List<ITraktEpisodeCollectionProgress>
                    {
                        new TraktEpisodeCollectionProgress
                        {
                            Number = 1,
                            Completed = true,
                            CollectedAt = COLLECTED_AT
                        },
                        new TraktEpisodeCollectionProgress
                        {
                            Number = 2,
                            Completed = true,
                            CollectedAt = COLLECTED_AT
                        }
                    }
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktSeasonCollectionProgress>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktSeasonCollectionProgresses);
                stringWriter.ToString().Should().Be(@"[{""number"":1,""aired"":24,""completed"":12," +
                                                    @"""episodes"":[" +
                                                    $"{{\"number\":1,\"completed\":true,\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"}}," +
                                                    $"{{\"number\":2,\"completed\":true,\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"}}" +
                                                    "]}," +
                                                    @"{""number"":2,""aired"":24,""completed"":12," +
                                                    @"""episodes"":[" +
                                                    $"{{\"number\":1,\"completed\":true,\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"}}," +
                                                    $"{{\"number\":2,\"completed\":true,\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"}}" +
                                                    "]}]");
            }
        }
    }
}
