namespace TraktApiSharp.Tests.Modules.TraktMoviesModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.Movies")]
    public partial class TraktMoviesModule_Tests
    {
        [Fact]
        public void Test_TraktMoviesModule_GetSingleMovie()
        {
            const string movieId = "94024";

            TestUtility.SetupMockResponseWithoutOAuth($"movies/{movieId}", MOVIE_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieAsync(movieId).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Title.Should().Be("Star Wars: The Force Awakens");
            responseValue.Year.Should().Be(2015);
            responseValue.Ids.Should().NotBeNull();
            responseValue.Ids.Trakt.Should().Be(94024U);
            responseValue.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            responseValue.Ids.Imdb.Should().Be("tt2488496");
            responseValue.Ids.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetSingleMovieWithExtendedInfo()
        {
            const string movieId = "94024";
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockResponseWithoutOAuth($"movies/{movieId}?extended={extendedInfo}", MOVIE_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieAsync(movieId, extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Title.Should().Be("Star Wars: The Force Awakens");
            responseValue.Year.Should().Be(2015);
            responseValue.Ids.Should().NotBeNull();
            responseValue.Ids.Trakt.Should().Be(94024U);
            responseValue.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            responseValue.Ids.Imdb.Should().Be("tt2488496");
            responseValue.Ids.Tmdb.Should().Be(140607U);
            responseValue.Tagline.Should().Be("Every generation has a story.");
            responseValue.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
            responseValue.Released.Should().Be(DateTime.Parse("2015-12-18"));
            responseValue.Runtime.Should().Be(136);
            responseValue.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            responseValue.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            responseValue.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            responseValue.Rating.Should().Be(8.31988f);
            responseValue.Votes.Should().Be(9338);
            responseValue.LanguageCode.Should().Be("en");
            responseValue.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            responseValue.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            responseValue.Certification.Should().Be("PG-13");
        }

        [Fact]
        public void Test_TraktMoviesModule_GetSingleMovieExceptions()
        {
            const string movieId = "94024";
            var uri = $"movies/{movieId}";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktResponse<ITraktMovie>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieAsync(movieId);
            act.Should().Throw<TraktMovieNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.Should().Throw<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.Should().Throw<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.Should().Throw<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.Should().Throw<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.Should().Throw<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.Should().Throw<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.Should().Throw<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.Should().Throw<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.Should().Throw<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetSingleMovieArgumentExceptions()
        {
            const string movieId = "94024";

            TestUtility.SetupMockResponseWithoutOAuth($"movies/{movieId}", MOVIE_JSON);

            Func<Task<TraktResponse<ITraktMovie>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieAsync(null);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieAsync("movie id");
            act.Should().Throw<ArgumentException>();
        }
    }
}
