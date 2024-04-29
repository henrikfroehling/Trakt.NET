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
    public partial class UserHiddenItemObjectJsonWriter_Tests
    {
        private readonly DateTime HIDDEN_AT = DateTime.UtcNow;

        [Fact]
        public async Task Test_UserHiddenItemObjectJsonWriter_Movie_WriteObject_Object_Only_HiddenAt_Property()
        {
            ITraktUserHiddenItem traktUserHiddenItem = new TraktUserHiddenItem
            {
                HiddenAt = HIDDEN_AT
            };

            var traktJsonWriter = new UserHiddenItemObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktUserHiddenItem);
            json.Should().Be($"{{\"hidden_at\":\"{HIDDEN_AT.ToTraktLongDateTimeString()}\"}}");
        }

        [Fact]
        public async Task Test_UserHiddenItemObjectJsonWriter_Movie_WriteObject_Object_Only_Type_Property()
        {
            ITraktUserHiddenItem traktUserHiddenItem = new TraktUserHiddenItem
            {
                Type = TraktHiddenItemType.Movie
            };

            var traktJsonWriter = new UserHiddenItemObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktUserHiddenItem);
            json.Should().Be(@"{""type"":""movie""}");
        }

        [Fact]
        public async Task Test_UserHiddenItemObjectJsonWriter_Movie_WriteObject_Object_Only_Movie_Property()
        {
            ITraktUserHiddenItem traktUserHiddenItem = new TraktUserHiddenItem
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

            var traktJsonWriter = new UserHiddenItemObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktUserHiddenItem);
            json.Should().Be(@"{""movie"":{""title"":""TRON: Legacy"",""year"":2010," +
                             @"""ids"":{""trakt"":1,""slug"":""tron-legacy-2010""," +
                             @"""imdb"":""tt1104001"",""tmdb"":20526}}}");
        }

        [Fact]
        public async Task Test_UserHiddenItemObjectJsonWriter_Movie_WriteObject_Object_Complete()
        {
            ITraktUserHiddenItem traktUserHiddenItem = new TraktUserHiddenItem
            {
                HiddenAt = HIDDEN_AT,
                Type = TraktHiddenItemType.Movie,
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

            var traktJsonWriter = new UserHiddenItemObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktUserHiddenItem);
            json.Should().Be($"{{\"hidden_at\":\"{HIDDEN_AT.ToTraktLongDateTimeString()}\"," +
                             @"""type"":""movie""," +
                             @"""movie"":{""title"":""TRON: Legacy"",""year"":2010," +
                             @"""ids"":{""trakt"":1,""slug"":""tron-legacy-2010""," +
                             @"""imdb"":""tt1104001"",""tmdb"":20526}}}");
        }
    }
}
