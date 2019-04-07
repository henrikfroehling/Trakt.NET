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
        private readonly string GET_PERSON_SHOW_CREDITS_URI = $"people/{PERSON_ID}/shows";

        [Fact]
        public async Task Test_TraktPeopleModule_GetPersonShowCredits()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_SHOW_CREDITS_URI, PERSON_SHOW_CREDITS_JSON);
            TraktResponse<ITraktPersonShowCredits> response = await client.People.GetPersonShowCreditsAsync(PERSON_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktPersonShowCredits responseValue = response.Value;
            responseValue.Cast.Should().NotBeNull().And.HaveCount(2);

            ITraktPersonShowCreditsCastItem[] cast = responseValue.Cast.ToArray();

            cast[0].Character.Should().Be("Walter White");
            cast[0].Show.Should().NotBeNull();
            cast[0].Show.Title.Should().Be("Breaking Bad");
            cast[0].Show.Year.Should().Be(2008);
            cast[0].Show.Ids.Should().NotBeNull();
            cast[0].Show.Ids.Trakt.Should().Be(1U);
            cast[0].Show.Ids.Slug.Should().Be("breaking-bad");
            cast[0].Show.Ids.Tvdb.Should().Be(81189U);
            cast[0].Show.Ids.Imdb.Should().Be("tt0903747");
            cast[0].Show.Ids.Tmdb.Should().Be(1396U);
            cast[0].Show.Ids.TvRage.Should().Be(18164U);

            cast[1].Character.Should().Be("Hal");
            cast[1].Show.Should().NotBeNull();
            cast[1].Show.Title.Should().Be("Malcolm in the Middle");
            cast[1].Show.Year.Should().Be(2000);
            cast[1].Show.Ids.Should().NotBeNull();
            cast[1].Show.Ids.Trakt.Should().Be(1991U);
            cast[1].Show.Ids.Slug.Should().Be("malcolm-in-the-middle");
            cast[1].Show.Ids.Tvdb.Should().Be(73838U);
            cast[1].Show.Ids.Imdb.Should().Be("tt0212671");
            cast[1].Show.Ids.Tmdb.Should().Be(2004U);
            cast[1].Show.Ids.TvRage.Should().BeNull();

            responseValue.Crew.Should().NotBeNull();
            responseValue.Crew.Art.Should().BeNull();
            responseValue.Crew.Camera.Should().BeNull();
            responseValue.Crew.CostumeAndMakeup.Should().BeNull();
            responseValue.Crew.Crew.Should().BeNull();
            responseValue.Crew.Directing.Should().BeNull();
            responseValue.Crew.Editing.Should().BeNull();
            responseValue.Crew.Lighting.Should().BeNull();
            responseValue.Crew.Production.Should().NotBeNull().And.HaveCount(1);

            ITraktPersonShowCreditsCrewItem[] production = responseValue.Crew.Production.ToArray();

            production[0].Job.Should().Be("Producer");
            production[0].Show.Should().NotBeNull();
            production[0].Show.Title.Should().Be("Breaking Bad");
            production[0].Show.Year.Should().Be(2008);
            production[0].Show.Ids.Should().NotBeNull();
            production[0].Show.Ids.Trakt.Should().Be(1U);
            production[0].Show.Ids.Slug.Should().Be("breaking-bad");
            production[0].Show.Ids.Tvdb.Should().Be(81189U);
            production[0].Show.Ids.Imdb.Should().Be("tt0903747");
            production[0].Show.Ids.Tmdb.Should().Be(1396U);
            production[0].Show.Ids.TvRage.Should().Be(18164U);

            responseValue.Crew.Sound.Should().BeNull();
            responseValue.Crew.VisualEffects.Should().BeNull();
            responseValue.Crew.Writing.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktPeopleModule_GetPersonShowCredits_With_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_PERSON_SHOW_CREDITS_URI}?extended={EXTENDED_INFO}", PERSON_SHOW_CREDITS_JSON);
            TraktResponse<ITraktPersonShowCredits> response = await client.People.GetPersonShowCreditsAsync(PERSON_ID, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktPersonShowCredits responseValue = response.Value;
            responseValue.Cast.Should().NotBeNull().And.HaveCount(2);

            ITraktPersonShowCreditsCastItem[] cast = responseValue.Cast.ToArray();

            cast[0].Character.Should().Be("Walter White");
            cast[0].Show.Should().NotBeNull();
            cast[0].Show.Title.Should().Be("Breaking Bad");
            cast[0].Show.Year.Should().Be(2008);
            cast[0].Show.Ids.Should().NotBeNull();
            cast[0].Show.Ids.Trakt.Should().Be(1U);
            cast[0].Show.Ids.Slug.Should().Be("breaking-bad");
            cast[0].Show.Ids.Tvdb.Should().Be(81189U);
            cast[0].Show.Ids.Imdb.Should().Be("tt0903747");
            cast[0].Show.Ids.Tmdb.Should().Be(1396U);
            cast[0].Show.Ids.TvRage.Should().Be(18164U);

            cast[1].Character.Should().Be("Hal");
            cast[1].Show.Should().NotBeNull();
            cast[1].Show.Title.Should().Be("Malcolm in the Middle");
            cast[1].Show.Year.Should().Be(2000);
            cast[1].Show.Ids.Should().NotBeNull();
            cast[1].Show.Ids.Trakt.Should().Be(1991U);
            cast[1].Show.Ids.Slug.Should().Be("malcolm-in-the-middle");
            cast[1].Show.Ids.Tvdb.Should().Be(73838U);
            cast[1].Show.Ids.Imdb.Should().Be("tt0212671");
            cast[1].Show.Ids.Tmdb.Should().Be(2004U);
            cast[1].Show.Ids.TvRage.Should().BeNull();

            responseValue.Crew.Should().NotBeNull();
            responseValue.Crew.Art.Should().BeNull();
            responseValue.Crew.Camera.Should().BeNull();
            responseValue.Crew.CostumeAndMakeup.Should().BeNull();
            responseValue.Crew.Crew.Should().BeNull();
            responseValue.Crew.Directing.Should().BeNull();
            responseValue.Crew.Editing.Should().BeNull();
            responseValue.Crew.Lighting.Should().BeNull();
            responseValue.Crew.Production.Should().NotBeNull().And.HaveCount(1);

            ITraktPersonShowCreditsCrewItem[] production = responseValue.Crew.Production.ToArray();

            production[0].Job.Should().Be("Producer");
            production[0].Show.Should().NotBeNull();
            production[0].Show.Title.Should().Be("Breaking Bad");
            production[0].Show.Year.Should().Be(2008);
            production[0].Show.Ids.Should().NotBeNull();
            production[0].Show.Ids.Trakt.Should().Be(1U);
            production[0].Show.Ids.Slug.Should().Be("breaking-bad");
            production[0].Show.Ids.Tvdb.Should().Be(81189U);
            production[0].Show.Ids.Imdb.Should().Be("tt0903747");
            production[0].Show.Ids.Tmdb.Should().Be(1396U);
            production[0].Show.Ids.TvRage.Should().Be(18164U);

            responseValue.Crew.Sound.Should().BeNull();
            responseValue.Crew.VisualEffects.Should().BeNull();
            responseValue.Crew.Writing.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPersonShowCredits_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_SHOW_CREDITS_URI, HttpStatusCode.NotFound);
            Func<Task<TraktResponse<ITraktPersonShowCredits>>> act = () => client.People.GetPersonShowCreditsAsync(PERSON_ID);
            act.Should().Throw<TraktPersonNotFoundException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPersonShowCredits_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_SHOW_CREDITS_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktResponse<ITraktPersonShowCredits>>> act = () => client.People.GetPersonShowCreditsAsync(PERSON_ID);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPersonShowCredits_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_SHOW_CREDITS_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktResponse<ITraktPersonShowCredits>>> act = () => client.People.GetPersonShowCreditsAsync(PERSON_ID);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPersonShowCredits_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_SHOW_CREDITS_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktResponse<ITraktPersonShowCredits>>> act = () => client.People.GetPersonShowCreditsAsync(PERSON_ID);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPersonShowCredits_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_SHOW_CREDITS_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktResponse<ITraktPersonShowCredits>>> act = () => client.People.GetPersonShowCreditsAsync(PERSON_ID);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPersonShowCredits_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_SHOW_CREDITS_URI, HttpStatusCode.Conflict);
            Func<Task<TraktResponse<ITraktPersonShowCredits>>> act = () => client.People.GetPersonShowCreditsAsync(PERSON_ID);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPersonShowCredits_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_SHOW_CREDITS_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktResponse<ITraktPersonShowCredits>>> act = () => client.People.GetPersonShowCreditsAsync(PERSON_ID);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPersonShowCredits_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_SHOW_CREDITS_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktResponse<ITraktPersonShowCredits>>> act = () => client.People.GetPersonShowCreditsAsync(PERSON_ID);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPersonShowCredits_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_SHOW_CREDITS_URI, (HttpStatusCode)412);
            Func<Task<TraktResponse<ITraktPersonShowCredits>>> act = () => client.People.GetPersonShowCreditsAsync(PERSON_ID);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPersonShowCredits_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_SHOW_CREDITS_URI, (HttpStatusCode)422);
            Func<Task<TraktResponse<ITraktPersonShowCredits>>> act = () => client.People.GetPersonShowCreditsAsync(PERSON_ID);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPersonShowCredits_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_SHOW_CREDITS_URI, (HttpStatusCode)429);
            Func<Task<TraktResponse<ITraktPersonShowCredits>>> act = () => client.People.GetPersonShowCreditsAsync(PERSON_ID);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPersonShowCredits_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_SHOW_CREDITS_URI, (HttpStatusCode)503);
            Func<Task<TraktResponse<ITraktPersonShowCredits>>> act = () => client.People.GetPersonShowCreditsAsync(PERSON_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPersonShowCredits_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_SHOW_CREDITS_URI, (HttpStatusCode)504);
            Func<Task<TraktResponse<ITraktPersonShowCredits>>> act = () => client.People.GetPersonShowCreditsAsync(PERSON_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPersonShowCredits_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_SHOW_CREDITS_URI, (HttpStatusCode)520);
            Func<Task<TraktResponse<ITraktPersonShowCredits>>> act = () => client.People.GetPersonShowCreditsAsync(PERSON_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPersonShowCredits_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_SHOW_CREDITS_URI, (HttpStatusCode)521);
            Func<Task<TraktResponse<ITraktPersonShowCredits>>> act = () => client.People.GetPersonShowCreditsAsync(PERSON_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPersonShowCredits_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_SHOW_CREDITS_URI, (HttpStatusCode)522);
            Func<Task<TraktResponse<ITraktPersonShowCredits>>> act = () => client.People.GetPersonShowCreditsAsync(PERSON_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPersonShowCredits_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_SHOW_CREDITS_URI, PERSON_SHOW_CREDITS_JSON);

            Func<Task<TraktResponse<ITraktPersonShowCredits>>> act = () => client.People.GetPersonShowCreditsAsync(null);
            act.Should().Throw<ArgumentException>();

            act = () => client.People.GetPersonShowCreditsAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.People.GetPersonShowCreditsAsync("person id");
            act.Should().Throw<ArgumentException>();
        }
    }
}
