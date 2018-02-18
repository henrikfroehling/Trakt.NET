namespace TraktApiSharp.Tests.Objects.Get.Seasons.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Extensions;
    using TraktApiSharp.Objects.Get.Episodes;
    using TraktApiSharp.Objects.Get.Episodes.Implementations;
    using TraktApiSharp.Objects.Get.Seasons;
    using TraktApiSharp.Objects.Get.Seasons.Implementations;
    using TraktApiSharp.Objects.Json;
    using Xunit;

    [Category("Objects.Get.Seasons.JsonWriter")]
    public partial class SeasonCollectionProgressArrayJsonWriter_Tests
    {
        [Fact]
        public void Test_SeasonCollectionProgressArrayJsonWriter_WriteArray_Array_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktSeasonCollectionProgress>();
            Func<Task<string>> action = () => traktJsonWriter.WriteArrayAsync(default(IEnumerable<ITraktSeasonCollectionProgress>));
            action.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SeasonCollectionProgressArrayJsonWriter_WriteArray_Array_Empty()
        {
            IEnumerable<ITraktSeasonCollectionProgress> traktSeasonCollectionProgresses = new List<TraktSeasonCollectionProgress>();

            var traktJsonWriter = new ArrayJsonWriter<ITraktSeasonCollectionProgress>();
            string json = await traktJsonWriter.WriteArrayAsync(traktSeasonCollectionProgresses);
            json.Should().Be("[]");
        }

        [Fact]
        public async Task Test_SeasonCollectionProgressArrayJsonWriter_WriteArray_Array_SingleObject()
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

            var traktJsonWriter = new ArrayJsonWriter<ITraktSeasonCollectionProgress>();
            string json = await traktJsonWriter.WriteArrayAsync(traktSeasonCollectionProgresses);
            json.Should().Be(@"[{""number"":1,""aired"":24,""completed"":12," +
                             @"""episodes"":[" +
                             $"{{\"number\":1,\"completed\":true,\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"}}," +
                             $"{{\"number\":2,\"completed\":true,\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"}}" +
                             "]}]");
        }

        [Fact]
        public async Task Test_SeasonCollectionProgressArrayJsonWriter_WriteArray_Array_Complete()
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

            var traktJsonWriter = new ArrayJsonWriter<ITraktSeasonCollectionProgress>();
            string json = await traktJsonWriter.WriteArrayAsync(traktSeasonCollectionProgresses);
            json.Should().Be(@"[{""number"":1,""aired"":24,""completed"":12," +
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
