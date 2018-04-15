namespace TraktApiSharp.Tests.Modules.TraktShowsModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.Shows")]
    public partial class TraktShowsModule_Tests
    {
        [Fact]
        public void Test_TraktShowsModule_GetShow()
        {
            const string showId = "1390";

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}", SHOW_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowAsync(showId).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Title.Should().Be("Game of Thrones");
            responseValue.Year.Should().Be(2011);
            responseValue.Ids.Should().NotBeNull();
            responseValue.Ids.Trakt.Should().Be(1390U);
            responseValue.Ids.Slug.Should().Be("game-of-thrones");
            responseValue.Ids.Tvdb.Should().Be(121361U);
            responseValue.Ids.Imdb.Should().Be("tt0944947");
            responseValue.Ids.Tmdb.Should().Be(1399U);
            responseValue.Ids.TvRage.Should().Be(24493U);
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowWithExtendedInfo()
        {
            const string showId = "1390";
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}?extended={extendedInfo}", SHOW_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowAsync(showId, extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Title.Should().Be("Game of Thrones");
            responseValue.Year.Should().Be(2011);
            responseValue.Airs.Should().NotBeNull();
            responseValue.Airs.Day.Should().Be("Sunday");
            responseValue.Airs.Time.Should().Be("21:00");
            responseValue.Airs.TimeZoneId.Should().Be("America/New_York");
            responseValue.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            responseValue.Ids.Should().NotBeNull();
            responseValue.Ids.Trakt.Should().Be(1390U);
            responseValue.Ids.Slug.Should().Be("game-of-thrones");
            responseValue.Ids.Tvdb.Should().Be(121361U);
            responseValue.Ids.Imdb.Should().Be("tt0944947");
            responseValue.Ids.Tmdb.Should().Be(1399U);
            responseValue.Ids.TvRage.Should().Be(24493U);
            responseValue.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            responseValue.Seasons.Should().BeNull();
            responseValue.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            responseValue.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            responseValue.Runtime.Should().Be(60);
            responseValue.Certification.Should().Be("TV-MA");
            responseValue.Network.Should().Be("HBO");
            responseValue.CountryCode.Should().Be("us");
            responseValue.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            responseValue.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            responseValue.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            responseValue.Status.Should().Be(TraktShowStatus.ReturningSeries);
            responseValue.Rating.Should().Be(9.38327f);
            responseValue.Votes.Should().Be(44773);
            responseValue.LanguageCode.Should().Be("en");
            responseValue.AiredEpisodes.Should().Be(50);
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowExceptions()
        {
            const string showId = "1390";
            var uri = $"shows/{showId}";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktResponse<ITraktShow>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowAsync(showId);
            act.Should().Throw<TraktShowNotFoundException>();

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
        public void Test_TraktShowsModule_GetShowArgumentExceptions()
        {
            const string showId = "1390";

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}", SHOW_JSON);

            Func<Task<TraktResponse<ITraktShow>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowAsync(null);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowAsync("show id");
            act.Should().Throw<ArgumentException>();
        }
    }
}
