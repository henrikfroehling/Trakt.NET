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

    [TestCategory("Modules.People")]
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

            cast[0].Characters.Should().NotBeNull().And.HaveCount(1).And.Contain("Walter White");
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

            cast[1].Characters.Should().NotBeNull().And.HaveCount(1).And.Contain("Hal");
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

            production[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Producer");
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

            cast[0].Characters.Should().NotBeNull().And.HaveCount(1).And.Contain("Walter White");
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

            cast[1].Characters.Should().NotBeNull().And.HaveCount(1).And.Contain("Hal");
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

            production[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Producer");
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
        public async Task Test_TraktPeopleModule_GetPersonShowCredits_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_SHOW_CREDITS_URI, statusCode);

            try
            {
                await client.People.GetPersonShowCreditsAsync(PERSON_ID);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }
    }
}
