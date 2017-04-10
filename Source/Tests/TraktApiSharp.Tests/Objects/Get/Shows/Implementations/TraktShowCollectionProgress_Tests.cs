namespace TraktApiSharp.Tests.Objects.Get.Shows.Implementations
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Objects.Get.Shows.Implementations;
    using TraktApiSharp.Objects.Get.Shows.JsonReader;
    using Xunit;

    [Category("Objects.Get.Shows.Implementations")]
    public class TraktShowCollectionProgress_Tests
    {
        [Fact]
        public void Test_TraktShowCollectionProgress_Inherits_TraktShowProgress()
        {
            typeof(TraktShowCollectionProgress).IsSubclassOf(typeof(TraktShowProgress)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktShowCollectionProgress_Implements_ITraktShowCollectionProgress_Interface()
        {
            typeof(TraktShowCollectionProgress).GetInterfaces().Should().Contain(typeof(ITraktShowCollectionProgress));
        }

        [Fact]
        public void Test_TraktShowCollectionProgress_Default_Constructor()
        {
            var showCollectionProgress = new TraktShowCollectionProgress();

            showCollectionProgress.Aired.Should().NotHaveValue();
            showCollectionProgress.Completed.Should().NotHaveValue();
            showCollectionProgress.LastCollectedAt.Should().NotHaveValue();
            showCollectionProgress.Seasons.Should().BeNull();
            showCollectionProgress.HiddenSeasons.Should().BeNull();
            showCollectionProgress.NextEpisode.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktShowCollectionProgress_From_Json()
        {
            var jsonReader = new ITraktShowCollectionProgressObjectJsonReader();
            var showCollectionProgress = await jsonReader.ReadObjectAsync(JSON);

            showCollectionProgress.Should().NotBeNull();

            showCollectionProgress.Aired.Should().Be(6);
            showCollectionProgress.Completed.Should().Be(6);
            showCollectionProgress.LastCollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());
            showCollectionProgress.Seasons.Should().NotBeNull().And.HaveCount(1);

            var seasons = showCollectionProgress.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Aired.Should().Be(8);
            seasons[0].Completed.Should().Be(6);
            seasons[0].Episodes.Should().NotBeNull().And.HaveCount(8);

            var episodes = seasons[0].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[2].Number.Should().Be(3);
            episodes[2].Completed.Should().BeTrue();
            episodes[2].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[3].Number.Should().Be(4);
            episodes[3].Completed.Should().BeTrue();
            episodes[3].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[4].Number.Should().Be(5);
            episodes[4].Completed.Should().BeTrue();
            episodes[4].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[5].Number.Should().Be(6);
            episodes[5].Completed.Should().BeTrue();
            episodes[5].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[6].Number.Should().Be(7);
            episodes[6].Completed.Should().BeFalse();
            episodes[6].CollectedAt.Should().NotHaveValue();

            episodes[7].Number.Should().Be(8);
            episodes[7].Completed.Should().BeFalse();
            episodes[7].CollectedAt.Should().NotHaveValue();

            showCollectionProgress.HiddenSeasons.Should().NotBeNull().And.HaveCount(1);

            var hiddenSeasons = showCollectionProgress.HiddenSeasons.ToArray();

            hiddenSeasons[0].Number.Should().Be(2);
            hiddenSeasons[0].Ids.Should().NotBeNull();
            hiddenSeasons[0].Ids.Trakt.Should().Be(3051U);
            hiddenSeasons[0].Ids.Tvdb.Should().Be(498968U);
            hiddenSeasons[0].Ids.Tmdb.Should().Be(53334U);
            hiddenSeasons[0].Ids.TvRage.Should().BeNull();

            showCollectionProgress.NextEpisode.Should().NotBeNull();
            showCollectionProgress.NextEpisode.SeasonNumber.Should().Be(1);
            showCollectionProgress.NextEpisode.Number.Should().Be(7);
            showCollectionProgress.NextEpisode.Title.Should().Be("Water");
            showCollectionProgress.NextEpisode.Ids.Should().NotBeNull();
            showCollectionProgress.NextEpisode.Ids.Trakt.Should().Be(62315U);
            showCollectionProgress.NextEpisode.Ids.Tvdb.Should().Be(4849873U);
            showCollectionProgress.NextEpisode.Ids.Imdb.Should().BeNull();
            showCollectionProgress.NextEpisode.Ids.Tmdb.Should().BeNull();
            showCollectionProgress.NextEpisode.Ids.TvRage.Should().BeNull();
        }

        private const string JSON =
            @"{
                ""aired"": 6,
                ""completed"": 6,
                ""last_collected_at"": ""2015-03-21T19:03:58.000Z"",
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""aired"": 8,
                    ""completed"": 6,
                    ""episodes"": [
                      {
                        ""number"": 1,
                        ""completed"": true,
                        ""collected_at"": ""2015-03-21T19:03:58.000Z""
                      },
                      {
                        ""number"": 2,
                        ""completed"": true,
                        ""collected_at"": ""2015-03-21T19:03:58.000Z""
                      },
                      {
                        ""number"": 3,
                        ""completed"": true,
                        ""collected_at"": ""2015-03-21T19:03:58.000Z""
                      },
                      {
                        ""number"": 4,
                        ""completed"": true,
                        ""collected_at"": ""2015-03-21T19:03:58.000Z""
                      },
                      {
                        ""number"": 5,
                        ""completed"": true,
                        ""collected_at"": ""2015-03-21T19:03:58.000Z""
                      },
                      {
                        ""number"": 6,
                        ""completed"": true,
                        ""collected_at"": ""2015-03-21T19:03:58.000Z""
                      },
                      {
                        ""number"": 7,
                        ""completed"": false,
                        ""collected_at"": null
                      },
                      {
                        ""number"": 8,
                        ""completed"": false,
                        ""collected_at"": null
                      }
                    ]
                  }
                ],
                ""hidden_seasons"": [
                  {
                    ""number"": 2,
                    ""ids"": {
                      ""trakt"": 3051,
                      ""tvdb"": 498968,
                      ""tmdb"": 53334,
                      ""tvrage"": null
                    }
                  }
                ],
                ""next_episode"": {
                  ""season"": 1,
                  ""number"": 7,
                  ""title"": ""Water"",
                  ""ids"": {
                    ""trakt"": 62315,
                    ""tvdb"": 4849873,
                    ""imdb"": null,
                    ""tmdb"": null,
                    ""tvrage"": null
                  }
                }
              }";
    }
}
