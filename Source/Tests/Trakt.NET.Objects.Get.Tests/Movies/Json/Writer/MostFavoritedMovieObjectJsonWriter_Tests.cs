namespace TraktNet.Objects.Get.Tests.Movies.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Movies.Json.Writer;
    using Xunit;

    [TestCategory("Objects.Get.Movies.JsonWriter")]
    public partial class MostFavoritedMovieObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_MostFavoritedMovieObjectJsonWriter_WriteObject_Exceptions()
        {
            var traktJsonWriter = new MostFavoritedMovieObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_MostFavoritedMovieObjectJsonWriter_WriteObject_Only_UserCount_Property()
        {
            ITraktMostFavoritedMovie traktMostFavoritedMovie = new TraktMostFavoritedMovie
            {
                UserCount = 76254
            };

            var traktJsonWriter = new MostFavoritedMovieObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktMostFavoritedMovie);
            json.Should().Be(@"{""user_count"":76254}");
        }

        [Fact]
        public async Task Test_MostFavoritedMovieObjectJsonWriter_WriteObject_Only_Movie_Property()
        {
            ITraktMostFavoritedMovie traktMostFavoritedMovie = new TraktMostFavoritedMovie
            {
                Movie = new TraktMovie
                {
                    Title = "Star Wars: The Force Awakens",
                    Year = 2015,
                    Ids = new TraktMovieIds
                    {
                        Trakt = 94024,
                        Slug = "star-wars-the-force-awakens-2015",
                        Imdb = "tt2488496",
                        Tmdb = 140607
                    }
                }
            };

            var traktJsonWriter = new MostFavoritedMovieObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktMostFavoritedMovie);
            json.Should().Be(@"{""movie"":{""title"":""Star Wars: The Force Awakens"",""year"":2015," +
                             @"""ids"":{""trakt"":94024,""slug"":""star-wars-the-force-awakens-2015""," +
                             @"""imdb"":""tt2488496"",""tmdb"":140607}}}");
        }

        [Fact]
        public async Task Test_MostFavoritedMovieObjectJsonWriter_WriteObject_Complete()
        {
            ITraktMostFavoritedMovie traktMostFavoritedMovie = new TraktMostFavoritedMovie
            {
                UserCount = 76254,
                Movie = new TraktMovie
                {
                    Title = "Star Wars: The Force Awakens",
                    Year = 2015,
                    Ids = new TraktMovieIds
                    {
                        Trakt = 94024,
                        Slug = "star-wars-the-force-awakens-2015",
                        Imdb = "tt2488496",
                        Tmdb = 140607
                    }
                }
            };

            var traktJsonWriter = new MostFavoritedMovieObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktMostFavoritedMovie);
            json.Should().Be(@"{""user_count"":76254," +
                             @"""movie"":{""title"":""Star Wars: The Force Awakens"",""year"":2015," +
                             @"""ids"":{""trakt"":94024,""slug"":""star-wars-the-force-awakens-2015""," +
                             @"""imdb"":""tt2488496"",""tmdb"":140607}}}");
        }
    }
}
