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
        public void Test_TraktPeopleModule_GetPersonMovieCredits()
        {
            const string personId = "297737";

            TestUtility.SetupMockResponseWithoutOAuth($"people/{personId}/movies", PERSON_MOVIE_CREDITS_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.People.GetPersonMovieCreditsAsync(personId).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Cast.Should().NotBeNull().And.HaveCount(2);

            var cast = responseValue.Cast.ToArray();

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

            var directing = responseValue.Crew.Directing.ToArray();

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

            var production = responseValue.Crew.Production.ToArray();

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

            var writing = responseValue.Crew.Writing.ToArray();

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
        public void Test_TraktPeopleModule_GetPersonMovieCreditsWithExtendedInfo()
        {
            const string personId = "297737";

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockResponseWithoutOAuth($"people/{personId}/movies?extended={extendedInfo}",
                                                      PERSON_MOVIE_CREDITS_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.People.GetPersonMovieCreditsAsync(personId, extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Cast.Should().NotBeNull().And.HaveCount(2);

            var cast = responseValue.Cast.ToArray();

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

            var directing = responseValue.Crew.Directing.ToArray();

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

            var production = responseValue.Crew.Production.ToArray();

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

            var writing = responseValue.Crew.Writing.ToArray();

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
        public void Test_TraktPeopleModule_GetPersonMovieCreditsExceptions()
        {
            const string personId = "297737";
            var uri = $"people/{personId}/movies";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktResponse<ITraktPersonMovieCredits>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.People.GetPersonMovieCreditsAsync(personId);
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
        public void Test_TraktPeopleModule_GetPersonMovieCreditsArgumentExceptions()
        {
            const string personId = "297737";

            TestUtility.SetupMockResponseWithoutOAuth($"people/{personId}/movies", PERSON_MOVIE_CREDITS_JSON);

            Func<Task<TraktResponse<ITraktPersonMovieCredits>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.People.GetPersonMovieCreditsAsync(null);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.People.GetPersonMovieCreditsAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.People.GetPersonMovieCreditsAsync("person id");
            act.Should().Throw<ArgumentException>();
        }
    }
}
