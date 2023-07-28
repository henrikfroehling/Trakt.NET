namespace TraktNet.Modules.Tests.TraktPeopleModule
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.People;
    using TraktNet.Objects.Get.People.Credits;
    using TraktNet.Responses;
    using Xunit;

    [TestCategory("Modules.People")]
    public partial class TraktPeopleModule_Tests
    {
        private readonly string GET_PERSON_MOVIE_CREDITS_URI = $"people/{PERSON_ID}/movies";

        [Fact]
        public async Task Test_TraktPeopleModule_GetPersonMovieCredits()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_MOVIE_CREDITS_URI, PERSON_MOVIE_CREDITS_JSON);
            TraktResponse<ITraktPersonMovieCredits> response = await client.People.GetPersonMovieCreditsAsync(PERSON_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktPersonMovieCredits responseValue = response.Value;
            responseValue.Cast.Should().NotBeNull().And.HaveCount(2);

            ITraktPersonMovieCreditsCastItem[] cast = responseValue.Cast.ToArray();

            cast[0].Characters.Should().NotBeNull().And.HaveCount(1).And.Contain("Li (voice)");
            cast[0].Movie.Should().NotBeNull();
            cast[0].Movie.Title.Should().Be("Kung Fu Panda 3");
            cast[0].Movie.Year.Should().Be(2016);
            cast[0].Movie.Ids.Should().NotBeNull();
            cast[0].Movie.Ids.Trakt.Should().Be(93870U);
            cast[0].Movie.Ids.Slug.Should().Be("kung-fu-panda-3-2016");
            cast[0].Movie.Ids.Imdb.Should().Be("tt2267968");
            cast[0].Movie.Ids.Tmdb.Should().Be(140300U);

            cast[1].Characters.Should().NotBeNull().And.HaveCount(1).And.Contain("Joe Brody");
            cast[1].Movie.Should().NotBeNull();
            cast[1].Movie.Title.Should().Be("Godzilla");
            cast[1].Movie.Year.Should().Be(2014);
            cast[1].Movie.Ids.Should().NotBeNull();
            cast[1].Movie.Ids.Trakt.Should().Be(24U);
            cast[1].Movie.Ids.Slug.Should().Be("godzilla-2014");
            cast[1].Movie.Ids.Imdb.Should().Be("tt0831387");
            cast[1].Movie.Ids.Tmdb.Should().Be(124905U);

            responseValue.Crew.Should().NotBeNull();
            responseValue.Crew.Art.Should().BeNull();
            responseValue.Crew.Camera.Should().BeNull();
            responseValue.Crew.CostumeAndMakeup.Should().BeNull();
            responseValue.Crew.Crew.Should().BeNull();
            responseValue.Crew.Directing.Should().NotBeNull().And.HaveCount(1);

            ITraktPersonMovieCreditsCrewItem[] directing = responseValue.Crew.Directing.ToArray();

            directing[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Director");
            directing[0].Movie.Should().NotBeNull();
            directing[0].Movie.Title.Should().Be("Godzilla");
            directing[0].Movie.Year.Should().Be(2014);
            directing[0].Movie.Ids.Should().NotBeNull();
            directing[0].Movie.Ids.Trakt.Should().Be(24U);
            directing[0].Movie.Ids.Slug.Should().Be("godzilla-2014");
            directing[0].Movie.Ids.Imdb.Should().Be("tt0831387");
            directing[0].Movie.Ids.Tmdb.Should().Be(124905U);

            responseValue.Crew.Editing.Should().BeNull();
            responseValue.Crew.Lighting.Should().BeNull();
            responseValue.Crew.Production.Should().NotBeNull().And.HaveCount(1);

            ITraktPersonMovieCreditsCrewItem[] production = responseValue.Crew.Production.ToArray();

            production[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Producer");
            production[0].Movie.Should().NotBeNull();
            production[0].Movie.Title.Should().Be("Godzilla");
            production[0].Movie.Year.Should().Be(2014);
            production[0].Movie.Ids.Should().NotBeNull();
            production[0].Movie.Ids.Trakt.Should().Be(24U);
            production[0].Movie.Ids.Slug.Should().Be("godzilla-2014");
            production[0].Movie.Ids.Imdb.Should().Be("tt0831387");
            production[0].Movie.Ids.Tmdb.Should().Be(124905U);

            responseValue.Crew.Sound.Should().BeNull();
            responseValue.Crew.VisualEffects.Should().BeNull();
            responseValue.Crew.Writing.Should().NotBeNull().And.HaveCount(1);

            ITraktPersonMovieCreditsCrewItem[] writing = responseValue.Crew.Writing.ToArray();

            writing[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Screenplay");
            writing[0].Movie.Should().NotBeNull();
            writing[0].Movie.Title.Should().Be("Godzilla");
            writing[0].Movie.Year.Should().Be(2014);
            writing[0].Movie.Ids.Should().NotBeNull();
            writing[0].Movie.Ids.Trakt.Should().Be(24U);
            writing[0].Movie.Ids.Slug.Should().Be("godzilla-2014");
            writing[0].Movie.Ids.Imdb.Should().Be("tt0831387");
            writing[0].Movie.Ids.Tmdb.Should().Be(124905U);
        }

        [Fact]
        public async Task Test_TraktPeopleModule_GetPersonMovieCredits_With_TraktID()
        {
            TraktClient client = TestUtility.GetMockClient($"people/{TRAKT_PERSON_ID}/movies", PERSON_MOVIE_CREDITS_JSON);
            TraktResponse<ITraktPersonMovieCredits> response = await client.People.GetPersonMovieCreditsAsync(TRAKT_PERSON_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();
        }

        [Fact]
        public async Task Test_TraktPeopleModule_GetPersonMovieCredits_With_PersonIds_TraktID()
        {
            var personIds = new TraktPersonIds
            {
                Trakt = TRAKT_PERSON_ID
            };

            TraktClient client = TestUtility.GetMockClient($"people/{TRAKT_PERSON_ID}/movies", PERSON_MOVIE_CREDITS_JSON);
            TraktResponse<ITraktPersonMovieCredits> response = await client.People.GetPersonMovieCreditsAsync(personIds);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();
        }

        [Fact]
        public async Task Test_TraktPeopleModule_GetPersonMovieCredits_With_PersonIds_Slug()
        {
            var personIds = new TraktPersonIds
            {
                Slug = PERSON_SLUG
            };

            TraktClient client = TestUtility.GetMockClient($"people/{PERSON_SLUG}/movies", PERSON_MOVIE_CREDITS_JSON);
            TraktResponse<ITraktPersonMovieCredits> response = await client.People.GetPersonMovieCreditsAsync(personIds);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();
        }

        [Fact]
        public async Task Test_TraktPeopleModule_GetPersonMovieCredits_With_PersonIds()
        {
            var personIds = new TraktPersonIds
            {
                Trakt = TRAKT_PERSON_ID,
                Slug = PERSON_SLUG
            };

            TraktClient client = TestUtility.GetMockClient($"people/{TRAKT_PERSON_ID}/movies", PERSON_MOVIE_CREDITS_JSON);
            TraktResponse<ITraktPersonMovieCredits> response = await client.People.GetPersonMovieCreditsAsync(personIds);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();
        }

        [Fact]
        public async Task Test_TraktPeopleModule_GetPersonMovieCredits_With_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_PERSON_MOVIE_CREDITS_URI}?extended={EXTENDED_INFO}", PERSON_MOVIE_CREDITS_JSON);
            TraktResponse<ITraktPersonMovieCredits> response = await client.People.GetPersonMovieCreditsAsync(PERSON_ID, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktPersonMovieCredits responseValue = response.Value;
            responseValue.Cast.Should().NotBeNull().And.HaveCount(2);

            ITraktPersonMovieCreditsCastItem[] cast = responseValue.Cast.ToArray();

            cast[0].Characters.Should().NotBeNull().And.HaveCount(1).And.Contain("Li (voice)");
            cast[0].Movie.Should().NotBeNull();
            cast[0].Movie.Title.Should().Be("Kung Fu Panda 3");
            cast[0].Movie.Year.Should().Be(2016);
            cast[0].Movie.Ids.Should().NotBeNull();
            cast[0].Movie.Ids.Trakt.Should().Be(93870U);
            cast[0].Movie.Ids.Slug.Should().Be("kung-fu-panda-3-2016");
            cast[0].Movie.Ids.Imdb.Should().Be("tt2267968");
            cast[0].Movie.Ids.Tmdb.Should().Be(140300U);

            cast[1].Characters.Should().NotBeNull().And.HaveCount(1).And.Contain("Joe Brody");
            cast[1].Movie.Should().NotBeNull();
            cast[1].Movie.Title.Should().Be("Godzilla");
            cast[1].Movie.Year.Should().Be(2014);
            cast[1].Movie.Ids.Should().NotBeNull();
            cast[1].Movie.Ids.Trakt.Should().Be(24U);
            cast[1].Movie.Ids.Slug.Should().Be("godzilla-2014");
            cast[1].Movie.Ids.Imdb.Should().Be("tt0831387");
            cast[1].Movie.Ids.Tmdb.Should().Be(124905U);

            responseValue.Crew.Should().NotBeNull();
            responseValue.Crew.Art.Should().BeNull();
            responseValue.Crew.Camera.Should().BeNull();
            responseValue.Crew.CostumeAndMakeup.Should().BeNull();
            responseValue.Crew.Crew.Should().BeNull();
            responseValue.Crew.Directing.Should().NotBeNull().And.HaveCount(1);

            ITraktPersonMovieCreditsCrewItem[] directing = responseValue.Crew.Directing.ToArray();

            directing[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Director");
            directing[0].Movie.Should().NotBeNull();
            directing[0].Movie.Title.Should().Be("Godzilla");
            directing[0].Movie.Year.Should().Be(2014);
            directing[0].Movie.Ids.Should().NotBeNull();
            directing[0].Movie.Ids.Trakt.Should().Be(24U);
            directing[0].Movie.Ids.Slug.Should().Be("godzilla-2014");
            directing[0].Movie.Ids.Imdb.Should().Be("tt0831387");
            directing[0].Movie.Ids.Tmdb.Should().Be(124905U);

            responseValue.Crew.Editing.Should().BeNull();
            responseValue.Crew.Lighting.Should().BeNull();
            responseValue.Crew.Production.Should().NotBeNull().And.HaveCount(1);

            ITraktPersonMovieCreditsCrewItem[] production = responseValue.Crew.Production.ToArray();

            production[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Producer");
            production[0].Movie.Should().NotBeNull();
            production[0].Movie.Title.Should().Be("Godzilla");
            production[0].Movie.Year.Should().Be(2014);
            production[0].Movie.Ids.Should().NotBeNull();
            production[0].Movie.Ids.Trakt.Should().Be(24U);
            production[0].Movie.Ids.Slug.Should().Be("godzilla-2014");
            production[0].Movie.Ids.Imdb.Should().Be("tt0831387");
            production[0].Movie.Ids.Tmdb.Should().Be(124905U);

            responseValue.Crew.Sound.Should().BeNull();
            responseValue.Crew.VisualEffects.Should().BeNull();
            responseValue.Crew.Writing.Should().NotBeNull().And.HaveCount(1);

            ITraktPersonMovieCreditsCrewItem[] writing = responseValue.Crew.Writing.ToArray();

            writing[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Screenplay");
            writing[0].Movie.Should().NotBeNull();
            writing[0].Movie.Title.Should().Be("Godzilla");
            writing[0].Movie.Year.Should().Be(2014);
            writing[0].Movie.Ids.Should().NotBeNull();
            writing[0].Movie.Ids.Trakt.Should().Be(24U);
            writing[0].Movie.Ids.Slug.Should().Be("godzilla-2014");
            writing[0].Movie.Ids.Imdb.Should().Be("tt0831387");
            writing[0].Movie.Ids.Tmdb.Should().Be(124905U);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktPersonNotFoundException))]
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
        public async Task Test_TraktPeopleModule_GetPersonMovieCredits_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_MOVIE_CREDITS_URI, statusCode);

            try
            {
                await client.People.GetPersonMovieCreditsAsync(PERSON_ID);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_TraktPeopleModule_GetPersonMovieCredits_Throws_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_MOVIE_CREDITS_URI, PERSON_MOVIE_CREDITS_JSON);

            Func<Task<TraktResponse<ITraktPersonMovieCredits>>> act = () => client.People.GetPersonMovieCreditsAsync(default(ITraktPersonIds));
            await act.Should().ThrowAsync<ArgumentNullException>();

            act = () => client.People.GetPersonMovieCreditsAsync(new TraktPersonIds());
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.People.GetPersonMovieCreditsAsync(0);
            await act.Should().ThrowAsync<ArgumentException>();
        }
    }
}
