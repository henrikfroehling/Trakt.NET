namespace TraktNet.Objects.Get.Tests.Seasons.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Extensions;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Get.Seasons.Json.Writer;
    using Xunit;

    [Category("Objects.Get.Seasons.JsonWriter")]
    public partial class SeasonCollectionProgressObjectJsonWriter_Tests
    {
        [Fact]
        public void Test_SeasonCollectionProgressObjectJsonWriter_WriteObject_Object_Exceptions()
        {
            var traktJsonWriter = new SeasonCollectionProgressObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default(ITraktSeasonCollectionProgress));
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SeasonCollectionProgressObjectJsonWriter_WriteObject_Object_Only_Number_Property()
        {
            ITraktSeasonCollectionProgress traktSeasonCollectionProgress = new TraktSeasonCollectionProgress
            {
                Number = 1
            };

            var traktJsonWriter = new SeasonCollectionProgressObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktSeasonCollectionProgress);
            json.Should().Be(@"{""number"":1}");
        }

        [Fact]
        public async Task Test_SeasonCollectionProgressObjectJsonWriter_WriteObject_Object_Only_Aired_Property()
        {
            ITraktSeasonCollectionProgress traktSeasonCollectionProgress = new TraktSeasonCollectionProgress
            {
                Aired = 24
            };

            var traktJsonWriter = new SeasonCollectionProgressObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktSeasonCollectionProgress);
            json.Should().Be(@"{""aired"":24}");
        }

        [Fact]
        public async Task Test_SeasonCollectionProgressObjectJsonWriter_WriteObject_Object_Only_Completed_Property()
        {
            ITraktSeasonCollectionProgress traktSeasonCollectionProgress = new TraktSeasonCollectionProgress
            {
                Completed = 12
            };

            var traktJsonWriter = new SeasonCollectionProgressObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktSeasonCollectionProgress);
            json.Should().Be(@"{""completed"":12}");
        }

        [Fact]
        public async Task Test_SeasonCollectionProgressObjectJsonWriter_WriteObject_Object_Only_Episodes_Property()
        {
            ITraktSeasonCollectionProgress traktSeasonCollectionProgress = new TraktSeasonCollectionProgress
            {
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
            };

            var traktJsonWriter = new SeasonCollectionProgressObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktSeasonCollectionProgress);
            json.Should().Be(@"{""episodes"":[" +
                             $"{{\"number\":1,\"completed\":true,\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"}}," +
                             $"{{\"number\":2,\"completed\":true,\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"}}" +
                             "]}");
        }

        [Fact]
        public async Task Test_SeasonCollectionProgressObjectJsonWriter_WriteObject_Object_Complete()
        {
            ITraktSeasonCollectionProgress traktSeasonCollectionProgress = new TraktSeasonCollectionProgress
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
            };

            var traktJsonWriter = new SeasonCollectionProgressObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktSeasonCollectionProgress);
            json.Should().Be(@"{""number"":1,""aired"":24,""completed"":12," +
                             @"""episodes"":[" +
                             $"{{\"number\":1,\"completed\":true,\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"}}," +
                             $"{{\"number\":2,\"completed\":true,\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"}}" +
                             "]}");
        }
    }
}
