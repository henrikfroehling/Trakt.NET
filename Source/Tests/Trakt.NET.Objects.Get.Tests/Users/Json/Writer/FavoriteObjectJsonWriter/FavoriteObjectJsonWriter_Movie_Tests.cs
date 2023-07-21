namespace TraktNet.Objects.Get.Tests.Users.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Extensions;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Users;
    using TraktNet.Objects.Get.Users.Json.Writer;
    using Xunit;

    [TestCategory("Objects.Get.Users.JsonWriter")]
    public partial class FavoriteObjectJsonWriter_Tests
    {
        private readonly DateTime LISTED_AT = DateTime.UtcNow;

        [Fact]
        public async Task Test_FavoriteObjectJsonWriter_Movie_WriteObject_Object_Only_Id_Property()
        {
            ITraktFavorite traktFavorite = new TraktFavorite
            {
                Id = 101
            };

            var traktJsonWriter = new FavoriteObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktFavorite);
            json.Should().Be(@"{""id"":101}");
        }

        [Fact]
        public async Task Test_FavoriteObjectJsonWriter_Movie_WriteObject_Object_Only_Rank_Property()
        {
            ITraktFavorite traktFavorite = new TraktFavorite
            {
                Rank = 1
            };

            var traktJsonWriter = new FavoriteObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktFavorite);
            json.Should().Be(@"{""rank"":1}");
        }

        [Fact]
        public async Task Test_FavoriteObjectJsonWriter_Movie_WriteObject_Object_Only_ListedAt_Property()
        {
            ITraktFavorite traktFavorite = new TraktFavorite
            {
                ListedAt = LISTED_AT
            };

            var traktJsonWriter = new FavoriteObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktFavorite);
            json.Should().Be($"{{\"listed_at\":\"{LISTED_AT.ToTraktLongDateTimeString()}\"}}");
        }

        [Fact]
        public async Task Test_FavoriteObjectJsonWriter_Movie_WriteObject_Object_Only_Type_Property()
        {
            ITraktFavorite traktFavorite = new TraktFavorite
            {
                Type = TraktFavoriteObjectType.Movie
            };

            var traktJsonWriter = new FavoriteObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktFavorite);
            json.Should().Be(@"{""type"":""movie""}");
        }

        [Fact]
        public async Task Test_FavoriteObjectJsonWriter_Movie_WriteObject_Object_Only_Notes_Property()
        {
            ITraktFavorite traktFavorite = new TraktFavorite
            {
                Notes = "Daft Punk really knocks it out of the park on the soundtrack."
            };

            var traktJsonWriter = new FavoriteObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktFavorite);
            json.Should().Be(@"{""notes"":""Daft Punk really knocks it out of the park on the soundtrack.""}");
        }

        [Fact]
        public async Task Test_FavoriteObjectJsonWriter_Movie_WriteObject_Object_Only_Movie_Property()
        {
            ITraktFavorite traktFavorite = new TraktFavorite
            {
                Movie = new TraktMovie
                {
                    Title = "TRON: Legacy",
                    Year = 2010,
                    Ids = new TraktMovieIds
                    {
                        Trakt = 1U,
                        Slug = "tron-legacy-2010",
                        Imdb = "tt1104001",
                        Tmdb = 20526U
                    }
                }
            };

            var traktJsonWriter = new FavoriteObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktFavorite);
            json.Should().Be(@"{""movie"":{""title"":""TRON: Legacy"",""year"":2010," +
                             @"""ids"":{""trakt"":1,""slug"":""tron-legacy-2010""," +
                             @"""imdb"":""tt1104001"",""tmdb"":20526}}}");
        }

        [Fact]
        public async Task Test_FavoriteObjectJsonWriter_Movie_WriteObject_Object_Complete()
        {
            ITraktFavorite traktFavorite = new TraktFavorite
            {
                Id = 101,
                Rank = 1,
                ListedAt = LISTED_AT,
                Type = TraktFavoriteObjectType.Movie,
                Notes = "Daft Punk really knocks it out of the park on the soundtrack.",
                Movie = new TraktMovie
                {
                    Title = "TRON: Legacy",
                    Year = 2010,
                    Ids = new TraktMovieIds
                    {
                        Trakt = 1U,
                        Slug = "tron-legacy-2010",
                        Imdb = "tt1104001",
                        Tmdb = 20526U
                    }
                }
            };

            var traktJsonWriter = new FavoriteObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktFavorite);
            json.Should().Be(@"{""id"":101,""rank"":1," +
                             $"\"listed_at\":\"{LISTED_AT.ToTraktLongDateTimeString()}\"," +
                             @"""type"":""movie""," +
                             @"""notes"":""Daft Punk really knocks it out of the park on the soundtrack.""," +
                             @"""movie"":{""title"":""TRON: Legacy"",""year"":2010," +
                             @"""ids"":{""trakt"":1,""slug"":""tron-legacy-2010""," +
                             @"""imdb"":""tt1104001"",""tmdb"":20526}}}");
        }
    }
}
