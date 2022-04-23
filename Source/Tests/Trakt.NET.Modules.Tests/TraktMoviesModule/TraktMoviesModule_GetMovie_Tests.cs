﻿namespace TraktNet.Modules.Tests.TraktMoviesModule
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Modules;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Responses;
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

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktMovieNotFoundException))]
        [InlineData(HttpStatusCode.Unauthorized, typeof(TraktAuthorizationException))]
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktBadRequestException))]
        [InlineData(HttpStatusCode.Forbidden, typeof(TraktForbiddenException))]
        [InlineData(HttpStatusCode.MethodNotAllowed, typeof(TraktMethodNotFoundException))]
        [InlineData(HttpStatusCode.Conflict, typeof(TraktConflictException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktServerException))]
        [InlineData(HttpStatusCode.BadGateway, typeof(TraktBadGatewayException))]
        [InlineData(HttpStatusCode.PreconditionFailed, typeof(TraktPreconditionFailedException))]
        [InlineData(HttpStatusCode.UnprocessableEntity, typeof(TraktValidationException))]
        [InlineData(HttpStatusCode.TooManyRequests, typeof(TraktRateLimitException))]
        [InlineData(HttpStatusCode.ServiceUnavailable, typeof(TraktServerUnavailableException))]
        [InlineData(HttpStatusCode.GatewayTimeout, typeof(TraktServerUnavailableException))]
        [InlineData((HttpStatusCode)520, typeof(TraktServerUnavailableException))]
        [InlineData((HttpStatusCode)521, typeof(TraktServerUnavailableException))]
        [InlineData((HttpStatusCode)522, typeof(TraktServerUnavailableException))]
        public async Task Test_TraktMoviesModule_GetMovie_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_URI, statusCode);

            try
            {
                await client.Movies.GetMovieAsync(MOVIE_ID);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_TraktMoviesModule_GetMovie_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_URI, MOVIE_JSON);

            Func<Task<TraktResponse<ITraktMovie>>> act = () => client.Movies.GetMovieAsync(null);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Movies.GetMovieAsync(string.Empty);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Movies.GetMovieAsync("movie id");
            await act.Should().ThrowAsync<ArgumentException>();
        }

        [Fact]
        public async Task Test_TraktMoviesModule_GetMultipleMovies_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_URI, MOVIE_JSON);

            Func<Task<IEnumerable<TraktResponse<ITraktMovie>>>> act = () => client.Movies.GetMultipleMoviesAsync(null);
            await act.Should().NotThrowAsync();

            act = () => client.Movies.GetMultipleMoviesAsync(new TraktMultipleObjectsQueryParams());
            await act.Should().NotThrowAsync();

            act = () => client.Movies.GetMultipleMoviesAsync(new TraktMultipleObjectsQueryParams { { null } });
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Movies.GetMultipleMoviesAsync(new TraktMultipleObjectsQueryParams { { string.Empty } });
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Movies.GetMultipleMoviesAsync(new TraktMultipleObjectsQueryParams { { "movie id" } });
            await act.Should().ThrowAsync<ArgumentException>();
        }
    }
}
