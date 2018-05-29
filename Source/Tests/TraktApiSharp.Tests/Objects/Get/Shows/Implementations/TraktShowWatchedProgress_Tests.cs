namespace TraktApiSharp.Tests.Objects.Get.Shows.Implementations
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Objects.Get.Shows.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Shows.Implementations")]
    public class TraktShowWatchedProgress_Tests
    {
        [Fact]
        public void Test_TraktShowWatchedProgress_Default_Constructor()
        {
            var showWatchedProgress = new TraktShowWatchedProgress();

            showWatchedProgress.Aired.Should().NotHaveValue();
            showWatchedProgress.Completed.Should().NotHaveValue();
            showWatchedProgress.LastWatchedAt.Should().NotHaveValue();
            showWatchedProgress.Seasons.Should().BeNull();
            showWatchedProgress.HiddenSeasons.Should().BeNull();
            showWatchedProgress.NextEpisode.Should().BeNull();
            showWatchedProgress.LastEpisode.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktShowWatchedProgress_From_Json()
        {
            var jsonReader = new ShowWatchedProgressObjectJsonReader();
            var showWatchedProgress = await jsonReader.ReadObjectAsync(JSON) as TraktShowWatchedProgress;

            showWatchedProgress.Should().NotBeNull();

            showWatchedProgress.Aired.Should().Be(6);
            showWatchedProgress.Completed.Should().Be(6);
            showWatchedProgress.LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());
            showWatchedProgress.Seasons.Should().NotBeNull().And.HaveCount(1);

            var seasons = showWatchedProgress.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Aired.Should().Be(8);
            seasons[0].Completed.Should().Be(6);
            seasons[0].Episodes.Should().NotBeNull().And.HaveCount(8);

            var episodes = seasons[0].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[2].Number.Should().Be(3);
            episodes[2].Completed.Should().BeTrue();
            episodes[2].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[3].Number.Should().Be(4);
            episodes[3].Completed.Should().BeTrue();
            episodes[3].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[4].Number.Should().Be(5);
            episodes[4].Completed.Should().BeTrue();
            episodes[4].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[5].Number.Should().Be(6);
            episodes[5].Completed.Should().BeTrue();
            episodes[5].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[6].Number.Should().Be(7);
            episodes[6].Completed.Should().BeFalse();
            episodes[6].LastWatchedAt.Should().NotHaveValue();

            episodes[7].Number.Should().Be(8);
            episodes[7].Completed.Should().BeFalse();
            episodes[7].LastWatchedAt.Should().NotHaveValue();

            showWatchedProgress.HiddenSeasons.Should().NotBeNull().And.HaveCount(1);

            var hiddenSeasons = showWatchedProgress.HiddenSeasons.ToArray();

            hiddenSeasons[0].Number.Should().Be(2);
            hiddenSeasons[0].Ids.Should().NotBeNull();
            hiddenSeasons[0].Ids.Trakt.Should().Be(3051U);
            hiddenSeasons[0].Ids.Tvdb.Should().Be(498968U);
            hiddenSeasons[0].Ids.Tmdb.Should().Be(53334U);
            hiddenSeasons[0].Ids.TvRage.Should().BeNull();

            showWatchedProgress.NextEpisode.Should().NotBeNull();
            showWatchedProgress.NextEpisode.SeasonNumber.Should().Be(1);
            showWatchedProgress.NextEpisode.Number.Should().Be(7);
            showWatchedProgress.NextEpisode.Title.Should().Be("Water");
            showWatchedProgress.NextEpisode.Ids.Should().NotBeNull();
            showWatchedProgress.NextEpisode.Ids.Trakt.Should().Be(62315U);
            showWatchedProgress.NextEpisode.Ids.Tvdb.Should().Be(4849873U);
            showWatchedProgress.NextEpisode.Ids.Imdb.Should().BeNull();
            showWatchedProgress.NextEpisode.Ids.Tmdb.Should().BeNull();
            showWatchedProgress.NextEpisode.Ids.TvRage.Should().BeNull();

            showWatchedProgress.LastEpisode.Should().NotBeNull();
            showWatchedProgress.LastEpisode.SeasonNumber.Should().Be(1);
            showWatchedProgress.LastEpisode.Number.Should().Be(2);
            showWatchedProgress.LastEpisode.Title.Should().Be("Storm");
            showWatchedProgress.LastEpisode.Ids.Should().NotBeNull();
            showWatchedProgress.LastEpisode.Ids.Trakt.Should().Be(62316U);
            showWatchedProgress.LastEpisode.Ids.Tvdb.Should().Be(4849875U);
            showWatchedProgress.LastEpisode.Ids.Imdb.Should().Be("tt0203245");
            showWatchedProgress.LastEpisode.Ids.Tmdb.Should().Be(525364U);
            showWatchedProgress.LastEpisode.Ids.TvRage.Should().Be(26414563U);
        }

        private const string JSON =
            @"{
                ""aired"": 6,
                ""completed"": 6,
                ""last_watched_at"": ""2015-03-21T19:03:58.000Z"",
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""aired"": 8,
                    ""completed"": 6,
                    ""episodes"": [
                      {
                        ""number"": 1,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      },
                      {
                        ""number"": 2,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      },
                      {
                        ""number"": 3,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      },
                      {
                        ""number"": 4,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      },
                      {
                        ""number"": 5,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      },
                      {
                        ""number"": 6,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      },
                      {
                        ""number"": 7,
                        ""completed"": false,
                        ""last_watched_at"": null
                      },
                      {
                        ""number"": 8,
                        ""completed"": false,
                        ""last_watched_at"": null
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
                },
                ""last_episode"": {
                  ""season"": 1,
                  ""number"": 2,
                  ""title"": ""Storm"",
                  ""ids"": {
                    ""trakt"": 62316,
                    ""tvdb"": 4849875,
                    ""imdb"": ""tt0203245"",
                    ""tmdb"": 525364,
                    ""tvrage"": 26414563
                  }
                }
              }";
    }
}
