namespace TraktApiSharp.Tests.Modules.TraktMoviesModule
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Modules;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.Movies")]
    public partial class TraktMoviesModule_Tests
    {
        private readonly string GET_MOVIE_URI = $"movies/{MOVIE_ID}";

        [Fact]
        public async Task Test_TraktMoviesModule_GetMovie()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_URI, MOVIE_JSON);
            TraktResponse<ITraktMovie> response = await client.Movies.GetMovieAsync(MOVIE_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktMovie responseValue = response.Value;

            responseValue.Title.Should().Be("Star Wars: The Force Awakens");
            responseValue.Year.Should().Be(2015);
            responseValue.Ids.Should().NotBeNull();
            responseValue.Ids.Trakt.Should().Be(94024U);
            responseValue.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            responseValue.Ids.Imdb.Should().Be("tt2488496");
            responseValue.Ids.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public async Task Test_TraktMoviesModule_GetMovie_With_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_MOVIE_URI}?extended={EXTENDED_INFO}", MOVIE_JSON);
            TraktResponse<ITraktMovie> response = await client.Movies.GetMovieAsync(MOVIE_ID, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktMovie responseValue = response.Value;

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
        public void Test_TraktMoviesModule_GetMovie_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_URI, HttpStatusCode.NotFound);
            Func<Task<TraktResponse<ITraktMovie>>> act = () => client.Movies.GetMovieAsync(MOVIE_ID);
            act.Should().Throw<TraktMovieNotFoundException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovie_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktResponse<ITraktMovie>>> act = () => client.Movies.GetMovieAsync(MOVIE_ID);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovie_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktResponse<ITraktMovie>>> act = () => client.Movies.GetMovieAsync(MOVIE_ID);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovie_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktResponse<ITraktMovie>>> act = () => client.Movies.GetMovieAsync(MOVIE_ID);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovie_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktResponse<ITraktMovie>>> act = () => client.Movies.GetMovieAsync(MOVIE_ID);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovie_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_URI, HttpStatusCode.Conflict);
            Func<Task<TraktResponse<ITraktMovie>>> act = () => client.Movies.GetMovieAsync(MOVIE_ID);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovie_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktResponse<ITraktMovie>>> act = () => client.Movies.GetMovieAsync(MOVIE_ID);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovie_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktResponse<ITraktMovie>>> act = () => client.Movies.GetMovieAsync(MOVIE_ID);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovie_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_URI, (HttpStatusCode)412);
            Func<Task<TraktResponse<ITraktMovie>>> act = () => client.Movies.GetMovieAsync(MOVIE_ID);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovie_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_URI, (HttpStatusCode)422);
            Func<Task<TraktResponse<ITraktMovie>>> act = () => client.Movies.GetMovieAsync(MOVIE_ID);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovie_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_URI, (HttpStatusCode)429);
            Func<Task<TraktResponse<ITraktMovie>>> act = () => client.Movies.GetMovieAsync(MOVIE_ID);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovie_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_URI, (HttpStatusCode)503);
            Func<Task<TraktResponse<ITraktMovie>>> act = () => client.Movies.GetMovieAsync(MOVIE_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovie_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_URI, (HttpStatusCode)504);
            Func<Task<TraktResponse<ITraktMovie>>> act = () => client.Movies.GetMovieAsync(MOVIE_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovie_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_URI, (HttpStatusCode)520);
            Func<Task<TraktResponse<ITraktMovie>>> act = () => client.Movies.GetMovieAsync(MOVIE_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovie_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_URI, (HttpStatusCode)521);
            Func<Task<TraktResponse<ITraktMovie>>> act = () => client.Movies.GetMovieAsync(MOVIE_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovie_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_URI, (HttpStatusCode)522);
            Func<Task<TraktResponse<ITraktMovie>>> act = () => client.Movies.GetMovieAsync(MOVIE_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovie_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_URI, MOVIE_JSON);

            Func<Task<TraktResponse<ITraktMovie>>> act = () => client.Movies.GetMovieAsync(null);
            act.Should().Throw<ArgumentException>();

            act = () => client.Movies.GetMovieAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Movies.GetMovieAsync("movie id");
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMultipleMovies_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_URI, MOVIE_JSON);

            Func<Task<IEnumerable<TraktResponse<ITraktMovie>>>> act = () => TestUtility.MOCK_TEST_CLIENT.Movies.GetMultipleMoviesAsync(null);
            act.Should().NotThrow();

            act = () => TestUtility.MOCK_TEST_CLIENT.Movies.GetMultipleMoviesAsync(new TraktMultipleObjectsQueryParams());
            act.Should().NotThrow();

            act = () => TestUtility.MOCK_TEST_CLIENT.Movies.GetMultipleMoviesAsync(new TraktMultipleObjectsQueryParams { { null } });
            act.Should().Throw<ArgumentException>();

            act = () => TestUtility.MOCK_TEST_CLIENT.Movies.GetMultipleMoviesAsync(new TraktMultipleObjectsQueryParams { { string.Empty } });
            act.Should().Throw<ArgumentException>();

            act = () => TestUtility.MOCK_TEST_CLIENT.Movies.GetMultipleMoviesAsync(new TraktMultipleObjectsQueryParams { { "movie id" } });
            act.Should().Throw<ArgumentException>();
        }
    }
}
