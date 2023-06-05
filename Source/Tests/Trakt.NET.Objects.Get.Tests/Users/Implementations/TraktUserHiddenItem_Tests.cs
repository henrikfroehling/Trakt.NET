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
    public class TraktUserHiddenItem_Tests
    {
        [Fact]
        public void Test_TraktUserHiddenItem_Default_Constructor()
        {
            var hiddenItem = new TraktUserHiddenItem();

            hiddenItem.HiddenAt.Should().BeNull();
            hiddenItem.Type.Should().BeNull();
            hiddenItem.Movie.Should().BeNull();
            hiddenItem.Show.Should().BeNull();
            hiddenItem.Season.Should().BeNull();
            hiddenItem.User.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserHiddenItem_With_Type_Movie_Json()
        {
            var jsonReader = new UserHiddenItemObjectJsonReader();
            var hiddenItem = await jsonReader.ReadObjectAsync(HIDDEN_ITEM_MOVIE_JSON) as TraktUserHiddenItem;

            hiddenItem.Should().NotBeNull();
            hiddenItem.HiddenAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            hiddenItem.Type.Should().Be(TraktHiddenItemType.Movie);
            hiddenItem.Movie.Should().NotBeNull();
            hiddenItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            hiddenItem.Movie.Year.Should().Be(2015);
            hiddenItem.Movie.Ids.Should().NotBeNull();
            hiddenItem.Movie.Ids.Trakt.Should().Be(94024U);
            hiddenItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            hiddenItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            hiddenItem.Movie.Ids.Tmdb.Should().Be(140607U);
            hiddenItem.Show.Should().BeNull();
            hiddenItem.Season.Should().BeNull();
            hiddenItem.User.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserHiddenItem_With_Type_Show_Json()
        {
            var jsonReader = new UserHiddenItemObjectJsonReader();
            var hiddenItem = await jsonReader.ReadObjectAsync(HIDDEN_ITEM_SHOW_JSON) as TraktUserHiddenItem;

            hiddenItem.Should().NotBeNull();
            hiddenItem.HiddenAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            hiddenItem.Type.Should().Be(TraktHiddenItemType.Show);
            hiddenItem.Show.Should().NotBeNull();
            hiddenItem.Show.Title.Should().Be("Game of Thrones");
            hiddenItem.Show.Year.Should().Be(2011);
            hiddenItem.Show.Ids.Should().NotBeNull();
            hiddenItem.Show.Ids.Trakt.Should().Be(1390U);
            hiddenItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            hiddenItem.Show.Ids.Tvdb.Should().Be(121361U);
            hiddenItem.Show.Ids.Imdb.Should().Be("tt0944947");
            hiddenItem.Show.Ids.Tmdb.Should().Be(1399U);
            hiddenItem.Show.Ids.TvRage.Should().Be(24493U);
            hiddenItem.Movie.Should().BeNull();
            hiddenItem.Season.Should().BeNull();
            hiddenItem.User.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserHiddenItem_With_Type_Season_Json()
        {
            var jsonReader = new UserHiddenItemObjectJsonReader();
            var hiddenItem = await jsonReader.ReadObjectAsync(HIDDEN_ITEM_SEASON_JSON) as TraktUserHiddenItem;

            hiddenItem.Should().NotBeNull();
            hiddenItem.HiddenAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            hiddenItem.Type.Should().Be(TraktHiddenItemType.Season);
            hiddenItem.Season.Should().NotBeNull();
            hiddenItem.Season.Number.Should().Be(1);
            hiddenItem.Season.Ids.Should().NotBeNull();
            hiddenItem.Season.Ids.Trakt.Should().Be(61430U);
            hiddenItem.Season.Ids.Tvdb.Should().Be(279121U);
            hiddenItem.Season.Ids.Tmdb.Should().Be(60523U);
            hiddenItem.Season.Ids.TvRage.Should().Be(36939U);
            hiddenItem.Movie.Should().BeNull();
            hiddenItem.Show.Should().BeNull();
            hiddenItem.User.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserHiddenItem_With_Type_User_Json()
        {
            var jsonReader = new UserHiddenItemObjectJsonReader();
            var hiddenItem = await jsonReader.ReadObjectAsync(HIDDEN_ITEM_USER_JSON) as TraktUserHiddenItem;

            hiddenItem.Should().NotBeNull();
            hiddenItem.HiddenAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            hiddenItem.Type.Should().Be(TraktHiddenItemType.User);
            hiddenItem.User.Should().NotBeNull();
            hiddenItem.User.Username.Should().Be("sean");
            hiddenItem.User.IsPrivate.Should().BeFalse();
            hiddenItem.User.Name.Should().Be("Sean Rudford");
            hiddenItem.User.IsVIP.Should().BeTrue();
            hiddenItem.User.IsVIP_EP.Should().BeTrue();
            hiddenItem.User.Ids.Should().NotBeNull();
            hiddenItem.User.Ids.Slug.Should().Be("sean");
            hiddenItem.User.Ids.UUID.Should().Be("3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070");
            hiddenItem.Movie.Should().BeNull();
            hiddenItem.Show.Should().BeNull();
            hiddenItem.Season.Should().BeNull();
        }

        private const string HIDDEN_ITEM_MOVIE_JSON =
            @"{
                ""hidden_at"": ""2014-09-01T09:10:11.000Z"",
                ""type"": ""movie"",
                ""movie"": {
                  ""title"": ""Star Wars: The Force Awakens"",
                  ""year"": 2015,
                  ""ids"": {
                    ""trakt"": 94024,
                    ""slug"": ""star-wars-the-force-awakens-2015"",
                    ""imdb"": ""tt2488496"",
                    ""tmdb"": 140607
                  }
                }
              }";

        private const string HIDDEN_ITEM_SHOW_JSON =
            @"{
                ""hidden_at"": ""2014-09-01T09:10:11.000Z"",
                ""type"": ""show"",
                ""show"": {
                  ""title"": ""Game of Thrones"",
                  ""year"": 2011,
                  ""ids"": {
                    ""trakt"": 1390,
                    ""slug"": ""game-of-thrones"",
                    ""tvdb"": 121361,
                    ""imdb"": ""tt0944947"",
                    ""tmdb"": 1399,
                    ""tvrage"": 24493
                  }
                }
              }";

        private const string HIDDEN_ITEM_SEASON_JSON =
            @"{
                ""hidden_at"": ""2014-09-01T09:10:11.000Z"",
                ""type"": ""season"",
                ""season"": {
                  ""number"": 1,
                  ""ids"": {
                    ""trakt"": 61430,
                    ""tvdb"": 279121,
                    ""tmdb"": 60523,
                    ""tvrage"": 36939
                  }
                }
              }";

        private const string HIDDEN_ITEM_USER_JSON =
            @"{
                ""hidden_at"": ""2014-09-01T09:10:11.000Z"",
                ""type"": ""user"",
                ""user"": {
                  ""username"": ""sean"",
                  ""private"": false,
                  ""name"": ""Sean Rudford"",
                  ""vip"": true,
                  ""vip_ep"": true,
                  ""ids"": {
                    ""slug"": ""sean"",
                    ""uuid"": ""3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070""
                  }
                }
              }";
    }
}
