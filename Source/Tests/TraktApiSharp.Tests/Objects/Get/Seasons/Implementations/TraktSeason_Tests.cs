namespace TraktApiSharp.Tests.Objects.Get.Seasons.Implementations
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Seasons;
    using TraktApiSharp.Objects.Get.Seasons.Implementations;
    using TraktApiSharp.Objects.Get.Seasons.JsonReader;
    using Xunit;

    [Category("Objects.Get.Seasons.Implementations")]
    public class TraktSeason_Tests
    {
        [Fact]
        public void Test_TraktSeason_Implements_ITraktSeason_Interface()
        {
            typeof(TraktSeason).GetInterfaces().Should().Contain(typeof(ITraktSeason));
        }

        [Fact]
        public void Test_TraktSeason_Default_Constructor()
        {
            var season = new TraktSeason();

            season.Number.Should().NotHaveValue();
            season.Title.Should().BeNullOrEmpty();
            season.Ids.Should().BeNull();
            season.Rating.Should().NotHaveValue();
            season.Votes.Should().NotHaveValue();
            season.TotalEpisodesCount.Should().NotHaveValue();
            season.AiredEpisodesCount.Should().NotHaveValue();
            season.Overview.Should().BeNullOrEmpty();
            season.FirstAired.Should().NotHaveValue();
            season.Episodes.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktSeason_From_Minimal_Json()
        {
            var jsonReader = new SeasonObjectJsonReader();
            var season = await jsonReader.ReadObjectAsync(MINIMAL_JSON) as TraktSeason;

            season.Should().NotBeNull();
            season.Number.Should().Be(1);
            season.Title.Should().BeNullOrEmpty();
            season.Ids.Should().NotBeNull();
            season.Ids.Trakt.Should().Be(61430U);
            season.Ids.Tvdb.Should().Be(279121U);
            season.Ids.Tmdb.Should().Be(60523U);
            season.Ids.TvRage.Should().Be(36939U);
            season.Rating.Should().NotHaveValue();
            season.Votes.Should().NotHaveValue();
            season.TotalEpisodesCount.Should().NotHaveValue();
            season.AiredEpisodesCount.Should().NotHaveValue();
            season.Overview.Should().BeNullOrEmpty();
            season.FirstAired.Should().NotHaveValue();
            season.Episodes.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktSeason_From_Full_Json()
        {
            var jsonReader = new SeasonObjectJsonReader();
            var season = await jsonReader.ReadObjectAsync(FULL_JSON) as TraktSeason;

            season.Should().NotBeNull();
            season.Number.Should().Be(1);
            season.Title.Should().Be("Season 1");
            season.Ids.Should().NotBeNull();
            season.Ids.Trakt.Should().Be(61430U);
            season.Ids.Tvdb.Should().Be(279121U);
            season.Ids.Tmdb.Should().Be(60523U);
            season.Ids.TvRage.Should().Be(36939U);
            season.Rating.Should().Be(8.57053f);
            season.Votes.Should().Be(794);
            season.TotalEpisodesCount.Should().Be(23);
            season.AiredEpisodesCount.Should().Be(23);
            season.Overview.Should().Be("Text text text");
            season.FirstAired.Should().Be(DateTime.Parse("2014-10-08T00:00:00.000Z").ToUniversalTime());
            season.Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodes = season.Episodes.ToArray();

            episodes[0].Should().NotBeNull();
            episodes[0].SeasonNumber.Should().Be(1);
            episodes[0].Number.Should().Be(1);
            episodes[0].Title.Should().Be("Winter Is Coming");
            episodes[0].Ids.Should().NotBeNull();
            episodes[0].Ids.Trakt.Should().Be(73640U);
            episodes[0].Ids.Tvdb.Should().Be(3254641U);
            episodes[0].Ids.Imdb.Should().Be("tt1480055");
            episodes[0].Ids.Tmdb.Should().Be(63056U);
            episodes[0].Ids.TvRage.Should().Be(1065008299U);
            episodes[0].NumberAbsolute.Should().NotHaveValue();
            episodes[0].Overview.Should().BeNullOrEmpty();
            episodes[0].Runtime.Should().NotHaveValue();
            episodes[0].Rating.Should().NotHaveValue();
            episodes[0].Votes.Should().NotHaveValue();
            episodes[0].FirstAired.Should().NotHaveValue();
            episodes[0].UpdatedAt.Should().NotHaveValue();
            episodes[0].AvailableTranslationLanguageCodes.Should().BeNull();
            episodes[0].Translations.Should().BeNull();

            episodes[1].Should().NotBeNull();
            episodes[1].SeasonNumber.Should().Be(1);
            episodes[1].Number.Should().Be(2);
            episodes[1].Title.Should().Be("The Kingsroad");
            episodes[1].Ids.Should().NotBeNull();
            episodes[1].Ids.Trakt.Should().Be(74138U);
            episodes[1].Ids.Tvdb.Should().Be(3436411U);
            episodes[1].Ids.Imdb.Should().Be("tt1668746");
            episodes[1].Ids.Tmdb.Should().Be(63141U);
            episodes[1].Ids.TvRage.Should().Be(1325718577U);
            episodes[1].NumberAbsolute.Should().NotHaveValue();
            episodes[1].Overview.Should().BeNullOrEmpty();
            episodes[1].Runtime.Should().NotHaveValue();
            episodes[1].Rating.Should().NotHaveValue();
            episodes[1].Votes.Should().NotHaveValue();
            episodes[1].FirstAired.Should().NotHaveValue();
            episodes[1].UpdatedAt.Should().NotHaveValue();
            episodes[1].AvailableTranslationLanguageCodes.Should().BeNull();
            episodes[1].Translations.Should().BeNull();
        }

        private const string MINIMAL_JSON =
            @"{
                ""number"": 1,
                ""ids"": {
                  ""trakt"": 61430,
                  ""tvdb"": 279121,
                  ""tmdb"": 60523,
                  ""tvrage"": 36939
                }
              }";

        private const string FULL_JSON =
            @"{
                ""number"": 1,
                ""ids"": {
                  ""trakt"": 61430,
                  ""tvdb"": 279121,
                  ""tmdb"": 60523,
                  ""tvrage"": 36939
                },
                ""title"": ""Season 1"",
                ""rating"": 8.57053,
                ""votes"": 794,
                ""episode_count"": 23,
                ""aired_episodes"": 23,
                ""overview"": ""Text text text"",
                ""first_aired"": ""2014-10-08T00:00:00.000Z"",
                ""episodes"": [
                  {
                    ""season"": 1,
                    ""number"": 1,
                    ""title"": ""Winter Is Coming"",
                    ""ids"": {
                      ""trakt"": 73640,
                      ""tvdb"": 3254641,
                      ""imdb"": ""tt1480055"",
                      ""tmdb"": 63056,
                      ""tvrage"": 1065008299
                    }
                  },
                  {
                    ""season"": 1,
                    ""number"": 2,
                    ""title"": ""The Kingsroad"",
                    ""ids"": {
                      ""trakt"": 74138,
                      ""tvdb"": 3436411,
                      ""imdb"": ""tt1668746"",
                      ""tmdb"": 63141,
                      ""tvrage"": 1325718577
                    }
                  }
                ]
              }";
    }
}
