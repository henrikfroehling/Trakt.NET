namespace TraktNet.Objects.Get.Tests.Users.Implementations
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.Users;
    using TraktNet.Objects.Get.Users.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Users.Implementations")]
    public class TraktFavorite_Tests
    {
        [Fact]
        public void Test_TraktFavorite_Default_Constructor()
        {
            var favorite = new TraktFavorite();

            favorite.Id.Should().BeNull();
            favorite.Rank.Should().BeNull();
            favorite.ListedAt.Should().BeNull();
            favorite.Type.Should().BeNull();
            favorite.Notes.Should().BeNull();
            favorite.Movie.Should().BeNull();
            favorite.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktFavorite_From_Json_With_Movie()
        {
            var jsonReader = new FavoriteObjectJsonReader();
            var favorite = await jsonReader.ReadObjectAsync(JSON_MOVIE) as TraktFavorite;

            favorite.Should().NotBeNull();
            favorite.Id.Should().Be(101);
            favorite.Rank.Should().Be(1);
            favorite.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            favorite.Type.Should().Be(TraktFavoriteObjectType.Movie);
            favorite.Notes.Should().Be("Daft Punk really knocks it out of the park on the soundtrack.");
            favorite.Movie.Should().NotBeNull();
            favorite.Movie.Title.Should().Be("TRON: Legacy");
            favorite.Movie.Year.Should().Be(2010);
            favorite.Movie.Ids.Should().NotBeNull();
            favorite.Movie.Ids.Trakt.Should().Be(1U);
            favorite.Movie.Ids.Slug.Should().Be("tron-legacy-2010");
            favorite.Movie.Ids.Imdb.Should().Be("tt1104001");
            favorite.Movie.Ids.Tmdb.Should().Be(20526U);
            favorite.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktFavorite_From_Json_With_Show()
        {
            var jsonReader = new FavoriteObjectJsonReader();
            var favorite = await jsonReader.ReadObjectAsync(JSON_SHOW) as TraktFavorite;

            favorite.Should().NotBeNull();
            favorite.Id.Should().Be(102);
            favorite.Rank.Should().Be(1);
            favorite.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            favorite.Type.Should().Be(TraktFavoriteObjectType.Show);
            favorite.Notes.Should().Be("Atmospheric for days.");
            favorite.Movie.Should().BeNull();
            favorite.Show.Should().NotBeNull();
            favorite.Show.Title.Should().Be("The Walking Dead");
            favorite.Show.Year.Should().Be(2010);
            favorite.Show.Ids.Should().NotBeNull();
            favorite.Show.Ids.Trakt.Should().Be(2U);
            favorite.Show.Ids.Slug.Should().Be("the-walking-dead");
            favorite.Show.Ids.Tvdb.Should().Be(153021U);
            favorite.Show.Ids.Imdb.Should().Be("tt1520211");
            favorite.Show.Ids.Tmdb.Should().Be(1402U);
        }

        private const string JSON_MOVIE =
            @"{
                ""id"": 101,
                ""rank"": 1,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""type"": ""movie"",
                ""notes"": ""Daft Punk really knocks it out of the park on the soundtrack."",
                ""movie"": {
                  ""title"": ""TRON: Legacy"",
                  ""year"": 2010,
                  ""ids"": {
                    ""trakt"": 1,
                    ""slug"": ""tron-legacy-2010"",
                    ""imdb"": ""tt1104001"",
                    ""tmdb"": 20526
                  }
                }
              }";

        private const string JSON_SHOW =
            @"{
                ""id"": 102,
                ""rank"": 1,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""type"": ""show"",
                ""notes"": ""Atmospheric for days."",
                ""show"": {
                  ""title"": ""The Walking Dead"",
                  ""year"": 2010,
                  ""ids"": {
                    ""trakt"": 2,
                    ""slug"": ""the-walking-dead"",
                    ""tvdb"": 153021,
                    ""imdb"": ""tt1520211"",
                    ""tmdb"": 1402
                  }
                }
              }";
    }
}
