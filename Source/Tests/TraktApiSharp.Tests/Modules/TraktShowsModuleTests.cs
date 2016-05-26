namespace TraktApiSharp.Tests.Modules
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Modules;
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
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowWithExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region MultipleShows

        [TestMethod]
        public void TestTraktShowsModuleGetShowsArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region ShowAliases

        [TestMethod]
        public void TestTraktShowsModuleGetShowAliases()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowAliasesExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowAliasesArgumentExceptions()
        {
            Assert.Fail();
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
