namespace TraktApiSharp.Tests.Modules.TraktPeopleModule
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Objects.Get.People.Credits;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.People")]
    public partial class TraktPeopleModule_Tests
    {
        [Fact]
        public void Test_TraktPeopleModule_GetPersonShowCredits()
        {
            const string personId = "297737";

            TestUtility.SetupMockResponseWithoutOAuth($"people/{personId}/shows", PERSON_SHOW_CREDITS_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.People.GetPersonShowCreditsAsync(personId).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Cast.Should().NotBeNull().And.HaveCount(2);

            var cast = responseValue.Cast.ToArray();

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

            var production = responseValue.Crew.Production.ToArray();

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
        public void Test_TraktPeopleModule_GetPersonShowCreditsWithExtendedInfo()
        {
            const string personId = "297737";

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockResponseWithoutOAuth($"people/{personId}/shows?extended={extendedInfo}",
                                                      PERSON_SHOW_CREDITS_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.People.GetPersonShowCreditsAsync(personId, extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Cast.Should().NotBeNull().And.HaveCount(2);

            var cast = responseValue.Cast.ToArray();

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

            var production = responseValue.Crew.Production.ToArray();

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
        public void Test_TraktPeopleModule_GetPersonShowCreditsExceptions()
        {
            const string personId = "297737";
            var uri = $"people/{personId}/shows";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktResponse<ITraktPersonShowCredits>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.People.GetPersonShowCreditsAsync(personId);
            act.Should().Throw<TraktPersonNotFoundException>();

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
        public void Test_TraktPeopleModule_GetPersonShowCreditsArgumentExceptions()
        {
            const string personId = "297737";

            TestUtility.SetupMockResponseWithoutOAuth($"people/{personId}/shows", PERSON_SHOW_CREDITS_JSON);

            Func<Task<TraktResponse<ITraktPersonShowCredits>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.People.GetPersonShowCreditsAsync(null);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.People.GetPersonShowCreditsAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.People.GetPersonShowCreditsAsync("person id");
            act.Should().Throw<ArgumentException>();
        }
    }
}
