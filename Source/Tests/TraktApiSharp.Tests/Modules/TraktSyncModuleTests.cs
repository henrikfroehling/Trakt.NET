namespace TraktApiSharp.Tests.Modules
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Modules;
    using Utils;

    [TestClass]
    public class TraktSyncModuleTests
    {
        [TestMethod]
        public void TestTraktSyncModuleIsModule()
        {
            typeof(TraktBaseModule).IsAssignableFrom(typeof(TraktSyncModule)).Should().BeTrue();
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

        #region GetLastActivities

        [TestMethod]
        public void TestTraktSyncModuleGetLastActivities()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetLastActivitiesExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region GetPlaybackProgress

        [TestMethod]
        public void TestTraktSyncModuleGetPlaybackProgress()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetPlaybackProgressWithExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetPlaybackProgressWithType()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetPlaybackProgressComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetPlaybackProgressExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region RemovePlaybackItem

        [TestMethod]
        public void TestTraktSyncModuleGetRemovePlaybackItem()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetRemovePlaybackItemExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetRemovePlaybackItemArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region GetCollectionMovies

        [TestMethod]
        public void TestTraktSyncModuleGetCollectionMovies()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetCollectionMoviesComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetCollectionMoviesExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region GetCollectionShows

        [TestMethod]
        public void TestTraktSyncModuleGetCollectionShows()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetCollectionShowsComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetCollectionShowsExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region AddCollectionItems

        [TestMethod]
        public void TestTraktSyncModuleAddCollectionItems()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleAddCollectionItemsExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleAddCollectionItemsArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region RemoveCollectionItems

        [TestMethod]
        public void TestTraktSyncModuleRemoveCollectionItems()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleRemoveCollectionItemsExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleRemoveCollectionItemsArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region GetWatchedMovies

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedMovies()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedMoviesComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedMoviesExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region GetWatchedShows

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedShows()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedShowsComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedShowsExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region GetWatchedHistory

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistory()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithType()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndId()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndIdAndStartDate()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndIdAndStartDateAndEndDate()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndIdAndStartDateAndPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndIdAndStartDateAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndIdAndStartDateAndPageAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndIdAndEndDateAndPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndIdAndEndDateAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndIdAndEndDateAndPageAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndStartDate()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndStartDateAndEndDate()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndStartDateAndEndDateAndPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndStartDateAndEndDateAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndStartDateAndEndDateAndPageAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndEndDate()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndEndDateAndPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndEndDateAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndEndDateAndPageAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndPageAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithStartDate()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithStartDateAndEndDate()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithStartDateAndEndDateAndPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithStartDateAndEndDateAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithStartDateAndEndDateAndPageAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithStartDateAndPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithStartDateAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithStartDateAndPageAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithEndDate()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithEndDateAndPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithEndDateAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithEndDateAndPageAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithPageAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region AddWatchedHistoryItems

        [TestMethod]
        public void TestTraktSyncModuleAddWatchedHistoryItems()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleAddWatchedHistoryItemsExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleAddWatchedHistoryItemsArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region RemoveWatchedHistoryItems

        [TestMethod]
        public void TestTraktSyncModuleRemoveWatchedHistoryItems()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleRemoveWatchedHistoryItemsExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleRemoveWatchedHistoryItemsArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region GetRatings

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatings()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatingsWithType()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatingsWithTypeAndRatingsFilter_1()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatingsWithTypeAndRatingsFilter_1_2()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatingsWithTypeAndRatingsFilter_1_2_3()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatingsWithTypeAndRatingsFilter_1_2_3_4()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatingsWithTypeAndRatingsFilter_1_2_3_4_5()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatingsWithTypeAndRatingsFilter_1_2_3_4_5_6()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatingsWithTypeAndRatingsFilter_1_2_3_4_5_6_7()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatingsWithTypeAndRatingsFilter_1_2_3_4_5_6_7_8()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatingsWithTypeAndRatingsFilter_1_2_3_4_5_6_7_8_9()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatingsWithTypeAndRatingsFilter_1_2_3_4_5_6_7_8_9_10()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatingsWithTypeAndRatingsFilter_1_2_3_4_5_6_7_8_9_10_11()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatingsWithTypeAndRatingsFilter_0_1_2_3_4_5_6_7_8_9_10()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatingsWithTypeAndRatingsFilter_1_2_3_4_5_6_7_8_9_11()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatingsWithTypeAndRatingsFilter_0_1_2_3_4_5_6_7_8_9()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatingsWithRatingsFilter()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatingsWithTypeAndExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatingsWithExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatingsComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatingsExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatingsArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region AddRatings

        [TestMethod]
        public void TestTraktSyncModuleAddRatings()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleAddRatingsExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleAddRatingsArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region RemoveRatings

        [TestMethod]
        public void TestTraktSyncModuleRemoveRatings()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleRemoveRatingsExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleRemoveRatingsArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region GetWatchlist

        [TestMethod]
        public void TestTraktSyncModuleGetWatchlist()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchlistWithType()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchlistWithExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchlistComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchlistExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region AddWatchlistItems

        [TestMethod]
        public void TestTraktSyncModuleAddWatchlistItems()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleAddWatchlistItemsExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleAddWatchlistItemsArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region RemoveWatchlistItems

        [TestMethod]
        public void TestTraktSyncModuleRemoveWatchlistItems()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleRemoveWatchlistItemsExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleRemoveWatchlistItemsArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion
    }
}
