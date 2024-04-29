namespace TraktNet.Objects.Get.Tests.Shows.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Get.Shows.Json.Writer;
    using Xunit;

    [TestCategory("Objects.Get.Shows.JsonWriter")]
    public partial class MostFavoritedShowObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_MostFavoritedShowObjectJsonWriter_WriteObject_Exceptions()
        {
            var traktJsonWriter = new MostFavoritedShowObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_MostFavoritedShowObjectJsonWriter_WriteObject_Only_UserCount_Property()
        {
            ITraktMostFavoritedShow traktMostFavoritedShow = new TraktMostFavoritedShow
            {
                UserCount = 155291
            };

            var traktJsonWriter = new MostFavoritedShowObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktMostFavoritedShow);
            json.Should().Be(@"{""user_count"":155291}");
        }

        [Fact]
        public async Task Test_MostFavoritedShowObjectJsonWriter_WriteObject_Only_Show_Property()
        {
            ITraktMostFavoritedShow traktMostFavoritedShow = new TraktMostFavoritedShow
            {
                Show = new TraktShow
                {
                    Title = "Game of Thrones",
                    Year = 2011,
                    Ids = new TraktShowIds
                    {
                        Trakt = 1390,
                        Slug = "game-of-thrones",
                        Tvdb = 121361,
                        Imdb = "tt0944947",
                        Tmdb = 1399,
                        TvRage = 24493
                    }
                }
            };

            var traktJsonWriter = new MostFavoritedShowObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktMostFavoritedShow);
            json.Should().Be(@"{""show"":{""title"":""Game of Thrones"",""year"":2011," +
                             @"""ids"":{""trakt"":1390,""slug"":""game-of-thrones""," +
                             @"""tvdb"":121361,""imdb"":""tt0944947"",""tmdb"":1399,""tvrage"":24493}}}");
        }

        [Fact]
        public async Task Test_MostFavoritedShowObjectJsonWriter_WriteObject_Complete()
        {
            ITraktMostFavoritedShow traktMostFavoritedShow = new TraktMostFavoritedShow
            {
                UserCount = 155291,
                Show = new TraktShow
                {
                    Title = "Game of Thrones",
                    Year = 2011,
                    Ids = new TraktShowIds
                    {
                        Trakt = 1390,
                        Slug = "game-of-thrones",
                        Tvdb = 121361,
                        Imdb = "tt0944947",
                        Tmdb = 1399,
                        TvRage = 24493
                    }
                }
            };

            var traktJsonWriter = new MostFavoritedShowObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktMostFavoritedShow);
            json.Should().Be(@"{""user_count"":155291," +
                             @"""show"":{""title"":""Game of Thrones"",""year"":2011," +
                             @"""ids"":{""trakt"":1390,""slug"":""game-of-thrones""," +
                             @"""tvdb"":121361,""imdb"":""tt0944947"",""tmdb"":1399,""tvrage"":24493}}}");
        }
    }
}
