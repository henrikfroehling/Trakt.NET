namespace TraktApiSharp.Tests.Modules
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Modules;
    using TraktApiSharp.Objects.Get.People;
    using TraktApiSharp.Objects.Get.People.Credits;
    using TraktApiSharp.Requests.Params;
    using Utils;

    [TestClass]
    public class TraktPeopleModuleTests
    {
        [TestMethod]
        public void TestTraktPeopleModuleIsModule()
        {
            typeof(TraktBaseModule).IsAssignableFrom(typeof(TraktPeopleModule)).Should().BeTrue();
        }

        [ClassInitialize]
        public static void InitializeTests(TestContext context)
        {
            TestUtility.SetupMockHttpClient();
        }

        [ClassCleanup]
        public static void CleanupTests()
        {
            TestUtility.ResetMockHttpClient();
        }

        [TestCleanup]
        public void CleanupSingleTest()
        {
            TestUtility.ClearMockHttpClient();
        }

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region SinglePerson

        [TestMethod]
        public void TestTraktPeopleModuleGetPerson()
        {
            var person = TestUtility.ReadFileContents(@"Objects\Get\People\PersonFullAndImages.json");
            person.Should().NotBeNullOrEmpty();

            var personId = "297737";

            TestUtility.SetupMockResponseWithoutOAuth($"people/{personId}", person);

            var response = TestUtility.MOCK_TEST_CLIENT.People.GetPersonAsync(personId).Result;

            response.Should().NotBeNull();
            response.Name.Should().Be("Bryan Cranston");
            response.Ids.Should().NotBeNull();
            response.Ids.Trakt.Should().Be(297737U);
            response.Ids.Slug.Should().Be("bryan-cranston");
            response.Ids.Imdb.Should().Be("nm0186505");
            response.Ids.Tmdb.Should().Be(17419U);
            response.Ids.TvRage.Should().Be(1797U);
        }

        [TestMethod]
        public void TestTraktPeopleModuleGetPersonWithExtendedInfo()
        {
            var person = TestUtility.ReadFileContents(@"Objects\Get\People\PersonFullAndImages.json");
            person.Should().NotBeNullOrEmpty();

            var personId = "297737";

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithoutOAuth($"people/{personId}?extended={extendedInfo.ToString()}", person);

            var response = TestUtility.MOCK_TEST_CLIENT.People.GetPersonAsync(personId, extendedInfo).Result;

            response.Should().NotBeNull();
            response.Name.Should().Be("Bryan Cranston");
            response.Ids.Should().NotBeNull();
            response.Ids.Trakt.Should().Be(297737U);
            response.Ids.Slug.Should().Be("bryan-cranston");
            response.Ids.Imdb.Should().Be("nm0186505");
            response.Ids.Tmdb.Should().Be(17419U);
            response.Ids.TvRage.Should().Be(1797U);
            response.Images.Should().NotBeNull();
            response.Images.Headshot.Should().NotBeNull();
            response.Images.Headshot.Full.Should().Be("https://walter.trakt.us/images/people/000/297/737/headshots/original/47aebaace9.jpg");
            response.Images.Headshot.Medium.Should().Be("https://walter.trakt.us/images/people/000/297/737/headshots/medium/47aebaace9.jpg");
            response.Images.Headshot.Thumb.Should().Be("https://walter.trakt.us/images/people/000/297/737/headshots/thumb/47aebaace9.jpg");
            response.Images.FanArt.Should().NotBeNull();
            response.Images.FanArt.Full.Should().Be("https://walter.trakt.us/images/people/000/297/737/fanarts/original/0e436db5dd.jpg");
            response.Images.FanArt.Medium.Should().Be("https://walter.trakt.us/images/people/000/297/737/fanarts/medium/0e436db5dd.jpg");
            response.Images.FanArt.Thumb.Should().Be("https://walter.trakt.us/images/people/000/297/737/fanarts/thumb/0e436db5dd.jpg");
            response.Biography.Should().Be("Bryan Lee Cranston (born March 7, 1956) is an American actor, voice actor, writer and director.He is perhaps best known for his roles as Hal, the father in the Fox situation comedy \"Malcolm in the Middle\", and as Walter White in the AMC drama series Breaking Bad, for which he has won three consecutive Outstanding Lead Actor in a Drama Series Emmy Awards. Other notable roles include Dr. Tim Whatley on Seinfeld, Doug Heffernan's neighbor in The King of Queens, Astronaut Buzz Aldrin in From the Earth to the Moon, and Ted Mosby's boss on How I Met Your Mother. Description above from the Wikipedia article Bryan Cranston, licensed under CC-BY-SA, full list of contributors on Wikipedia.");
            response.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
            response.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
            response.Age.Should().Be(60);
            response.Birthplace.Should().Be("San Fernando Valley, California, USA");
            response.Homepage.Should().Be("http://www.bryancranston.com/");
        }

        [TestMethod]
        public void TestTraktPeopleModuleGetPersonExceptions()
        {
            var personId = "297737";
            var uri = $"people/{personId}";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPerson>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.People.GetPersonAsync(personId);
            act.ShouldThrow<TraktPersonNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktPeopleModuleGetPersonArgumentExceptions()
        {
            var person = TestUtility.ReadFileContents(@"Objects\Get\People\PersonFullAndImages.json");
            person.Should().NotBeNullOrEmpty();

            var personId = "297737";

            TestUtility.SetupMockResponseWithoutOAuth($"people/{personId}", person);

            Func<Task<TraktPerson>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.People.GetPersonAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.People.GetPersonAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.People.GetPersonAsync("person id");
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region MultiplePerson

        [TestMethod]
        public void TestTraktPeopleModuleGetPersonsArgumentExceptions()
        {
            Func<Task<IEnumerable<TraktPerson>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.People.GetMultiplePersonsAsync(null);
            act.ShouldNotThrow();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.People.GetMultiplePersonsAsync(
                new TraktMultipleObjectsQueryParams());
            act.ShouldNotThrow();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.People.GetMultiplePersonsAsync(
                new TraktMultipleObjectsQueryParams { { null } });
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.People.GetMultiplePersonsAsync(
                new TraktMultipleObjectsQueryParams { { string.Empty } });
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.People.GetMultiplePersonsAsync(
                new TraktMultipleObjectsQueryParams { { "person id" } });
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region PersonMovieCredits

        [TestMethod]
        public void TestTraktPeopleModuleGetPersonMovieCredits()
        {
            var personMovieCredits = TestUtility.ReadFileContents(@"Objects\Get\People\Credits\PersonMovieCredits.json");
            personMovieCredits.Should().NotBeNullOrEmpty();

            var personId = "297737";

            TestUtility.SetupMockResponseWithoutOAuth($"people/{personId}/movies", personMovieCredits);

            var response = TestUtility.MOCK_TEST_CLIENT.People.GetPersonMovieCreditsAsync(personId).Result;

            response.Should().NotBeNull();

            response.Cast.Should().NotBeNull().And.HaveCount(2);

            var cast = response.Cast.ToArray();

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

            response.Crew.Should().NotBeNull();
            response.Crew.Art.Should().BeNull();
            response.Crew.Camera.Should().BeNull();
            response.Crew.CostumeAndMakeup.Should().BeNull();
            response.Crew.Crew.Should().BeNull();
            response.Crew.Directing.Should().NotBeNull().And.HaveCount(1);

            var directing = response.Crew.Directing.ToArray();

            directing[0].Job.Should().Be("Director");
            directing[0].Movie.Should().NotBeNull();
            directing[0].Movie.Title.Should().Be("Godzilla");
            directing[0].Movie.Year.Should().Be(2014);
            directing[0].Movie.Ids.Should().NotBeNull();
            directing[0].Movie.Ids.Trakt.Should().Be(24U);
            directing[0].Movie.Ids.Slug.Should().Be("godzilla-2014");
            directing[0].Movie.Ids.Imdb.Should().Be("tt0831387");
            directing[0].Movie.Ids.Tmdb.Should().Be(124905U);

            response.Crew.Editing.Should().BeNull();
            response.Crew.Lighting.Should().BeNull();
            response.Crew.Production.Should().NotBeNull().And.HaveCount(1);

            var production = response.Crew.Production.ToArray();

            production[0].Job.Should().Be("Producer");
            production[0].Movie.Should().NotBeNull();
            production[0].Movie.Title.Should().Be("Godzilla");
            production[0].Movie.Year.Should().Be(2014);
            production[0].Movie.Ids.Should().NotBeNull();
            production[0].Movie.Ids.Trakt.Should().Be(24U);
            production[0].Movie.Ids.Slug.Should().Be("godzilla-2014");
            production[0].Movie.Ids.Imdb.Should().Be("tt0831387");
            production[0].Movie.Ids.Tmdb.Should().Be(124905U);

            response.Crew.Sound.Should().BeNull();
            response.Crew.VisualEffects.Should().BeNull();
            response.Crew.Writing.Should().NotBeNull().And.HaveCount(1);

            var writing = response.Crew.Writing.ToArray();

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

        [TestMethod]
        public void TestTraktPeopleModuleGetPersonMovieCreditsWithExtendedInfo()
        {
            var personMovieCredits = TestUtility.ReadFileContents(@"Objects\Get\People\Credits\PersonMovieCredits.json");
            personMovieCredits.Should().NotBeNullOrEmpty();

            var personId = "297737";

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithoutOAuth($"people/{personId}/movies?extended={extendedInfo.ToString()}",
                                                      personMovieCredits);

            var response = TestUtility.MOCK_TEST_CLIENT.People.GetPersonMovieCreditsAsync(personId, extendedInfo).Result;

            response.Should().NotBeNull();

            response.Cast.Should().NotBeNull().And.HaveCount(2);

            var cast = response.Cast.ToArray();

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

            response.Crew.Should().NotBeNull();
            response.Crew.Art.Should().BeNull();
            response.Crew.Camera.Should().BeNull();
            response.Crew.CostumeAndMakeup.Should().BeNull();
            response.Crew.Crew.Should().BeNull();
            response.Crew.Directing.Should().NotBeNull().And.HaveCount(1);

            var directing = response.Crew.Directing.ToArray();

            directing[0].Job.Should().Be("Director");
            directing[0].Movie.Should().NotBeNull();
            directing[0].Movie.Title.Should().Be("Godzilla");
            directing[0].Movie.Year.Should().Be(2014);
            directing[0].Movie.Ids.Should().NotBeNull();
            directing[0].Movie.Ids.Trakt.Should().Be(24U);
            directing[0].Movie.Ids.Slug.Should().Be("godzilla-2014");
            directing[0].Movie.Ids.Imdb.Should().Be("tt0831387");
            directing[0].Movie.Ids.Tmdb.Should().Be(124905U);

            response.Crew.Editing.Should().BeNull();
            response.Crew.Lighting.Should().BeNull();
            response.Crew.Production.Should().NotBeNull().And.HaveCount(1);

            var production = response.Crew.Production.ToArray();

            production[0].Job.Should().Be("Producer");
            production[0].Movie.Should().NotBeNull();
            production[0].Movie.Title.Should().Be("Godzilla");
            production[0].Movie.Year.Should().Be(2014);
            production[0].Movie.Ids.Should().NotBeNull();
            production[0].Movie.Ids.Trakt.Should().Be(24U);
            production[0].Movie.Ids.Slug.Should().Be("godzilla-2014");
            production[0].Movie.Ids.Imdb.Should().Be("tt0831387");
            production[0].Movie.Ids.Tmdb.Should().Be(124905U);

            response.Crew.Sound.Should().BeNull();
            response.Crew.VisualEffects.Should().BeNull();
            response.Crew.Writing.Should().NotBeNull().And.HaveCount(1);

            var writing = response.Crew.Writing.ToArray();

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

        [TestMethod]
        public void TestTraktPeopleModuleGetPersonMovieCreditsExceptions()
        {
            var personId = "297737";
            var uri = $"people/{personId}/movies";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPersonMovieCredits>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.People.GetPersonMovieCreditsAsync(personId);
            act.ShouldThrow<TraktPersonNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktPeopleModuleGetPersonMovieCreditsArgumentExceptions()
        {
            var personMovieCredits = TestUtility.ReadFileContents(@"Objects\Get\People\Credits\PersonMovieCredits.json");
            personMovieCredits.Should().NotBeNullOrEmpty();

            var personId = "297737";

            TestUtility.SetupMockResponseWithoutOAuth($"people/{personId}/movies", personMovieCredits);

            Func<Task<TraktPersonMovieCredits>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.People.GetPersonMovieCreditsAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.People.GetPersonMovieCreditsAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.People.GetPersonMovieCreditsAsync("person id");
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region PersonShowCredits

        [TestMethod]
        public void TestTraktPeopleModuleGetPersonShowCredits()
        {
            var personShowCredits = TestUtility.ReadFileContents(@"Objects\Get\People\Credits\PersonShowCredits.json");
            personShowCredits.Should().NotBeNullOrEmpty();

            var personId = "297737";

            TestUtility.SetupMockResponseWithoutOAuth($"people/{personId}/shows", personShowCredits);

            var response = TestUtility.MOCK_TEST_CLIENT.People.GetPersonShowCreditsAsync(personId).Result;

            response.Should().NotBeNull();

            response.Cast.Should().NotBeNull().And.HaveCount(2);

            var cast = response.Cast.ToArray();

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

            response.Crew.Should().NotBeNull();
            response.Crew.Art.Should().BeNull();
            response.Crew.Camera.Should().BeNull();
            response.Crew.CostumeAndMakeup.Should().BeNull();
            response.Crew.Crew.Should().BeNull();
            response.Crew.Directing.Should().BeNull();
            response.Crew.Editing.Should().BeNull();
            response.Crew.Lighting.Should().BeNull();
            response.Crew.Production.Should().NotBeNull().And.HaveCount(1);

            var production = response.Crew.Production.ToArray();

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

            response.Crew.Sound.Should().BeNull();
            response.Crew.VisualEffects.Should().BeNull();
            response.Crew.Writing.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktPeopleModuleGetPersonShowCreditsWithExtendedInfo()
        {
            var personShowCredits = TestUtility.ReadFileContents(@"Objects\Get\People\Credits\PersonShowCredits.json");
            personShowCredits.Should().NotBeNullOrEmpty();

            var personId = "297737";

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithoutOAuth($"people/{personId}/shows?extended={extendedInfo.ToString()}",
                                                      personShowCredits);

            var response = TestUtility.MOCK_TEST_CLIENT.People.GetPersonShowCreditsAsync(personId, extendedInfo).Result;

            response.Should().NotBeNull();

            response.Cast.Should().NotBeNull().And.HaveCount(2);

            var cast = response.Cast.ToArray();

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

            response.Crew.Should().NotBeNull();
            response.Crew.Art.Should().BeNull();
            response.Crew.Camera.Should().BeNull();
            response.Crew.CostumeAndMakeup.Should().BeNull();
            response.Crew.Crew.Should().BeNull();
            response.Crew.Directing.Should().BeNull();
            response.Crew.Editing.Should().BeNull();
            response.Crew.Lighting.Should().BeNull();
            response.Crew.Production.Should().NotBeNull().And.HaveCount(1);

            var production = response.Crew.Production.ToArray();

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

            response.Crew.Sound.Should().BeNull();
            response.Crew.VisualEffects.Should().BeNull();
            response.Crew.Writing.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktPeopleModuleGetPersonShowCreditsExceptions()
        {
            var personId = "297737";
            var uri = $"people/{personId}/shows";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPersonShowCredits>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.People.GetPersonShowCreditsAsync(personId);
            act.ShouldThrow<TraktPersonNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktPeopleModuleGetPersonShowCreditsArgumentExceptions()
        {
            var personShowCredits = TestUtility.ReadFileContents(@"Objects\Get\People\Credits\PersonShowCredits.json");
            personShowCredits.Should().NotBeNullOrEmpty();

            var personId = "297737";

            TestUtility.SetupMockResponseWithoutOAuth($"people/{personId}/shows", personShowCredits);

            Func<Task<TraktPersonShowCredits>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.People.GetPersonShowCreditsAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.People.GetPersonShowCreditsAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.People.GetPersonShowCreditsAsync("person id");
            act.ShouldThrow<ArgumentException>();
        }

        #endregion
    }
}
