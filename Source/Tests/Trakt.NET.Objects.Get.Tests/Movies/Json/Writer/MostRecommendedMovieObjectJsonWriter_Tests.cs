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
    public partial class MostRecommendedMovieObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_MostRecommendedMovieObjectJsonWriter_WriteObject_Exceptions()
        {
            var traktJsonWriter = new MostRecommendedMovieObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_MostRecommendedMovieObjectJsonWriter_WriteObject_Only_UserCount_Property()
        {
            ITraktMostRecommendedMovie traktMostRecommendedMovie = new TraktMostRecommendedMovie
            {
                UserCount = 76254
            };

            var traktJsonWriter = new MostRecommendedMovieObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktMostRecommendedMovie);
            json.Should().Be(@"{""user_count"":76254}");
        }

        [Fact]
        public async Task Test_MostRecommendedMovieObjectJsonWriter_WriteObject_Only_Movie_Property()
        {
            ITraktMostRecommendedMovie traktMostRecommendedMovie = new TraktMostRecommendedMovie
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

            var traktJsonWriter = new MostRecommendedMovieObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktMostRecommendedMovie);
            json.Should().Be(@"{""movie"":{""title"":""Star Wars: The Force Awakens"",""year"":2015," +
                             @"""ids"":{""trakt"":94024,""slug"":""star-wars-the-force-awakens-2015""," +
                             @"""imdb"":""tt2488496"",""tmdb"":140607}}}");
        }

        [Fact]
        public async Task Test_MostRecommendedMovieObjectJsonWriter_WriteObject_Complete()
        {
            ITraktMostRecommendedMovie traktMostRecommendedMovie = new TraktMostRecommendedMovie
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

            var traktJsonWriter = new MostRecommendedMovieObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktMostRecommendedMovie);
            json.Should().Be(@"{""user_count"":76254," +
                             @"""movie"":{""title"":""Star Wars: The Force Awakens"",""year"":2015," +
                             @"""ids"":{""trakt"":94024,""slug"":""star-wars-the-force-awakens-2015""," +
                             @"""imdb"":""tt2488496"",""tmdb"":140607}}}");
        }
    }
}
