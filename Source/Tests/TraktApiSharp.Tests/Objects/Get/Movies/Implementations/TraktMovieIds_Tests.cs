namespace TraktApiSharp.Tests.Objects.Get.Movies.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Objects.Get.Movies.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Movies.Implementations")]
    public class TraktMovieIds_Tests
    {
        [Fact]
        public void Test_TraktMovieIds_Default_Constructor()
        {
            var movieIds = new TraktMovieIds();

            movieIds.Trakt.Should().Be(0);
            movieIds.Slug.Should().BeNullOrEmpty();
            movieIds.Imdb.Should().BeNullOrEmpty();
            movieIds.Tmdb.Should().BeNull();
            movieIds.HasAnyId.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktMovieIds_HasAnyId()
        {
            var movieIds = new TraktMovieIds { Trakt = 1 };
            movieIds.HasAnyId.Should().BeTrue();

            movieIds = new TraktMovieIds { Slug = "slug" };
            movieIds.HasAnyId.Should().BeTrue();

            movieIds = new TraktMovieIds { Imdb = "imdb" };
            movieIds.HasAnyId.Should().BeTrue();

            movieIds = new TraktMovieIds { Tmdb = 1 };
            movieIds.HasAnyId.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktMovieIds_GetBestId()
        {
            var movieIds = new TraktMovieIds();

            var bestId = movieIds.GetBestId();
            bestId.Should().NotBeNull().And.BeEmpty();

            movieIds = new TraktMovieIds { Trakt = 1 };

            bestId = movieIds.GetBestId();
            bestId.Should().Be("1");

            movieIds = new TraktMovieIds { Slug = "slug" };

            bestId = movieIds.GetBestId();
            bestId.Should().Be("slug");

            movieIds = new TraktMovieIds { Imdb = "imdb" };

            bestId = movieIds.GetBestId();
            bestId.Should().Be("imdb");

            movieIds = new TraktMovieIds { Tmdb = 1 };

            bestId = movieIds.GetBestId();
            bestId.Should().Be("1");

            movieIds = new TraktMovieIds
            {
                Trakt = 1,
                Slug = "slug",
                Imdb = "imdb",
                Tmdb = 1
            };

            bestId = movieIds.GetBestId();
            bestId.Should().Be("1");

            movieIds = new TraktMovieIds
            {
                Slug = "slug",
                Imdb = "imdb",
                Tmdb = 1
            };

            bestId = movieIds.GetBestId();
            bestId.Should().Be("slug");

            movieIds = new TraktMovieIds
            {
                Imdb = "imdb",
                Tmdb = 1
            };

            bestId = movieIds.GetBestId();
            bestId.Should().Be("imdb");
        }

        [Fact]
        public async Task Test_TraktMovieIds_From_Json()
        {
            var jsonReader = new MovieIdsObjectJsonReader();
            var movieIds = await jsonReader.ReadObjectAsync(JSON) as TraktMovieIds;

            movieIds.Should().NotBeNull();
            movieIds.Trakt.Should().Be(94024);
            movieIds.Slug.Should().Be("star-wars-the-force-awakens-2015");
            movieIds.Imdb.Should().Be("tt2488496");
            movieIds.Tmdb.Should().Be(140607U);
            movieIds.HasAnyId.Should().BeTrue();
        }

        private const string JSON =
            @"{
                ""trakt"": 94024,
                ""slug"": ""star-wars-the-force-awakens-2015"",
                ""imdb"": ""tt2488496"",
                ""tmdb"": 140607
              }";
    }
}
