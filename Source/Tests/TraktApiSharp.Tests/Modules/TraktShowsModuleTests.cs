namespace TraktApiSharp.Tests.Modules
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Modules;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Requests;
    using Utils;

    [TestClass]
    public class TraktShowsModuleTests
    {
        [TestMethod]
        public void TestTraktShowsModuleIsModule()
        {
            typeof(TraktBaseModule).IsAssignableFrom(typeof(TraktShowsModule)).Should().BeTrue();
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

        #region SingleShow

        [TestMethod]
        public void TestTraktShowsModuleGetShow()
        {
            var show = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowSummaryFullAndImages.json");
            show.Should().NotBeNullOrEmpty();

            var showId = "1390";

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}", show);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowAsync(showId).Result;

            response.Should().NotBeNull();
            response.Title.Should().Be("Game of Thrones");
            response.Year.Should().Be(2011);
            response.Ids.Should().NotBeNull();
            response.Ids.Trakt.Should().Be(1390);
            response.Ids.Slug.Should().Be("game-of-thrones");
            response.Ids.Tvdb.Should().Be(121361);
            response.Ids.Imdb.Should().Be("tt0944947");
            response.Ids.Tmdb.Should().Be(1399);
            response.Ids.TvRage.Should().Be(24493);
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowWithExtendedOption()
        {
            var show = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowSummaryFullAndImages.json");
            show.Should().NotBeNullOrEmpty();

            var showId = "1390";

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}?extended={extendedOption.ToString()}", show);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowAsync(showId, extendedOption).Result;

            response.Should().NotBeNull();
            response.Title.Should().Be("Game of Thrones");
            response.Year.Should().Be(2011);
            response.Airs.Should().NotBeNull();
            response.Airs.Day.Should().Be("Sunday");
            response.Airs.Time.Should().Be("21:00");
            response.Airs.TimeZoneId.Should().Be("America/New_York");
            response.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            response.Ids.Should().NotBeNull();
            response.Ids.Trakt.Should().Be(1390);
            response.Ids.Slug.Should().Be("game-of-thrones");
            response.Ids.Tvdb.Should().Be(121361);
            response.Ids.Imdb.Should().Be("tt0944947");
            response.Ids.Tmdb.Should().Be(1399);
            response.Ids.TvRage.Should().Be(24493);
            response.Images.Should().NotBeNull();
            response.Images.FanArt.Full.Should().Be("https://walter.trakt.us/images/shows/000/001/390/fanarts/original/76d5df8aed.jpg");
            response.Images.FanArt.Medium.Should().Be("https://walter.trakt.us/images/shows/000/001/390/fanarts/medium/76d5df8aed.jpg");
            response.Images.FanArt.Thumb.Should().Be("https://walter.trakt.us/images/shows/000/001/390/fanarts/thumb/76d5df8aed.jpg");
            response.Images.Poster.Full.Should().Be("https://walter.trakt.us/images/shows/000/001/390/posters/original/93df9cd612.jpg");
            response.Images.Poster.Medium.Should().Be("https://walter.trakt.us/images/shows/000/001/390/posters/medium/93df9cd612.jpg");
            response.Images.Poster.Thumb.Should().Be("https://walter.trakt.us/images/shows/000/001/390/posters/thumb/93df9cd612.jpg");
            response.Images.Logo.Full.Should().Be("https://walter.trakt.us/images/shows/000/001/390/logos/original/13b614ad43.png");
            response.Images.ClearArt.Full.Should().Be("https://walter.trakt.us/images/shows/000/001/390/cleararts/original/5cbde9e647.png");
            response.Images.Banner.Full.Should().Be("https://walter.trakt.us/images/shows/000/001/390/banners/original/9fefff703d.jpg");
            response.Images.Thumb.Full.Should().Be("https://walter.trakt.us/images/shows/000/001/390/thumbs/original/7beccbd5a1.jpg");
            response.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            response.Seasons.Should().BeNull();
            response.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            response.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            response.Runtime.Should().Be(60);
            response.Certification.Should().Be("TV-MA");
            response.Network.Should().Be("HBO");
            response.CountryCode.Should().Be("us");
            response.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            response.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            response.TrailerUri.Should().NotBeNull();
            response.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            response.HomepageUri.Should().NotBeNull();
            response.Status.Should().Be(TraktShowStatus.ReturningSeries);
            response.Rating.Should().Be(9.38327f);
            response.Votes.Should().Be(44773);
            response.LanguageCode.Should().Be("en");
            response.AiredEpisodes.Should().Be(50);
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowExceptions()
        {
            var showId = "1390";
            var uri = $"shows/{showId}";

            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktShow>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowAsync(showId);
            act.ShouldThrow<TraktShowNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowArgumentExceptions()
        {
            var show = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowSummaryFullAndImages.json");
            show.Should().NotBeNullOrEmpty();

            var showId = "1390";

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}", show);

            Func<Task<TraktShow>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region MultipleShows

        [TestMethod]
        public void TestTraktShowsModuleGetShowsArgumentExceptions()
        {
            Func<Task<TraktListResult<TraktShow>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowsAsync(new string[] { null });
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowsAsync(new string[] { string.Empty });
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowsAsync(new string[] { });
            act.ShouldNotThrow();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowsAsync(null);
            act.ShouldNotThrow();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region ShowAliases

        [TestMethod]
        public void TestTraktShowsModuleGetShowAliases()
        {
            var showAliases = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowAliases.json");
            showAliases.Should().NotBeNullOrEmpty();

            var showId = "1390";

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/aliases", showAliases);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowAliasesAsync(showId).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(8);
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowAliasesExceptions()
        {
            var showId = "1390";
            var uri = $"shows/{showId}/aliases";

            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktListResult<TraktShowAlias>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowAliasesAsync(showId);
            act.ShouldThrow<TraktShowNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowAliasesArgumentExceptions()
        {
            var showAliases = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowAliases.json");
            showAliases.Should().NotBeNullOrEmpty();

            var showId = "1390";

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/aliases", showAliases);

            Func<Task<TraktListResult<TraktShowAlias>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowAliasesAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowAliasesAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region ShowTranslations

        [TestMethod]
        public void TestTraktShowsModuleGetShowTranslations()
        {
            var showTranslations = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowTranslations.json");
            showTranslations.Should().NotBeNullOrEmpty();

            var showId = "1390";

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/translations", showTranslations);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowTranslationsAsync(showId).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(4);
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowTranslationsExceptions()
        {
            var showId = "1390";
            var uri = $"shows/{showId}/translations";

            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktListResult<TraktShowTranslation>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowTranslationsAsync(showId);
            act.ShouldThrow<TraktShowNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowTranslationsArgumentExceptions()
        {
            var showTranslations = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowTranslations.json");
            showTranslations.Should().NotBeNullOrEmpty();

            var showId = "1390";

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/translations", showTranslations);

            Func<Task<TraktListResult<TraktShowTranslation>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowTranslationsAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowTranslationsAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region ShowSingleTranslation

        [TestMethod]
        public void TestTraktShowsModuleGetShowSingleTranslation()
        {
            var showTranslation = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowSingleTranslation.json");
            showTranslation.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var languageCode = "de";

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/translations/{languageCode}", showTranslation);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowSingleTranslationAsync(showId, languageCode).Result;

            response.Should().NotBeNull();
            response.Title.Should().Be("Game of Thrones");
            response.Overview.Should().Be("Die Handlung ist in einer fiktiven Welt angesiedelt und spielt auf den Kontinenten Westeros (den Sieben Königreichen sowie im Gebiet der „Mauer“ und jenseits davon im Norden) und Essos. In dieser Welt ist die Länge der Sommer und Winter unvorhersehbar und variabel; eine Jahreszeit kann Jahre oder sogar Jahrzehnte dauern. Der Handlungsort auf dem Kontinent Westeros in den Sieben Königreichen ähnelt dabei stark dem mittelalterlichen Europa. Die Geschichte spielt am Ende eines langen Sommers und wird in drei Handlungssträngen weitgehend parallel erzählt. In den Sieben Königreichen bauen sich zwischen den mächtigsten Adelshäusern des Reiches Spannungen auf, die schließlich zum offenen Thronkampf führen. Gleichzeitig droht der Wintereinbruch und es zeichnet sich eine Gefahr durch eine fremde Rasse im hohen Norden von Westeros ab. Der dritte Handlungsstrang spielt auf dem Kontinent Essos, wo Daenerys Targaryen, Mitglied der vor Jahren abgesetzten Königsfamilie, bestrebt ist, wieder an die Macht zu gelangen. Die komplexe Handlung umfasst zahlreiche Figuren und thematisiert unter anderem Politik und Machtkämpfe, Gesellschaftsverhältnisse und Religion.");
            response.LanguageCode.Should().Be("de");
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowSingleTranslationExceptions()
        {
            var showId = "1390";
            var languageCode = "de";
            var uri = $"shows/{showId}/translations/{languageCode}";

            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktShowTranslation>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowSingleTranslationAsync(showId, languageCode);
            act.ShouldThrow<TraktShowNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowSingleTranslationArgumentExceptions()
        {
            var showTranslation = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowSingleTranslation.json");
            showTranslation.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var languageCode = "de";

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/translations/{languageCode}", showTranslation);

            Func<Task<TraktShowTranslation>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowSingleTranslationAsync(null, languageCode);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowSingleTranslationAsync(string.Empty, languageCode);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowSingleTranslationAsync(showId, null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowSingleTranslationAsync(showId, string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowSingleTranslationAsync(showId, "d");
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowSingleTranslationAsync(showId, "deu");
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region ShowComments

        [TestMethod]
        public void TestTraktShowsModuleGetShowComments()
        {
            var showComments = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowComments.json");
            showComments.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var itemCount = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/comments",
                                                                showComments, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowCommentsAsync(showId).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().Be(itemCount);
            response.Limit.Should().Be(10);
            response.Page.Should().Be(1);
            response.PageCount.Should().Be(1);
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowCommentsWithSortOrder()
        {
            var showComments = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowComments.json");
            showComments.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var itemCount = 2;
            var sortOrder = TraktCommentSortOrder.Likes;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/comments/{sortOrder.AsString()}",
                                                                showComments, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowCommentsAsync(showId, sortOrder).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().Be(itemCount);
            response.Limit.Should().Be(10);
            response.Page.Should().Be(1);
            response.PageCount.Should().Be(1);
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowCommentsWithPage()
        {
            var showComments = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowComments.json");
            showComments.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var itemCount = 2;
            var page = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/comments?page={page}",
                                                                showComments, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowCommentsAsync(showId, null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().Be(itemCount);
            response.Limit.Should().Be(10);
            response.Page.Should().Be(page);
            response.PageCount.Should().Be(1);
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowCommentsWithSortOrderAndPage()
        {
            var showComments = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowComments.json");
            showComments.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var itemCount = 2;
            var page = 2;
            var sortOrder = TraktCommentSortOrder.Likes;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/comments/{sortOrder.AsString()}?page={page}",
                                                                showComments, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowCommentsAsync(showId, sortOrder, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().Be(itemCount);
            response.Limit.Should().Be(10);
            response.Page.Should().Be(page);
            response.PageCount.Should().Be(1);
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowCommentsWithLimit()
        {
            var showComments = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowComments.json");
            showComments.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var itemCount = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/comments?limit={limit}",
                                                                showComments, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowCommentsAsync(showId, null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1);
            response.PageCount.Should().Be(1);
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowCommentsWithSortOrderAndLimit()
        {
            var showComments = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowComments.json");
            showComments.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var itemCount = 2;
            var limit = 4;
            var sortOrder = TraktCommentSortOrder.Likes;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/comments/{sortOrder.AsString()}?limit={limit}",
                                                                showComments, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowCommentsAsync(showId, sortOrder, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1);
            response.PageCount.Should().Be(1);
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowCommentsWithPageAndLimit()
        {
            var showComments = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowComments.json");
            showComments.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var itemCount = 2;
            var page = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/comments?page={page}&limit={limit}",
                                                                showComments, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowCommentsAsync(showId, null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().Be(1);
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowCommentsComplete()
        {
            var showComments = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowComments.json");
            showComments.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var itemCount = 2;
            var page = 2;
            var limit = 4;
            var sortOrder = TraktCommentSortOrder.Likes;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/comments/{sortOrder.AsString()}?page={page}&limit={limit}",
                                                                showComments, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowCommentsAsync(showId, sortOrder, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().Be(1);
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowCommentsExceptions()
        {
            var showId = "1390";
            var uri = $"shows/{showId}/comments";

            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPaginationListResult<TraktShowComment>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowCommentsAsync(showId);
            act.ShouldThrow<TraktShowNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowCommentsArgumentExceptions()
        {
            var showComments = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowComments.json");
            showComments.Should().NotBeNullOrEmpty();

            var showId = "1390";

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/comments", showComments);

            Func<Task<TraktPaginationListResult<TraktShowComment>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowCommentsAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowCommentsAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region ShowPeople

        [TestMethod]
        public void TestTraktShowsModuleGetShowPeople()
        {
            var showPeople = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowPeople.json");
            showPeople.Should().NotBeNullOrEmpty();

            var showId = "1390";

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/people", showPeople);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowPeopleAsync(showId).Result;

            response.Should().NotBeNull();
            response.Cast.Should().NotBeNull().And.HaveCount(3);
            response.Crew.Should().NotBeNull();
            response.Crew.Production.Should().NotBeNull().And.HaveCount(2);
            response.Crew.Art.Should().NotBeNull().And.HaveCount(1);
            response.Crew.Crew.Should().NotBeNull().And.HaveCount(1);
            response.Crew.CostumeAndMakeup.Should().BeNull();
            response.Crew.Directing.Should().BeNull();
            response.Crew.Writing.Should().NotBeNull().And.HaveCount(3);
            response.Crew.Sound.Should().NotBeNull().And.HaveCount(1);
            response.Crew.Camera.Should().BeNull();
            response.Crew.Lighting.Should().BeNull();
            response.Crew.VisualEffects.Should().BeNull();
            response.Crew.Editing.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowPeopleWithExtendedOption()
        {
            var showPeople = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowPeople.json");
            showPeople.Should().NotBeNullOrEmpty();

            var showId = "1390";

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/people?extended={extendedOption.ToString()}", showPeople);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowPeopleAsync(showId, extendedOption).Result;

            response.Should().NotBeNull();
            response.Cast.Should().NotBeNull().And.HaveCount(3);
            response.Crew.Should().NotBeNull();
            response.Crew.Production.Should().NotBeNull().And.HaveCount(2);
            response.Crew.Art.Should().NotBeNull().And.HaveCount(1);
            response.Crew.Crew.Should().NotBeNull().And.HaveCount(1);
            response.Crew.CostumeAndMakeup.Should().BeNull();
            response.Crew.Directing.Should().BeNull();
            response.Crew.Writing.Should().NotBeNull().And.HaveCount(3);
            response.Crew.Sound.Should().NotBeNull().And.HaveCount(1);
            response.Crew.Camera.Should().BeNull();
            response.Crew.Lighting.Should().BeNull();
            response.Crew.VisualEffects.Should().BeNull();
            response.Crew.Editing.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowPeopleExceptions()
        {
            var showId = "1390";
            var uri = $"shows/{showId}/people";

            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktShowPeople>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowPeopleAsync(showId);
            act.ShouldThrow<TraktShowNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowPeopleArgumentExceptions()
        {
            var showPeople = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowPeople.json");
            showPeople.Should().NotBeNullOrEmpty();

            var showId = "1390";

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/people", showPeople);

            Func<Task<TraktShowPeople>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowPeopleAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowPeopleAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region ShowRatings

        [TestMethod]
        public void TestTraktShowsModuleGetShowRatings()
        {
            var showRatings = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowRatings.json");
            showRatings.Should().NotBeNullOrEmpty();

            var showId = "1390";

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/ratings", showRatings);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowRatingsAsync(showId).Result;

            response.Should().NotBeNull();
            response.Rating.Should().Be(9.38231f);
            response.Votes.Should().Be(44590);

            var distribution = new Dictionary<string, int>()
            {
                { "1",  258 }, { "2", 57 }, { "3", 59 }, { "4", 116 }, { "5", 262 },
                { "6",  448 }, { "7", 1427 }, { "8", 3893 }, { "9", 8467 }, { "10", 29590 }
            };

            response.Distribution.Should().HaveCount(10).And.Contain(distribution);
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowRatingsExceptions()
        {
            var showId = "1390";
            var uri = $"shows/{showId}/ratings";

            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktShowRating>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowRatingsAsync(showId);
            act.ShouldThrow<TraktShowNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowRatingsArgumentExceptions()
        {
            var showRatings = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowRatings.json");
            showRatings.Should().NotBeNullOrEmpty();

            var showId = "1390";

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/ratings", showRatings);

            Func<Task<TraktShowRating>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowRatingsAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowRatingsAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region ShowRelatedShows

        [TestMethod]
        public void TestTraktShowsModuleGetShowRelatedShows()
        {
            var showRelatedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowRelatedShowsFullAndImages.json");
            showRelatedShows.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var itemCount = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/related", showRelatedShows, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowRelatedShowsAsync(showId).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().Be(itemCount);
            response.Limit.Should().Be(10);
            response.Page.Should().Be(1);
            response.PageCount.Should().Be(1);
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowRelatedShowsWithExtendedOption()
        {
            var showRelatedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowRelatedShowsFullAndImages.json");
            showRelatedShows.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var itemCount = 2;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/related?extended={extendedOption.ToString()}",
                                                                showRelatedShows, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowRelatedShowsAsync(showId, extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().Be(itemCount);
            response.Limit.Should().Be(10);
            response.Page.Should().Be(1);
            response.PageCount.Should().Be(1);
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowRelatedShowsWithPage()
        {
            var showRelatedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowRelatedShowsFullAndImages.json");
            showRelatedShows.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var itemCount = 2;
            var page = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/related?page={page}", showRelatedShows, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowRelatedShowsAsync(showId, null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().Be(itemCount);
            response.Limit.Should().Be(10);
            response.Page.Should().Be(page);
            response.PageCount.Should().Be(1);
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowRelatedShowsWithExtendedOptionAndPage()
        {
            var showRelatedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowRelatedShowsFullAndImages.json");
            showRelatedShows.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var itemCount = 2;
            var page = 2;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/related?extended={extendedOption.ToString()}&page={page}",
                                                                showRelatedShows, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowRelatedShowsAsync(showId, extendedOption, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().Be(itemCount);
            response.Limit.Should().Be(10);
            response.Page.Should().Be(page);
            response.PageCount.Should().Be(1);
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowRelatedShowsWithLimit()
        {
            var showRelatedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowRelatedShowsFullAndImages.json");
            showRelatedShows.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var itemCount = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/related?limit={limit}", showRelatedShows, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowRelatedShowsAsync(showId, null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1);
            response.PageCount.Should().Be(1);
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowRelatedShowsWithExtendedOptionAndLimit()
        {
            var showRelatedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowRelatedShowsFullAndImages.json");
            showRelatedShows.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var itemCount = 2;
            var limit = 4;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/related?extended={extendedOption.ToString()}&limit={limit}",
                                                                showRelatedShows, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowRelatedShowsAsync(showId, extendedOption, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1);
            response.PageCount.Should().Be(1);
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowRelatedShowsWithPageAndLimit()
        {
            var showRelatedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowRelatedShowsFullAndImages.json");
            showRelatedShows.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var itemCount = 2;
            var page = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/related?page={page}&limit={limit}",
                                                                showRelatedShows, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowRelatedShowsAsync(showId, null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().Be(1);
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowRelatedShowsComplete()
        {
            var showRelatedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowRelatedShowsFullAndImages.json");
            showRelatedShows.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var itemCount = 2;
            var page = 2;
            var limit = 4;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/related?extended={extendedOption.ToString()}&page={page}&limit={limit}",
                                                                showRelatedShows, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowRelatedShowsAsync(showId, extendedOption, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().Be(1);
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowRelatedShowsExceptions()
        {
            var showId = "1390";
            var uri = $"shows/{showId}/related";

            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPaginationListResult<TraktShow>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowRelatedShowsAsync(showId);
            act.ShouldThrow<TraktShowNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowRelatedShowsArgumentExceptions()
        {
            var showRelatedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowRelatedShowsFullAndImages.json");
            showRelatedShows.Should().NotBeNullOrEmpty();

            var showId = "1390";

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/related", showRelatedShows);

            Func<Task<TraktPaginationListResult<TraktShow>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowRelatedShowsAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowRelatedShowsAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region ShowStatistics

        [TestMethod]
        public void TestTraktShowsModuleGetShowStatistics()
        {
            var showStatistics = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowStatistics.json");
            showStatistics.Should().NotBeNullOrEmpty();

            var showId = "1390";

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/stats", showStatistics);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowStatisticsAsync(showId).Result;

            response.Should().NotBeNull();
            response.Watchers.Should().Be(265955);
            response.Plays.Should().Be(12491168);
            response.Collectors.Should().Be(106028);
            response.CollectedEpisodes.Should().Be(4092901);
            response.Comments.Should().Be(233);
            response.Lists.Should().Be(103943);
            response.Votes.Should().Be(44590);
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowStatisticsExceptions()
        {
            var showId = "1390";
            var uri = $"shows/{showId}/stats";

            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktShowStatistics>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowStatisticsAsync(showId);
            act.ShouldThrow<TraktShowNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowStatisticsArgumentExceptions()
        {
            var showStatistics = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowStatistics.json");
            showStatistics.Should().NotBeNullOrEmpty();

            var showId = "1390";

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/stats", showStatistics);

            Func<Task<TraktShowStatistics>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowStatisticsAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowStatisticsAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region ShowWatchingUsers

        [TestMethod]
        public void TestTraktShowsModuleGetShowWatchingUsers()
        {
            var showWatchingUsers = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowWatchingUsers.json");
            showWatchingUsers.Should().NotBeNullOrEmpty();

            var showId = "1390";

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/watching", showWatchingUsers);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowWatchingUsersAsync(showId).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowWatchingUsersWithExtendedOption()
        {
            var showWatchingUsers = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowWatchingUsers.json");
            showWatchingUsers.Should().NotBeNullOrEmpty();

            var showId = "1390";

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/watching?extended={extendedOption.ToString()}", showWatchingUsers);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowWatchingUsersAsync(showId, extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowWatchingUsersExceptions()
        {
            var showId = "1390";
            var uri = $"shows/{showId}/watching";

            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktListResult<TraktShowWatchingUser>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowWatchingUsersAsync(showId);
            act.ShouldThrow<TraktShowNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowWatchingUsersArgumentExceptions()
        {
            var showWatchingUsers = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowWatchingUsers.json");
            showWatchingUsers.Should().NotBeNullOrEmpty();

            var showId = "1390";

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/watching", showWatchingUsers);

            Func<Task<TraktListResult<TraktShowWatchingUser>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowWatchingUsersAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowWatchingUsersAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region ShowCollectionProgress

        [TestMethod]
        public void TestTraktShowsModuleGetShowCollectionProgress()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowCollectionProgressWithHidden()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowCollectionProgressWithSpecials()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowCollectionProgressComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowCollectionProgressExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowCollectionProgressArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region ShowWatchedProgress

        [TestMethod]
        public void TestTraktShowsModuleGetShowWatchedProgress()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowWatchedProgressWithHidden()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowWatchedProgressWithSpecials()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowWatchedProgressComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowWatchedProgressExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowWatchedProgressArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region TrendingShows

        [TestMethod]
        public void TestTraktShowsModuleGetTrendingShows()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetTrendingShowsWithExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetTrendingShowsWithPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetTrendingShowsWithExtendedOptionAndPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetTrendingShowsWithLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetTrendingShowsWithExtendedOptionAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetTrendingShowsWithPageAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetTrendingShowsComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetTrendingShowsExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region PopularShows

        [TestMethod]
        public void TestTraktShowsModuleGetPopularShows()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetPopularShowsWithExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetPopularShowsWithPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetPopularShowsWithExtendedOptionAndPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetPopularShowsWithLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetPopularShowsWithExtendedOptionAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetPopularShowsWithPageAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetPopularShowsComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetPopularShowsExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region MostPlayedShows

        [TestMethod]
        public void TestTraktShowsModuleGetMostPlayedShows()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetMostPlayedShowsWithPeriod()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetMostPlayedShowsWithExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetMostPlayedShowsWithPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetMostPlayedShowsWithLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetMostPlayedShowsWithPeriodAndExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetMostPlayedShowsWithPeriodAndPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetMostPlayedShowsWithPeriodAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetMostPlayedShowsWithExtendedOptionAndPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetMostPlayedShowsWithExtendedOptionAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetMostPlayedShowsWithPageAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetMostPlayedShowsWithExtendedOptionAndPageAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetMostPlayedShowsWithPeriodAndPageAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetMostPlayedShowsComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetMostPlayedShowsExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region MostWatchedShows

        [TestMethod]
        public void TestTraktShowsModuleGetMostWatchedShows()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetMostWatchedShowsWithPeriod()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetMostWatchedShowsWithExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetMostWatchedShowsWithPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetMostWatchedShowsWithLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetMostWatchedShowsWithPeriodAndExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetMostWatchedShowsWithPeriodAndPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetMostWatchedShowsWithPeriodAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetMostWatchedShowsWithExtendedOptionAndPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetMostWatchedShowsWithExtendedOptionAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetMostWatchedShowsWithPageAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetMostWatchedShowsWithExtendedOptionAndPageAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetMostWatchedShowsWithPeriodAndPageAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetMostWatchedShowsComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetMostWatchedShowsExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region MostCollectedShows

        [TestMethod]
        public void TestTraktShowsModuleGetMostCollectedShows()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetMostCollectedShowsWithPeriod()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetMostCollectedShowsWithExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetMostCollectedShowsWithPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetMostCollectedShowsWithLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetMostCollectedShowsWithPeriodAndExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetMostCollectedShowsWithPeriodAndPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetMostCollectedShowsWithPeriodAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetMostCollectedShowsWithExtendedOptionAndPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetMostCollectedShowsWithExtendedOptionAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetMostCollectedShowsWithPageAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetMostCollectedShowsWithExtendedOptionAndPageAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetMostCollectedShowsWithPeriodAndPageAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetMostCollectedShowsComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetMostCollectedShowsExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region MostAnticipatedShows

        [TestMethod]
        public void TestTraktShowsModuleGetMostAnticipatedShows()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetMostAnticipatedShowsWithExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetMostAnticipatedShowsWithPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetMostAnticipatedShowsWithExtendedOptionAndPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetMostAnticipatedShowsWithLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetMostAnticipatedShowsWithExtendedOptionAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetMostAnticipatedShowsWithPageAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetMostAnticipatedShowsComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetMostAnticipatedShowsExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region RecentlyUpdatedShows

        [TestMethod]
        public void TestTraktShowsModuleGetRecentlyUpdatedShowss()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetRecentlyUpdatedShowsWithStartDate()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetRecentlyUpdatedShowsWithExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetRecentlyUpdatedShowsWithPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetRecentlyUpdatedShowsWithLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetRecentlyUpdatedShowsWithStartDateAndExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetRecentlyUpdatedShowsWithStartDateAndPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetRecentlyUpdatedShowsWithStartDateAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetRecentlyUpdatedShowsWithExtendedOptionAndPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetRecentlyUpdatedShowsWithExtendedOptionAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetRecentlyUpdatedShowsWithPageAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetRecentlyUpdatedShowsWithExtendedOptionAndPageAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetRecentlyUpdatedShowsWithStartDateAndPageAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetRecentlyUpdatedShowsComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetRecentlyUpdatedShowsExceptions()
        {
            Assert.Fail();
        }

        #endregion
    }
}
