namespace TraktNet.Objects.Get.Tests.Users.Json.Writer
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Extensions;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Get.Users;
    using TraktNet.Objects.Get.Users.Json.Writer;
    using Xunit;

    [TestCategory("Objects.Get.Users.JsonWriter")]
    public partial class FavoriteObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_FavoriteObjectJsonWriter_Show_WriteObject_Object_Only_Id_Property()
        {
            ITraktFavorite traktFavorite = new TraktFavorite
            {
                Id = 102
            };

            var traktJsonWriter = new FavoriteObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktFavorite);
            json.Should().Be(@"{""id"":102}");
        }

        [Fact]
        public async Task Test_FavoriteObjectJsonWriter_Show_WriteObject_Object_Only_Rank_Property()
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
        public async Task Test_FavoriteObjectJsonWriter_Show_WriteObject_Object_Only_ListedAt_Property()
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
        public async Task Test_FavoriteObjectJsonWriter_Show_WriteObject_Object_Only_Type_Property()
        {
            ITraktFavorite traktFavorite = new TraktFavorite
            {
                Type = TraktFavoriteObjectType.Show
            };

            var traktJsonWriter = new FavoriteObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktFavorite);
            json.Should().Be(@"{""type"":""show""}");
        }

        [Fact]
        public async Task Test_FavoriteObjectJsonWriter_Show_WriteObject_Object_Only_Notes_Property()
        {
            ITraktFavorite traktFavorite = new TraktFavorite
            {
                Notes = "Atmospheric for days."
            };

            var traktJsonWriter = new FavoriteObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktFavorite);
            json.Should().Be(@"{""notes"":""Atmospheric for days.""}");
        }

        [Fact]
        public async Task Test_FavoriteObjectJsonWriter_Show_WriteObject_Object_Only_Show_Property()
        {
            ITraktFavorite traktFavorite = new TraktFavorite
            {
                Show = new TraktShow
                {
                    Title = "The Walking Dead",
                    Year = 2010,
                    Ids = new TraktShowIds
                    {
                        Trakt = 2U,
                        Slug = "the-walking-dead",
                        Tvdb = 153021U,
                        Imdb = "tt1520211",
                        Tmdb = 1402U
                    }
                }
            };

            var traktJsonWriter = new FavoriteObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktFavorite);
            json.Should().Be(@"{""show"":{""title"":""The Walking Dead"",""year"":2010," +
                             @"""ids"":{""trakt"":2,""slug"":""the-walking-dead""," +
                             @"""tvdb"":153021,""imdb"":""tt1520211"",""tmdb"":1402}}}");
        }

        [Fact]
        public async Task Test_FavoriteObjectJsonWriter_Show_WriteObject_Object_Complete()
        {
            ITraktFavorite traktFavorite = new TraktFavorite
            {
                Id = 102,
                Rank = 1,
                ListedAt = LISTED_AT,
                Type = TraktFavoriteObjectType.Show,
                Notes = "Atmospheric for days.",
                Show = new TraktShow
                {
                    Title = "The Walking Dead",
                    Year = 2010,
                    Ids = new TraktShowIds
                    {
                        Trakt = 2U,
                        Slug = "the-walking-dead",
                        Tvdb = 153021U,
                        Imdb = "tt1520211",
                        Tmdb = 1402U
                    }
                }
            };

            var traktJsonWriter = new FavoriteObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktFavorite);
            json.Should().Be(@"{""id"":102,""rank"":1," +
                             $"\"listed_at\":\"{LISTED_AT.ToTraktLongDateTimeString()}\"," +
                             @"""type"":""show""," +
                             @"""notes"":""Atmospheric for days.""," +
                             @"""show"":{""title"":""The Walking Dead"",""year"":2010," +
                             @"""ids"":{""trakt"":2,""slug"":""the-walking-dead""," +
                             @"""tvdb"":153021,""imdb"":""tt1520211"",""tmdb"":1402}}}");
        }
    }
}
