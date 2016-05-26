namespace TraktApiSharp.Tests.Modules
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
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
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowTranslationsExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowTranslationsArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region ShowSingleTranslation

        [TestMethod]
        public void TestTraktShowsModuleGetShowSingleTranslation()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowSingleTranslationExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowSingleTranslationArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region ShowComments

        [TestMethod]
        public void TestTraktShowsModuleGetShowComments()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowCommentsWithSortOrder()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowCommentsWithPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowCommentsWithSortOrderAndPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowCommentsWithLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowCommentsWithSortOrderAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowCommentsWithPageAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowCommentsComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowCommentsExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowCommentsArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region ShowPeople

        [TestMethod]
        public void TestTraktShowsModuleGetShowPeople()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowPeopleWithExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowPeopleExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowPeopleArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region ShowRatings

        [TestMethod]
        public void TestTraktShowsModuleGetShowRatings()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowRatingsExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowRatingsArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region ShowRelatedShows

        [TestMethod]
        public void TestTraktShowsModuleGetShowRelatedShows()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowRelatedShowsWithExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowRelatedShowsWithPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowRelatedShowsWithExtendedOptionAndPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowRelatedShowsWithLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowRelatedShowsWithExtendedOptionAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowRelatedShowsWithPageAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowRelatedShowsComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowRelatedShowsExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowRelatedShowsArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region ShowStatistics

        [TestMethod]
        public void TestTraktShowsModuleGetShowStatistics()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowStatisticsExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowStatisticsArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region ShowWatchingUsers

        [TestMethod]
        public void TestTraktShowsModuleGetShowWatchingUsers()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowWatchingUsersWithExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowWatchingUsersExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowWatchingUsersArgumentExceptions()
        {
            Assert.Fail();
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
