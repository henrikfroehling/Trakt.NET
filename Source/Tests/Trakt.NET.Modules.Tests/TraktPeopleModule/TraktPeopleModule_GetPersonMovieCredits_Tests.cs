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
    using TraktNet.Objects.Get.People.Credits;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.People")]
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

            cast[0].Character.Should().Be("Li (voice)");
            cast[0].Movie.Should().NotBeNull();
            cast[0].Movie.Title.Should().Be("Kung Fu Panda 3");
            cast[0].Movie.Year.Should().Be(2016);
            cast[0].Movie.Ids.Should().NotBeNull();
            cast[0].Movie.Ids.Trakt.Should().Be(93870U);
            cast[0].Movie.Ids.Slug.Should().Be("kung-fu-panda-3-2016");
            cast[0].Movie.Ids.Imdb.Should().Be("tt2267968");
            cast[0].Movie.Ids.Tmdb.Should().Be(140300U);

            cast[1].Character.Should().Be("Joe Brody");
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

            directing[0].Job.Should().Be("Director");
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

            production[0].Job.Should().Be("Producer");
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

            writing[0].Job.Should().Be("Screenplay");
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

            cast[0].Character.Should().Be("Li (voice)");
            cast[0].Movie.Should().NotBeNull();
            cast[0].Movie.Title.Should().Be("Kung Fu Panda 3");
            cast[0].Movie.Year.Should().Be(2016);
            cast[0].Movie.Ids.Should().NotBeNull();
            cast[0].Movie.Ids.Trakt.Should().Be(93870U);
            cast[0].Movie.Ids.Slug.Should().Be("kung-fu-panda-3-2016");
            cast[0].Movie.Ids.Imdb.Should().Be("tt2267968");
            cast[0].Movie.Ids.Tmdb.Should().Be(140300U);

            cast[1].Character.Should().Be("Joe Brody");
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

            directing[0].Job.Should().Be("Director");
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

            production[0].Job.Should().Be("Producer");
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

            writing[0].Job.Should().Be("Screenplay");
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
        public void Test_TraktPeopleModule_GetPersonMovieCredits_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_MOVIE_CREDITS_URI, HttpStatusCode.NotFound);
            Func<Task<TraktResponse<ITraktPersonMovieCredits>>> act = () => client.People.GetPersonMovieCreditsAsync(PERSON_ID);
            act.Should().Throw<TraktPersonNotFoundException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPersonMovieCredits_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_MOVIE_CREDITS_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktResponse<ITraktPersonMovieCredits>>> act = () => client.People.GetPersonMovieCreditsAsync(PERSON_ID);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPersonMovieCredits_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_MOVIE_CREDITS_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktResponse<ITraktPersonMovieCredits>>> act = () => client.People.GetPersonMovieCreditsAsync(PERSON_ID);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPersonMovieCredits_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_MOVIE_CREDITS_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktResponse<ITraktPersonMovieCredits>>> act = () => client.People.GetPersonMovieCreditsAsync(PERSON_ID);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPersonMovieCredits_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_MOVIE_CREDITS_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktResponse<ITraktPersonMovieCredits>>> act = () => client.People.GetPersonMovieCreditsAsync(PERSON_ID);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPersonMovieCredits_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_MOVIE_CREDITS_URI, HttpStatusCode.Conflict);
            Func<Task<TraktResponse<ITraktPersonMovieCredits>>> act = () => client.People.GetPersonMovieCreditsAsync(PERSON_ID);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPersonMovieCredits_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_MOVIE_CREDITS_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktResponse<ITraktPersonMovieCredits>>> act = () => client.People.GetPersonMovieCreditsAsync(PERSON_ID);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPersonMovieCredits_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_MOVIE_CREDITS_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktResponse<ITraktPersonMovieCredits>>> act = () => client.People.GetPersonMovieCreditsAsync(PERSON_ID);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPersonMovieCredits_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_MOVIE_CREDITS_URI, (HttpStatusCode)412);
            Func<Task<TraktResponse<ITraktPersonMovieCredits>>> act = () => client.People.GetPersonMovieCreditsAsync(PERSON_ID);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPersonMovieCredits_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_MOVIE_CREDITS_URI, (HttpStatusCode)422);
            Func<Task<TraktResponse<ITraktPersonMovieCredits>>> act = () => client.People.GetPersonMovieCreditsAsync(PERSON_ID);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPersonMovieCredits_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_MOVIE_CREDITS_URI, (HttpStatusCode)429);
            Func<Task<TraktResponse<ITraktPersonMovieCredits>>> act = () => client.People.GetPersonMovieCreditsAsync(PERSON_ID);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPersonMovieCredits_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_MOVIE_CREDITS_URI, (HttpStatusCode)503);
            Func<Task<TraktResponse<ITraktPersonMovieCredits>>> act = () => client.People.GetPersonMovieCreditsAsync(PERSON_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPersonMovieCredits_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_MOVIE_CREDITS_URI, (HttpStatusCode)504);
            Func<Task<TraktResponse<ITraktPersonMovieCredits>>> act = () => client.People.GetPersonMovieCreditsAsync(PERSON_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPersonMovieCredits_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_MOVIE_CREDITS_URI, (HttpStatusCode)520);
            Func<Task<TraktResponse<ITraktPersonMovieCredits>>> act = () => client.People.GetPersonMovieCreditsAsync(PERSON_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPersonMovieCredits_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_MOVIE_CREDITS_URI, (HttpStatusCode)521);
            Func<Task<TraktResponse<ITraktPersonMovieCredits>>> act = () => client.People.GetPersonMovieCreditsAsync(PERSON_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPersonMovieCredits_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_MOVIE_CREDITS_URI, (HttpStatusCode)522);
            Func<Task<TraktResponse<ITraktPersonMovieCredits>>> act = () => client.People.GetPersonMovieCreditsAsync(PERSON_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPersonMovieCredits_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_MOVIE_CREDITS_URI, PERSON_MOVIE_CREDITS_JSON);

            Func<Task<TraktResponse<ITraktPersonMovieCredits>>> act = () => client.People.GetPersonMovieCreditsAsync(null);
            act.Should().Throw<ArgumentException>();

            act = () => client.People.GetPersonMovieCreditsAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.People.GetPersonMovieCreditsAsync("person id");
            act.Should().Throw<ArgumentException>();
        }
    }
}
