namespace TraktApiSharp.Tests.Modules.TraktPeopleModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Objects.Get.People;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.People")]
    public partial class TraktPeopleModule_Tests
    {
        [Fact]
        public void Test_TraktPeopleModule_GetPerson()
        {
            const string personId = "297737";

            TestUtility.SetupMockResponseWithoutOAuth($"people/{personId}", PERSON_MINIMAL_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.People.GetPersonAsync(personId).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Name.Should().Be("Bryan Cranston");
            responseValue.Ids.Should().NotBeNull();
            responseValue.Ids.Trakt.Should().Be(297737U);
            responseValue.Ids.Slug.Should().Be("bryan-cranston");
            responseValue.Ids.Imdb.Should().Be("nm0186505");
            responseValue.Ids.Tmdb.Should().Be(17419U);
            responseValue.Ids.TvRage.Should().Be(1797U);
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPersonWithExtendedInfo()
        {
            const string personId = "297737";

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockResponseWithoutOAuth($"people/{personId}?extended={extendedInfo}", PERSON_FULL_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.People.GetPersonAsync(personId, extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Name.Should().Be("Bryan Cranston");
            responseValue.Ids.Should().NotBeNull();
            responseValue.Ids.Trakt.Should().Be(297737U);
            responseValue.Ids.Slug.Should().Be("bryan-cranston");
            responseValue.Ids.Imdb.Should().Be("nm0186505");
            responseValue.Ids.Tmdb.Should().Be(17419U);
            responseValue.Ids.TvRage.Should().Be(1797U);
            responseValue.Biography.Should().Be("Bryan Lee Cranston (born March 7, 1956) is an American actor, voice actor, writer and director.He is perhaps best known for his roles as Hal, the father in the Fox situation comedy \"Malcolm in the Middle\", and as Walter White in the AMC drama series Breaking Bad, for which he has won three consecutive Outstanding Lead Actor in a Drama Series Emmy Awards. Other notable roles include Dr. Tim Whatley on Seinfeld, Doug Heffernan's neighbor in The King of Queens, Astronaut Buzz Aldrin in From the Earth to the Moon, and Ted Mosby's boss on How I Met Your Mother. Description above from the Wikipedia article Bryan Cranston, licensed under CC-BY-SA, full list of contributors on Wikipedia.");
            responseValue.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
            responseValue.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
            responseValue.Age.Should().Be(60);
            responseValue.Birthplace.Should().Be("San Fernando Valley, California, USA");
            responseValue.Homepage.Should().Be("http://www.bryancranston.com/");
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPersonExceptions()
        {
            const string personId = "297737";
            var uri = $"people/{personId}";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktResponse<ITraktPerson>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.People.GetPersonAsync(personId);
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
        public void Test_TraktPeopleModule_GetPersonArgumentExceptions()
        {
            const string personId = "297737";

            TestUtility.SetupMockResponseWithoutOAuth($"people/{personId}", PERSON_FULL_JSON);

            Func<Task<TraktResponse<ITraktPerson>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.People.GetPersonAsync(null);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.People.GetPersonAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.People.GetPersonAsync("person id");
            act.Should().Throw<ArgumentException>();
        }
    }
}
